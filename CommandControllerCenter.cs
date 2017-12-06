using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CommandControllerCenter : NetworkBehaviour {

	// Use this for initialization

	public GameObject[] racketPrefabs;

	bool up = false;

	void Start () {
	}

	[Command]
	public void CmdUpMoney(int i){
		RpcUpMoney (i);
	}

	[Command]
	public void CmdUpInfoAfterABet_Money(int z){
		Datas.instance.p2mon = z;
		int i = Datas.instance.whichBet;
		for (; i >= 1; i--) {
			if (Datas.instance.p1mon >= InBettingManager.instance.cal (i) && z >= InBettingManager.instance.cal (i)) {
				break;
			}
		}
		Datas.instance.whichBet = i;
	}

	[Command]
	public void CmdUpInfo(){
		InBettingManager.instance.UpdateMoney ();
	}

	[ClientRpc]
	public void RpcUpMoney(int i){
		if (isServer) {
			if (i == 1) {
				gamemanager.instance.SetMoney (Datas.instance.p1mon + (int)(cal (Datas.instance.whichBet) * 1.25f));
				gamemanager.instance.SetSecurity3 ();
				mydatabasecontroller.instance.Save ();
			} else {
				gamemanager.instance.SetMoney (Datas.instance.p1mon - cal (Datas.instance.whichBet));
				gamemanager.instance.SetSecurity3 ();
				mydatabasecontroller.instance.Save ();
			}
			Datas.instance.p1mon = gamemanager.instance.GetMoney ();
		} else {
			if (i == 1) {
				gamemanager.instance.SetMoney (Datas.instance.p2mon - cal (Datas.instance.whichBet));
				gamemanager.instance.SetSecurity3 ();
				mydatabasecontroller.instance.Save ();
			} else {
				gamemanager.instance.SetMoney (Datas.instance.p2mon + (int)(cal (Datas.instance.whichBet) * 1.25f));
				gamemanager.instance.SetSecurity3 ();
				mydatabasecontroller.instance.Save ();
			}
			foreach (GameObject tmp in GameObject.FindGameObjectsWithTag("Player")) {
				if (tmp.GetComponent<CommandControllerCenter> ().isLocalPlayer) {
					tmp.GetComponent<CommandControllerCenter> ().CmdUpInfoAfterABet_Money(gamemanager.instance.GetMoney());
				}
			}
		}
	}

	[Command]
	public void CmdJoined(string p2name, string p2country, int p2moneyed, int p2highscore){
		Datas.instance.p2name = p2name;
		Datas.instance.p2country = p2country;
		Datas.instance.p2hs = p2highscore;
		Datas.instance.p2mon = p2moneyed;
		Datas.instance.ClientReady = true;
	}

	[Command]
	public void CmdChangedBet(int i){
		Datas.instance.WhichBetPress (i);
	}

	[Command]
	public void CmdClientReadyNewBet(){
		Datas.instance.clientReadyNewBet = true;
	}

	[Command]
	public void CmdClientAccept(int tmp){
		if (tmp == 1) Datas.instance.clientAccept = true;
		else Datas.instance.clientAccept = false;
		audiomanager.instance.PLAYPOS ();
	}

	[Command]
	public void CmdSpawnRackets(){
	}

	[Command]
	public void CmdSetMatchAttibute(){
		MultiplayerManager.instance.Unlisted ();
	}

	void Update () {
		if (!isLocalPlayer)
			return;
		if (Datas.instance != null && Datas.instance.ServerReady && Datas.instance.ClientReady)
			return;
		if (isServer) {
			if (ClientScene.ready == true && Datas.instance != null && Datas.instance.ServerReady == false) {
				gamemanager.instance.whoIAm = 1;
				Datas.instance.ServerReady = true;
				Datas.instance.whichBet = 1;
				Datas.instance.p1name = PlayerPrefs.GetString ("myname");
				Datas.instance.p1country = PlayerPrefs.GetString ("mycountry");
				Datas.instance.p1mon = gamemanager.instance.GetMoney ();
				Datas.instance.p1hs = gamemanager.instance.GetHighScore ();
			}
		} else {
			if (ClientScene.ready == true && Datas.instance != null && Datas.instance.ClientReady == false && up == false) {
				gamemanager.instance.whoIAm = 2;
				CmdJoined (PlayerPrefs.GetString ("myname"),  PlayerPrefs.GetString ("mycountry"), gamemanager.instance.GetMoney(), gamemanager.instance.GetHighScore());
				CmdSetMatchAttibute ();
				up = true;
			}
		}
	}

	public int cal(int i) {
		if (i == 1)	return 10;
		else if (i == 2) return 30;
		else if (i == 3) return 50;
		else if (i == 4) return 100;
		else if (i == 5) return 200;
		else if (i == 6) return 500;
		else if (i == 7) return 1000;
		else return 10000;
	}
}

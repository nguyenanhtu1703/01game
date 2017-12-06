using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Datas : NetworkBehaviour{

	[SyncVar]
	public bool ClientReady, ServerReady, readyforprematch, matchreadyclient, matchreadyserver, hostReadyNewBet, clientReadyNewBet;

	[SyncVar(hook="HostAccepted")]
	public bool hostAccept;

	[SyncVar(hook="ClientAccepted")]
	public bool clientAccept;

	public static Datas instance = null;

	public bool enterABet, didDetectWinner;

	[SyncVar]
	public string p1name, p1country, p2name, p2country;

	[SyncVar]
	public int p1hs, p2hs;

	[SyncVar(hook="MoneyChanged1")]
	public int p1mon = -1;


	[SyncVar(hook="MoneyChanged2")]
	public int p2mon = -1;

	[SyncVar(hook="WinnerDetect")]
	public int winner;

	[SyncVar(hook="ChangedWhichBet")]
	public int whichBet;

	float clock;

	void Awake(){
		if (instance == null)
			instance = this;
		else {
			Destroy(this.gameObject);
			return;
		}
		DontDestroyOnLoad (this);
	}

	public void HostAccepted(bool valueChangedTo){
		hostAccept = valueChangedTo;
		if (valueChangedTo) audiomanager.instance.PLAYPOS ();
		enterABet = false;
		didDetectWinner = false;
	}

	public void ClientAccepted(bool valueChangedTo){
		clientAccept = valueChangedTo;
		if (valueChangedTo) audiomanager.instance.PLAYPOS ();
		enterABet = false;
		didDetectWinner = false;
	}

	public void ChangedWhichBet(int valueChangeTo){
		audiomanager.instance.PLAYPOS ();
		whichBet = valueChangeTo;
	}

	public void WhichBetPress(int i){
		if (gamemanager.instance.whoIAm == 2) {
		} else {
			whichBet = i;
			audiomanager.instance.PLAYPOS ();
		}
	}

	public void MoneyChanged1(int valueToChange){
		p1mon = valueToChange;
		if (InBettingManager.instance != null) InBettingManager.instance.UpdateMoney ();
	}

	public void MoneyChanged2(int valueToChange){
		p2mon = valueToChange;
		if (InBettingManager.instance != null) InBettingManager.instance.UpdateMoney ();
	}

	public void WinnerDetect(int valueChangeTo){
		if (isServer)
			return;
		if(valueChangeTo == 0){
			foreach (GameObject tmp in GameObject.FindGameObjectsWithTag("Player")) {
				if (tmp.GetComponent<CommandControllerCenter> ().isLocalPlayer) {
					tmp.GetComponent<CommandControllerCenter> ().CmdUpMoney(winner);
				}
			}
			InBettingManager.instance.enterBet = false;
		}
		winner = valueChangeTo;
		if (winner == 0)
			return;
		if (winner == 1) InBettingManager.instance.clock.text = "You Lose";
		else InBettingManager.instance.clock.text = "You Win";
	}

	[ClientRpc]
	public void RpcBet(){
		InBettingManager.instance.enterBet = true;
		InBettingManager.instance.timeClock = 10;
		InBettingManager.instance.StartCoroutine ("CoolDownCo");
	}

	void Start () {
		enterABet = false;
	}

	IEnumerator WaitSecondsCo(){
		yield return new WaitForSeconds (0.2f);
		InBettingManager.instance.Reset ();
	}

	[Server]
	void Update () {
		if (gamemanager.instance.whoIAm == 1) {
			if (Datas.instance.hostAccept == true && Datas.instance.clientAccept == true) {
				if (enterABet == false) {
					enterABet = true;
					RpcBet();
				}
			}
		}
		if (enterABet == false)
			return;
		if (isServer == false)
			return;
		if (hostReadyNewBet && clientReadyNewBet) {
			if (didDetectWinner == true)
				return;
			if (Random.Range (0, 1f) > 0.5f) {
				winner = 1;
			} else
				winner = 2;

			if (winner == 1) InBettingManager.instance.clock.text = "You Win";
			else InBettingManager.instance.clock.text = "You Lose";

			StartCoroutine ("WaitSecondsCo");
			didDetectWinner = true;
		}
	}
}

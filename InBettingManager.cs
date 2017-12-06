using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InBettingManager : MonoBehaviour {

	public Text p1name, p2name, p1country, p2country, p1montxt, p2montxt, p1bettxt, p2bettxt, moneyBet, clock;

	public Button[] buttons; 

	public Button p1, p2;

	public static InBettingManager instance = null; 

	public float timeClock;

	public bool enterBet;

	void Awake(){
		if (instance == null)
			instance = this;
		else Destroy (this.gameObject);
	}

	public void Start () {
		if (Datas.instance.isServer == true) {
			if (Datas.instance.p1mon < 10 || Datas.instance.p2mon < 10)
				Datas.instance.whichBet = 0;
			else
				Datas.instance.whichBet = 1;
		}
		if (gamemanager.instance.whoIAm ==  1) {
			p1name.text = Datas.instance.p1name;
			p1montxt.text = System.Math.Round (Datas.instance.p1mon / 10f, 1).ToString ();
			p2name.text = Datas.instance.p2name;
			p2montxt.text = System.Math.Round (Datas.instance.p2mon / 10f, 1).ToString ();
		} else {
			p1name.text = Datas.instance.p2name;
			p1montxt.text = System.Math.Round (Datas.instance.p2mon / 10f, 1).ToString ();
			p2name.text = Datas.instance.p1name;
			p2montxt.text = System.Math.Round (Datas.instance.p1mon / 10f, 1).ToString ();
		}
	}

	public void UpdateMoney(){
		if (Datas.instance == null)
			return;
		if (gamemanager.instance.whoIAm == 1) {
			p1name.text = Datas.instance.p1name;
			p1montxt.text = System.Math.Round (Datas.instance.p1mon / 10f, 1).ToString ();
			p2name.text = Datas.instance.p2name;
			p2montxt.text = System.Math.Round (Datas.instance.p2mon / 10f, 1).ToString ();
		} else {
			p1name.text = Datas.instance.p2name;
			p1montxt.text = System.Math.Round (Datas.instance.p2mon / 10f, 1).ToString ();
			p2name.text = Datas.instance.p1name;
			p2montxt.text = System.Math.Round (Datas.instance.p1mon / 10f, 1).ToString ();
		}
	}

	public void Accept(){
		if (Datas.instance.whichBet == 0) {
			audiomanager.instance.PLAYNEG ();
			return;
		}
		if (gamemanager.instance.whoIAm == 1) {
			if (Datas.instance.hostAccept == false)
				Datas.instance.hostAccept = true;
			else {
				if (timeClock >= 4) Datas.instance.hostAccept = false;
			}
			//audiomanager.instance.PLAYPOS ();
		} else {
			foreach (GameObject tmp in GameObject.FindGameObjectsWithTag("Player")) {
				if (tmp.GetComponent<CommandControllerCenter> ().isLocalPlayer) {
					if(Datas.instance.clientAccept == false) tmp.GetComponent<CommandControllerCenter> ().CmdClientAccept(1);
					else if (timeClock >= 4) tmp.GetComponent<CommandControllerCenter> ().CmdClientAccept(2);
				}
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

	public void WhichPress(int i){
		if (cal (i) > Datas.instance.p1mon || cal (i) > Datas.instance.p2mon) {
			audiomanager.instance.PLAYNEG ();
			return;
		}
		if (gamemanager.instance.whoIAm == 1) {
			if (Datas.instance.hostAccept == true)
				return;
		} else {
			if (Datas.instance.clientAccept == true)
				return;
		}
		if (gamemanager.instance.whoIAm == 1) {
			Datas.instance.WhichBetPress (i);
		}
		else {
			foreach (GameObject tmp in GameObject.FindGameObjectsWithTag("Player")) {
				if (tmp.GetComponent<CommandControllerCenter> ().isLocalPlayer) {
					tmp.GetComponent<CommandControllerCenter> ().CmdChangedBet (i);
				}
			}
		}
	}

	IEnumerator CoolDownCo(){
		clock.text = ((int)(timeClock)).ToString ();
		yield return new WaitForSeconds (0.2f);
		while (timeClock > 0) {
			if (Datas.instance.hostAccept == false || Datas.instance.clientAccept == false)
				break;
			yield return new WaitForSeconds (1);
			if (Datas.instance.hostAccept == false || Datas.instance.clientAccept == false)
				break;
			timeClock -= 1;
			clock.text = ((int)(timeClock)).ToString ();
		}
		if (Datas.instance.hostAccept == false || Datas.instance.clientAccept == false)
			yield break;
		if (gamemanager.instance.whoIAm == 1)
			Datas.instance.hostReadyNewBet = true;
		else {
			foreach (GameObject tmp in GameObject.FindGameObjectsWithTag("Player")) {
				if (tmp.GetComponent<CommandControllerCenter> ().isLocalPlayer) {
					tmp.GetComponent<CommandControllerCenter> ().CmdClientReadyNewBet();
				}
			}
		}
	}

	public void Reset(){
		if (gamemanager.instance.whoIAm == 2)
			return;
		int i = 0;
		for (i = Datas.instance.whichBet; i >= 1; i--) {
			if (Datas.instance.p1mon > cal (i) && Datas.instance.p2mon > cal (i))
				break;
		}
		Datas.instance.whichBet = i;
		Datas.instance.hostAccept = false;
		Datas.instance.clientAccept = false;
		Datas.instance.enterABet = false;
		Datas.instance.winner = 0;
		Datas.instance.hostReadyNewBet = false;
		Datas.instance.clientReadyNewBet = false;
		Datas.instance.didDetectWinner = false;
		InBettingManager.instance.enterBet = false;
	}

	void OnEnalble(){
	}

	void Update () {
		if (Datas.instance == null)
			return;
		for(int i = 0; i <= 7; i++){
			buttons [i].GetComponent<Image>().color = new Color32(230, 230, 230, 255);
			if (i == Datas.instance.whichBet - 1) {
				buttons [i].GetComponent<Image>().color = new Color32(150, 150, 150, 255);
			}
		}

		UpdateMoney ();

		p1.GetComponent<Image>().color = new Color32(230, 230, 230, 255);
		p2.GetComponent<Image>().color = new Color32(230, 230, 230, 255);

		p1.GetComponentInChildren<Text>().text = "Accept";
		p2.GetComponentInChildren<Text>().text = "Accept";

		if (gamemanager.instance.whoIAm == 1) {
			if (Datas.instance.hostAccept == true) {
				p1.GetComponent<Image> ().color = new Color32 (150, 150, 150, 255);
				p1.GetComponentInChildren<Text>().text = "x";
			}
			if (Datas.instance.clientAccept == true) {
				p2.GetComponent<Image> ().color = new Color32 (150, 150, 150, 255);
				p2.GetComponentInChildren<Text>().text = "Accepted";
			}
		} else {
			if (Datas.instance.clientAccept == true) {
				p1.GetComponent<Image> ().color = new Color32 (150, 150, 150, 255);
				p1.GetComponentInChildren<Text>().text = "x";
			}
			if (Datas.instance.hostAccept == true) {
				p2.GetComponent<Image> ().color = new Color32 (150, 150, 150, 255);
				p2.GetComponentInChildren<Text>().text = "Accepted";
			}
		}

		switch (Datas.instance.whichBet) {
		case 1:
			moneyBet.text = "1$";
			break;
		case 2:
			moneyBet.text = "3$";
			break;
		case 3:
			moneyBet.text = "5$";
			break;
		case 4:
			moneyBet.text = "10$";
			break;
		case 5:
			moneyBet.text = "20$";
			break;
		case 6:
			moneyBet.text = "50$";
			break;
		case 7:
			moneyBet.text = "100$";
			break;
		case 8:
			moneyBet.text = "1000$";
			break;
		}
	}
}

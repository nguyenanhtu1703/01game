using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InBetWithComputerManager : MonoBehaviour {

	// Use this for initialization

	public Text myName, myMoney, betTxt, clockTxt;

	public int whichBet = 0;

	public Button[] buttons;

	public bool accepted;

	public float timeClock;

	public Button p1;

	void Start () {
		myMoney.text = System.Math.Round(gamemanager.instance.GetMoney () / 10f, 1).ToString() + "$";
		myName.text = PlayerPrefs.GetString ("myname");
		whichBet = 1;
		if (gamemanager.instance.GetMoney () < 10)
			whichBet = 0;
	}

	public void BetPress(int i){
		if (gamemanager.instance.GetMoney () < cal (i)) {
			audiomanager.instance.PLAYNEG ();
			return;
		}
		audiomanager.instance.PLAYPOS();
		whichBet = i;
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

	IEnumerator BetCooldownCo() {
		clockTxt.text = ((int)(timeClock)).ToString();
		while (timeClock > 0) {
			if (accepted == false)
				break;
			yield return new WaitForSeconds (1);
			if (accepted == false)
				break;
			timeClock -= 1;
			clockTxt.text = ((int)(timeClock)).ToString();
		}
		if (accepted == true) {
			if (Random.Range (0, 1f) > 0.5f) {
				clockTxt.text = "You Win";
				gamemanager.instance.SetMoney (gamemanager.instance.GetMoney() + cal(whichBet));
				gamemanager.instance.SetSecurity3 ();
				mydatabasecontroller.instance.Save ();
			} else {
				clockTxt.text = "You Lose";
				gamemanager.instance.SetMoney (gamemanager.instance.GetMoney() - cal(whichBet));
				gamemanager.instance.SetSecurity3 ();
				mydatabasecontroller.instance.Save ();
			}
			myMoney.text = System.Math.Round(gamemanager.instance.GetMoney () / 10f, 1).ToString() + "$";
		}
		Reset ();
		int i;
		for (i = whichBet; i >= 1; i--)
			if (gamemanager.instance.GetMoney () >= cal (i)) {
				break;
			}
		whichBet = i;
	}

	void Reset(){
		accepted = false;
		p1.GetComponentInChildren<Text>().text = "Accept";
	}

	public void Accept(){
		if (accepted) {
			Reset ();
			return;
		}
		if (whichBet <= 0) {
			audiomanager.instance.PLAYNEG ();
			return;
		}
		audiomanager.instance.PLAYPOS ();
		timeClock = 5;
		accepted = true;
		StartCoroutine (BetCooldownCo());
	}
	
	// Update is called once per frame
	void Update () {

		myMoney.text = System.Math.Round(gamemanager.instance.GetMoney () / 10f, 1).ToString() + "$";

		for(int i = 0; i <= 7; i++){
			buttons [i].GetComponent<Image>().color = new Color32(230, 230, 230, 255);
			if (i == whichBet - 1) {
				buttons [i].GetComponent<Image>().color = new Color32(150, 150, 150, 255);
			}
		}
		if (accepted) p1.GetComponent<Image>().color = new Color32(150, 150, 150, 255);
		else p1.GetComponent<Image>().color = new Color32(230, 230, 230, 255);
		if(accepted) p1.GetComponentInChildren<Text>().text = "x";

		switch (whichBet) {
		case 1:
			betTxt.text = "1$";
			break;
		case 2:
			betTxt.text = "3$";
			break;
		case 3:
			betTxt.text = "5$";
			break;
		case 4:
			betTxt.text = "10$";
			break;
		case 5:
			betTxt.text = "20$";
			break;
		case 6:
			betTxt.text = "50$";
			break;
		case 7:
			betTxt.text = "100$";
			break;
		case 8:
			betTxt.text = "1000$";
			break;
		}
	}
}

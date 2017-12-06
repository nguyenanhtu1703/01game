using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MultiplayerManager : MonoBehaviour
{
	public string _Username = "Username";

	float randomtimewait;
	float starttime;

	public static MultiplayerManager instance = null;

	public Text text, textwarninternet, text2;

	public bool hosted, joinned, listed, enter, searching;

	string gameName = "Default";

	public Button start, findingbutton;

	public GameObject panel1, panel2;

	public Text matchID;

	public Text roomName, warningTxt;

	public bool amIHost, randomFinding;

	public GameObject inBetMultiplayerPanel, statusPanel, randomFindingPanel;

	public bool quit = false, deactive = false;

	string oldPass = "123wwwzzzaaa";

	IEnumerator MustSetPasswordCo(){
		warningTxt.gameObject.SetActive (true);
		yield return new WaitForSeconds (2);
		warningTxt.gameObject.SetActive (false);
	}

	void Start()
	{
		instance = this;
		randomtimewait = Random.Range (0, 3);
		enter = false;
		listed = false;
		starttime = Time.time;
		hosted = false;
		joinned = false;
	}

	public void ReSet(){
		randomtimewait = Random.Range (0, 3);
		enter = false;
		listed = false;
		starttime = Time.time;
		hosted = false;
		joinned = false;
		searching = false;
		randomFinding = false;
	}

	public void QuitMultiplayer(){
		if (Datas.instance.isServer) {
			Datas.instance.ClientReady = false;
			Datas.instance.ServerReady = false;
			if (randomFinding)
				deactive = true;
			GetComponent<CustomNetworkManager> ().StopHost ();
		} else {
			Datas.instance.ClientReady = false;
			Datas.instance.ServerReady = false;
			if (randomFinding)
				deactive = true;
			GetComponent<CustomNetworkManager> ().StopClient ();
		}
	}

	public void IWILLHOST(){
		amIHost = true;
		randomFinding = false;
	}

	public void IWILLFINDMYFRIEND(){
		amIHost = false;
		randomFinding = false;
	}

	public void IWILLFINDRANDOM(){
		randomFinding = true;
		amIHost = false;
		searching = true;
	}

	public void starttosearch(){
		if (hosted || joinned)
			return;
		if (internetchecker.instance.internet == true && roomName.text != "") {
			audiomanager.instance.SOUND.PlayOneShot (audiomanager.instance.positive);
			searching = true;
			enter = false;
			listed = false;
			starttime = Time.time;
			hosted = false; 
			joinned = false;
			gameName = roomName.text;
			statusPanel.gameObject.SetActive (true);
		} else {
			StartCoroutine (MustSetPasswordCo());
			audiomanager.instance.SOUND.PlayOneShot (audiomanager.instance.negative);
		}
	}

	void Update()
	{
		if (searching == false) {
			return;
		}
		if (enter)
			return;
		if (Datas.instance != null && Datas.instance.ClientReady && Datas.instance.ServerReady) {
			inBetMultiplayerPanel.gameObject.SetActive (true);
			if (randomFinding)
				gamemanager.instance.randomFindingPanel.gameObject.SetActive (false);
			statusPanel.gameObject.SetActive (false);
			if (InBettingManager.instance != null)
				InBettingManager.instance.Start ();
			text.gameObject.SetActive (false);
			enter = true;
			return;
		}
		if (GetComponent<CustomNetworkManager>().matchMaker == null)
		{
			GetComponent<CustomNetworkManager>().StartMatchMaker();
		}
		if (hosted || joinned)
			return;
		if (GetComponent<CustomNetworkManager> ().matchMaker == null)
			return;
		if (listed == false) {
			GetComponent<CustomNetworkManager> ().matchMaker.ListMatches (0, 10, "", true, 0, 0, GetComponent<CustomNetworkManager> ().OnMatchList);
			listed = true;
		}
		if (GetComponent<CustomNetworkManager> ().matches == null)
			return;
		if (amIHost && randomFinding == false) {
			HostGame ();
			hosted = true;
			text.gameObject.SetActive (true);
			text.text = "Created";
			text.fontStyle = FontStyle.Bold;
		} else if (randomFinding == false && amIHost == false) {
			text.gameObject.SetActive (true);
			if (string.Compare (oldPass, gameName) != 0) {
				text.text = "Finding...";
				text.fontStyle = FontStyle.Italic;
				oldPass = gameName;
			}
			if (GetComponent<CustomNetworkManager> ().matches.Count > 0) {
				foreach (var _Match in GetComponent<CustomNetworkManager>().matches) {
					if (string.Compare (roomName.text, _Match.name) == 0) {
						GetComponent<CustomNetworkManager> ().matchName = _Match.name;
						GetComponent<CustomNetworkManager> ().matchSize = (uint)_Match.currentSize;
						GetComponent<CustomNetworkManager> ().matchMaker.JoinMatch (_Match.networkId, "", "", "", 0, 0, GetComponent<CustomNetworkManager> ().OnMatchJoined);
						joinned = true;
						text.text = "Connecting...";
						text.fontStyle = FontStyle.Bold;
						break;
					}
				}
			}
			if (joinned == false) {
				text.text = "Not found";
				text.fontStyle = FontStyle.Bold;
			}
		} else {
			Debug.Log ("123");
			if (GetComponent<CustomNetworkManager> ().matches.Count > 0) {
				foreach (var _Match in GetComponent<CustomNetworkManager>().matches) {
						GetComponent<CustomNetworkManager> ().matchName = _Match.name;
						GetComponent<CustomNetworkManager> ().matchSize = (uint)_Match.currentSize;
						GetComponent<CustomNetworkManager> ().matchMaker.JoinMatch (_Match.networkId, "", "", "", 0, 0, GetComponent<CustomNetworkManager> ().OnMatchJoined);
						joinned = true;
						text2.gameObject.SetActive (true);
						text2.text = "Finding...";
						text.fontStyle = FontStyle.Bold;
						break;
				}
			} else {
				HostGame2();
				hosted = true;
				text2.gameObject.SetActive (true);
				text2.text ="Finding...";
				text.fontStyle = FontStyle.Bold;
			}
		}
	}

	public void Leave(){
		GetComponent<CustomNetworkManager> ().matchMaker.DropConnection (GetComponent<CustomNetworkManager> ().matchInfo.networkId, GetComponent<CustomNetworkManager> ().matchInfo.nodeId, 0, GetComponent<CustomNetworkManager> ().OnDropConnection);
	}

	public void Unlisted(){
		GetComponent<CustomNetworkManager> ().matchMaker.SetMatchAttributes(GetComponent<CustomNetworkManager> ().matchInfo.networkId, false, 0, GetComponent<CustomNetworkManager> ().OnSetMatchAttributes);
		quit = false;
	}

	public void Unlisted2(){
		if (hosted == true) {
			GetComponent<CustomNetworkManager> ().matchMaker.SetMatchAttributes (GetComponent<CustomNetworkManager> ().matchInfo.networkId, false, 0, GetComponent<CustomNetworkManager> ().OnSetMatchAttributes);
			quit = true;
		} else
			GetComponent<CustomNetworkManager> ().StopMatchMaker ();
	}

	public void Unlisted3(){
		if (randomFinding) {
			if (hosted == true) {
				GetComponent<CustomNetworkManager> ().matchMaker.SetMatchAttributes (GetComponent<CustomNetworkManager> ().matchInfo.networkId, false, 0, GetComponent<CustomNetworkManager> ().OnSetMatchAttributes);
				if (randomFinding)
					deactive = true;
			} else
				GetComponent<CustomNetworkManager> ().StopMatchMaker ();
		} else
			gamemanager.instance.mainRandomFindingPanel.gameObject.SetActive (false);
	}

	void HostGame()
	{
		GetComponent<CustomNetworkManager>().matchMaker.CreateMatch(gameName,  2, true, "", "", "", 0, 0, GetComponent<CustomNetworkManager>().OnMatchCreate);
	}

	void HostGame2()
	{
		GetComponent<CustomNetworkManager>().matchMaker.CreateMatch(((int)(Random.Range(0, 10000000))).ToString(),  2, true, "", "", "", 0, 0, GetComponent<CustomNetworkManager>().OnMatchCreate);
	}

	void OnApplicationQuit() {
	}
}
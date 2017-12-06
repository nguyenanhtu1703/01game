using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class CustomNetworkManager : NetworkManager {
	public static CustomNetworkManager instance = null;

	void Awake()
	{
		if (instance == null) {
			instance = this;
		} else {
			DestroyImmediate (this.gameObject);
		}
		NetworkManager.singleton = instance;
	}

	void Start () {
	}

	public override void OnStartClient (NetworkClient client)
	{
		base.OnStartClient (client);
		Debug.Log ("Client connected");
	}

	public override void OnMatchCreate (bool success, string extendedInfo, MatchInfo matchInfo)
	{
		base.OnMatchCreate (success, extendedInfo, matchInfo);
		if (success) {
			Debug.Log ("Created Successfully");
		}
	}

	public override void OnStopHost ()
	{
		base.OnStopHost ();
		Debug.Log ("Stoped host");
	}

	public override void OnStopServer ()
	{
		base.OnStopServer ();
		Debug.Log ("Stoped Server");
	}

	public override void OnStopClient ()
	{
		base.OnStopClient ();
		MultiplayerManager.instance.text.gameObject.SetActive (false);
		MultiplayerManager.instance.ReSet ();
		if (MultiplayerManager.instance.deactive) {
			MultiplayerManager.instance.deactive = false;
			gamemanager.instance.mainRandomFindingPanel.gameObject.SetActive (false);
			gamemanager.instance.randomFindingPanel.gameObject.SetActive (false);
		}
		Debug.Log ("Stoped Client");
	}

	public override void OnDropConnection (bool success, string extendedInfo)
	{
		base.OnDropConnection (success, extendedInfo);
		if (success) {
			Debug.Log ("Dropped connection");
		}
	}

	public override void OnSetMatchAttributes (bool success, string extendedInfo)
	{
		base.OnSetMatchAttributes (success, extendedInfo);
		if (MultiplayerManager.instance.quit == true || MultiplayerManager.instance.deactive == true) {
			instance.StopHost ();
		}
	}

	public override void OnServerAddPlayer (NetworkConnection conn, short playerControllerId)
	{
		base.OnServerAddPlayer (conn, playerControllerId);
		Debug.Log ("Added a Player");
	}

	// Update is called once per frame
	void Update () {

	}
}

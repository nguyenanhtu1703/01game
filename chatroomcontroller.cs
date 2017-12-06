using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chatroomcontroller : MonoBehaviour {

	// Use this for initialization

	public Text mymessage;
	float timedidsend;
	int numberoftime;
	public float duration;
	float delta;
	public Text[] listmessage;

	public static chatroomcontroller instance = null;

	void Awake(){
		if (instance == null)
			instance = this;
		else
			Destroy (this.gameObject);
		DontDestroyOnLoad (this.gameObject);
	}

	void Start () {
		delta = duration;
	}
//
//	IEnumerator refreshCo(){
//		for (int i = 1; i <= 30; i++) {
//			mydatabasecontroller.instance.getMessage (i);
//			yield return new WaitForSeconds (0.1f);
//		}
//	}

	public void assign(int n, string tmp){
		string a = "";
		int i = 0;
		for(; i < tmp.Length; i++){
			if(i < tmp.Length - 1 && tmp[i] == '^' && tmp[i + 1] == '$') break;
			else a = a + tmp[i].ToString();
		}
		i += 2;
		string b = "";
		for(; i < tmp.Length; i++){
			b = b + tmp[i].ToString();
		}
		listmessage [n - 1].text = a;
		listmessage [n - 1].transform.GetChild (0).GetComponent<Text> ().text = b;
	}

	public void refresh(){
		//StartCoroutine (refreshCo ());
	}

	public void Send(){
		if (mymessage.text.Length <= 0)
			return;
		//if (numberoftime == 3 && Time.time - timedidsend <= 60)
			//return;
		//if (numberoftime == 0)
		//	timedidsend = Time.time;
	//	numberoftime++;
		mydatabasecontroller.instance.SendMessage (mymessage.text);
	}

	// Update is called once per frame
	void Update () {
		if (Time.time - timedidsend >= 60) {
			numberoftime = 0;
		}
		delta -= Time.deltaTime;
		if (delta <= 0) {
		//	StartCoroutine (refreshCo ());
			delta = duration;
		}
	}
}

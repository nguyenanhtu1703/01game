using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class runtext : MonoBehaviour {

	// Use this for initialization

	IEnumerator runtextani(){
		for (int i = 1; i <= 5; i++) {
			transform.localScale = new Vector3 (transform.localScale.x * 1.1f, transform.localScale.y * 1.1f, transform.localScale.z * 1.1f);
			gamemanager.instance.numberoftry += 50;
			gamemanager.instance.numberoftrytext.text = gamemanager.instance.numberoftry.ToString ();
			PlayerPrefs.SetInt ("noft", gamemanager.instance.numberoftry);
			yield return new WaitForSeconds (0.05f);
		}
		for (int i = 1; i <= 5; i++) {
			transform.localScale = new Vector3 (transform.localScale.x / 1.1f, transform.localScale.y / 1.1f, transform.localScale.z / 1.1f);	
			gamemanager.instance.numberoftry += 50;
			gamemanager.instance.numberoftrytext.text = gamemanager.instance.numberoftry.ToString ();
			PlayerPrefs.SetInt ("noft", gamemanager.instance.numberoftry);
			yield return new WaitForSeconds (0.05f);
		}
	}

	public void startanimationtext(){
		StartCoroutine (runtextani ());
	}

	void Update () {
		
	}
}

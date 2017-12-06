using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audiomanager : MonoBehaviour {

	// Use this for initialization

	public static audiomanager instance = null;

	public AudioClip positive, negative, yell, dis;

	public Button button;

	public AudioSource SOUND;

	void Awake(){
		if (instance == null) {
			instance = this;   
		} else
			Destroy (this.gameObject);
		DontDestroyOnLoad (this.gameObject);
	}

	public void mute(){
		PlayerPrefs.SetInt ("SOUND", 1 - PlayerPrefs.GetInt ("SOUND"));
		if (PlayerPrefs.GetInt ("SOUND") == 0)
			PLAYPOS ();
		button.GetComponent<Image> ().sprite = Resources.Load ("sound" + PlayerPrefs.GetInt ("SOUND").ToString(), typeof(Sprite)) as Sprite;
	}

	void Start () {
		button.GetComponent<Image> ().sprite = Resources.Load ("sound" + PlayerPrefs.GetInt ("SOUND").ToString(), typeof(Sprite)) as Sprite;
	}

	public void PLAYPOS(){
		if (PlayerPrefs.GetInt ("SOUND") == 0) {
			SOUND.PlayOneShot (positive);
		}
	}

	public void PLAYNEG(){
		if (PlayerPrefs.GetInt ("SOUND") == 0) {
			SOUND.PlayOneShot (negative);
		}
	}

	public void STOP(){
		SOUND.Stop ();
	}

	public void PLAYYELL(){
		if (PlayerPrefs.GetInt ("SOUND") == 0) {
			SOUND.PlayOneShot (yell);
		}
	}

	public void PLAYDIS(){
		if (PlayerPrefs.GetInt ("SOUND") == 0) {
			SOUND.PlayOneShot (dis);
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}

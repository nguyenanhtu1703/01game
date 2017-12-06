using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class internetchecker : MonoBehaviour {

	public static internetchecker instance = null;

	public float duration;
	public float delta, timedid;
	bool isRunning;
	public bool internet;
	public float timedis;
	public bool entergame;
	public GameObject panel, panel2, panel3, panel4, panel5;
	public Image runimage;
	public TextMeshProUGUI textrun;
	bool did = false;

	void Awake(){
		if (instance == null) {
			instance = this;
		} else {
			Destroy (this.gameObject);
		}
		DontDestroyOnLoad (this.gameObject);
	}

	void Start () {
		delta = 0;
		entergame = true;
		timedid = -1;
		internet = false;
		isRunning = false;
	}

	IEnumerator CheckingCo(){
		if (isRunning == false) {
			isRunning = true;
			WWW www = new WWW("http://google.com");
			yield return www;
			if (www.isDone && www.bytesDownloaded == 0) {
				if (internet == true)
					timedis = Time.time;
				internet = false;
			};

			if (www.isDone && www.bytesDownloaded > 0) {
				internet = true;
			}
			isRunning = false;
		}
	}

	// Update is called once per frame
	void Update () {
		if (internet == true && Time.time >= 1.5f) {
			panel.gameObject.SetActive (false);
			if (panel3.gameObject.activeInHierarchy == false && entergame == true) {
				panel2.gameObject.SetActive (true);
				entergame = false;
			}
		}
		if (panel2.activeInHierarchy) {
			if (mydatabasecontroller.instance.t5 == true || mydatabasecontroller.instance.t6 == true) {
				panel2.gameObject.SetActive (false);
				if(timedid == -1) timedid = Time.time;
				panel4.gameObject.SetActive (true);
			}
		}
		if (internet == false && Time.time - timedis >= 4) {
			panel.gameObject.SetActive (true);
		}
		if (panel4.gameObject.activeInHierarchy && Time.time - timedid >= 1) {
			if (mydatabasecontroller.instance.t9 == true) {
				//panel4.gameObject.SetActive (false);
				StartCoroutine(TestCo());
			}
		}
		delta -= Time.deltaTime;
		if (delta <= 0) {
			StartCoroutine ("CheckingCo");
			delta = duration;
		}
	}

	IEnumerator TestCo(){
		runimage.gameObject.GetComponent<imagerotate> ().speed = 0;
		textrun.text = "Done!";
		yield return new WaitForSeconds (0f);
		Vector3 ray = runimage.transform.TransformPoint(Vector3.zero);
		if (did == false) {
		//	Instantiate (gamemanager.instance.fx2 [Random.Range (0, gamemanager.instance.fx2.Length - 1)], new Vector3 (ray.x, ray.y, ray.z), Quaternion.identity);
			did = true;
		}
		panel4.gameObject.SetActive (false);
		if (mydatabasecontroller.instance.t10 == true) {
			panel5.gameObject.SetActive (true);
			mydatabasecontroller.instance.t10 = false;
		}
	}
}

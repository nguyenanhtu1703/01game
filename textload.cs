using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class textload : MonoBehaviour {

	// Use this for initialization

	public string z;
	public TextMeshProUGUI txt;
	float z0, k;
	int t;

	void Start () {
		z0 = 1.5f;
		k = 0;
	}
	
	// Update is called once per frame
	void Update () {
		k -= Time.deltaTime;
		if (k <= 0) {
			k = z0;
			if (t == 1)
				t = 2;
			else if (t == 2)
				t = 3;
			else
				t = 1;
	//		if(t == 1) txt.text = z + " .";
//			if(t == 2) txt.text = z + " ..";
//			if(t == 3) txt.text = z + " ...";
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textchecking : MonoBehaviour {

	// Use this for initialization
	public string text;
	public float duration;
	int which;
	float delta;

	void Start () {
		delta = duration;
		which = 1;
	}
	
	// Update is called once per frame
	void Update () {
		delta -= Time.deltaTime;
		if (delta <= 0) {
			if (which == 1)
				which = 2;
			else if (which == 2)
				which = 3;
			else
				which = 1;
			delta = duration;
		}
		if(which == 1) gameObject.GetComponent<Text>().text = text + " .";
		if(which == 2) gameObject.GetComponent<Text>().text = text + " ..";
		if(which == 3) gameObject.GetComponent<Text>().text = text + " ...";
	}
}

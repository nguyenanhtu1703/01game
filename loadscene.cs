using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadscene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > 2)
			Application.LoadLevel (1);	
	}
}

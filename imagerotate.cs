using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class imagerotate : MonoBehaviour {

	// Use this for initialization
	public float speed;

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(speed >= 800) transform.Rotate ( - Vector3.forward * speed * Time.deltaTime);
		else transform.Rotate ( - Vector3.forward * speed * Time.deltaTime);
	}
}

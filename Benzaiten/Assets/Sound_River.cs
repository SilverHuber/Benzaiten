using UnityEngine;
using System.Collections;

public class Sound_River : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D coll){

		if (coll.gameObject.name == "Player") {
			print ("colliding with sound barrier for river!");

		}

	}


}

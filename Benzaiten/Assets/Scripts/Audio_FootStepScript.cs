using UnityEngine;
using System.Collections;

public class Audio_FootStepScript : MonoBehaviour {

	public string FootstepSwitch;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D (Collider2D coll){
	
		if (coll.gameObject.name == "Player") {
			print ("colliding");
			MainSoundScript.Instance.SetFootstepSwitch (FootstepSwitch);
		
		}
	
	}
}

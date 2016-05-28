using UnityEngine;
using System.Collections;

public class Player_FootStepScript : MonoBehaviour {

	Vector2 walkingSpeed;
	public Rigidbody2D rigid2D;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		walkingSpeed = rigid2D.velocity;

		print (walkingSpeed.x);
		if (walkingSpeed.x > 0.2 || walkingSpeed.y > 0.2) {
			MainSoundScript.Instance.PlaySFX ("Footstep_Start"); 
		} else {
			MainSoundScript.Instance.PlaySFX ("Footstep_Stop"); 
		}
	}
}

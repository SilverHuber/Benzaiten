using UnityEngine;
using System.Collections;

public class Tengu : MonoBehaviour
{
	private Animator thisAnimator;
	// Use this for initialization
	void Start ()
	{
		thisAnimator = GetComponent <Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		print ("Something Enters");
		if (other.name == "Player")
		{
			Debug.Log ("Player enters");
			thisAnimator.SetBool ("Looking", true);
		}

	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.name == "Player")
		{
			thisAnimator.SetBool ("Looking", false);
		}

	}
}

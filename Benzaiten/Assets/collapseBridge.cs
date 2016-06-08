using UnityEngine;
using System.Collections;

public class collapseBridge : MonoBehaviour
{
	public GameObject bridge;
	private Animator bridgeAnimator;
	// Use this for initialization
	void Start ()
	{
		bridgeAnimator = bridge.GetComponent <Animator> ();
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name == "Kenji")
		{
			print ("kenji");
			bridgeAnimator.SetBool ("Collapse", true);
		}
	}
}

using UnityEngine;
using System.Collections;

public class FinalBridge : MonoBehaviour
{
	private RestoreObject thisRO;
	private Animator thisAnimator;

	// Use this for initialization
	void Start ()
	{
		thisAnimator = GetComponent <Animator> ();
		thisRO = GetComponent <RestoreObject> ();

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (thisRO.blessed == true)
		{
			thisAnimator.SetBool ("Collapse", false);
		}
	}
}

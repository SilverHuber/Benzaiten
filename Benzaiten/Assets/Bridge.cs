using UnityEngine;
using System.Collections;

public class Bridge : MonoBehaviour
{

	private RestoreObject thisRO;
	private Animator thisAnimator;


	void Start ()
	{
		thisRO = GetComponent <RestoreObject> ();
		thisAnimator = GetComponent <Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (thisRO.blessed == true)
		{

			thisAnimator.SetBool ("Restored", true);
			GetComponent <Collider2D> ().enabled = false;

			GameObject.Find ("2.Bridge").GetComponent <BridgeSequence> ().restored = true;
		
		}
	}

}

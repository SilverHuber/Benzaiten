using UnityEngine;
using System.Collections;

public class InterActionScanner : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}


	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "RestoreObject")
		{
			GetComponentInParent <FluteMode> ().interactiveObjects.Add (other.gameObject);
		}
	}


	void OnTriggerExit2D (Collider2D other)
	{
		if (other.tag == "RestoreObject")
		{
			//	GameObject itemToDelete = GetComponentInParent <FluteMode> ().interactiveObjects.Contains (other.name);
			GetComponentInParent <FluteMode> ().interactiveObjects.Remove (other.gameObject);
		}
	}
}

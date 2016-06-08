using UnityEngine;
using System.Collections;

public class Cat : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}


	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name == "Player")
			GetComponent <Animator> ().SetBool ("Collapse", true);
	}

}

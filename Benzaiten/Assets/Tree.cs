using UnityEngine;
using System.Collections;

public class Tree : MonoBehaviour
{

	private RestoreObject thisRO;
	// Use this for initialization
	void Start ()
	{
		thisRO = GetComponent <RestoreObject> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
		if (thisRO.blessed == true)
		{
			print ("leaves");

		}

	}
}

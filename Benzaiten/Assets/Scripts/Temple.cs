using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Temple : MonoBehaviour
{

	private RestoreObject thisRO;

	public List<SpriteRenderer> itemsToFadeAway = new List<SpriteRenderer> ();
	public List<SpriteRenderer> itemsToFadeIn = new List<SpriteRenderer> ();


	// Use this for initialization
	void Start ()
	{
		thisRO = GetComponent <RestoreObject> ();

		foreach (Transform child in transform)
		{
			itemsToFadeAway.Add (child.GetComponent <SpriteRenderer> ());

		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
		if (thisRO.blessed == true)
		{
			print ("leaves");
			foreach (SpriteRenderer sR in itemsToFadeAway)
			{
				Color color = sR.color;
				color.a -= 0.03f;
				sR.color = color;
			}

			print ("leaves");
			foreach (SpriteRenderer sR in itemsToFadeIn)
			{
				Color color = sR.color;
				color.a += 0.03f;
				sR.color = color;
			}
		}

	}
}

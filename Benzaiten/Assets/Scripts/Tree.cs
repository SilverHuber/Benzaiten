using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tree : MonoBehaviour
{

	private RestoreObject thisRO;

	public List<SpriteRenderer> leavesRenderers = new List<SpriteRenderer> ();

	// Use this for initialization
	void Start ()
	{
		thisRO = GetComponent <RestoreObject> ();

		foreach (Transform child in transform)
		{
			leavesRenderers.Add (child.GetComponent <SpriteRenderer> ());
			child.GetComponent<SpriteRenderer> ().sortingLayerName = GetComponent <SpriteRenderer> ().sortingLayerName;
			child.GetComponent<SpriteRenderer> ().sortingOrder = GetComponent <SpriteRenderer> ().sortingOrder + 1;

		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
		if (thisRO.blessed == true)
		{
			//print ("leaves");
			foreach (SpriteRenderer sR in leavesRenderers)
			{
				Color color = sR.color;
				color.a += 0.03f;
				sR.color = color;
			}

			if (name == "Bridge")
			{
				GetComponent <Collider2D> ().enabled = false;
			}
		}

	}
}

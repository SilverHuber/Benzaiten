using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class LineRenderScript : MonoBehaviour
{
	private LineRenderer lR;
	public int sortingOrder;

	public List<Transform> switches = new List<Transform> ();

	// Use this for initialization
	void Start ()
	{
		
		lR = GetComponent <LineRenderer> ();
		lR.sortingLayerName = "Front";
		lR.sortingOrder = 0;


		lR.SetVertexCount (switches.Count);
	
		for (int i = 0; i < switches.Count; i++)
		{
			lR.SetPosition (i, switches [i].position);
		}


		foreach (Transform link in switches)
		{
			
			if (link.GetComponent <SpriteRenderer> ())
			{
				link.GetComponent <SpriteRenderer> ().enabled = false;

			}
		}

	}







	void Update ()
	{

		foreach (Transform link in switches)
		{
			lR.SetPosition (switches.IndexOf (link), link.position);
		}
			

	}





}
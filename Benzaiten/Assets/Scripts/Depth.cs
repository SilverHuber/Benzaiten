using UnityEngine;
using System.Collections;

public class Depth : MonoBehaviour
{
	private int sortingOrder;
	private SpriteRenderer thisSR;
	public int offset;

	// Use this for initialization
	void Start ()
	{
		sortingOrder = Mathf.RoundToInt (((transform.position.y * 0.5f) * 100) * -1) + offset;
		thisSR = GetComponent <SpriteRenderer> ();
		thisSR.sortingOrder = sortingOrder;
	
			



	}


	void Update ()
	{
		sortingOrder = Mathf.RoundToInt (((transform.position.y * 0.5f) * 100) * -1) + offset;
		thisSR.sortingOrder = sortingOrder;

	}
}





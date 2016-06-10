using UnityEngine;
using System.Collections;

public class Tail : MonoBehaviour
{

	public GameObject[] tailParts;

	void Start ()
	{
		foreach (GameObject tail in tailParts)
		{
			Debug.Log ("aan");
			tail.GetComponent <SpriteRenderer> ().enabled = true;
		}
	}

	public void DisableSpriteRenderer ()
	{
		foreach (GameObject tail in tailParts)
		{
			Debug.Log ("uit");
			tail.GetComponent <SpriteRenderer> ().enabled = false;
		}
	}


	public void EnableSpriteRenderer ()
	{
		foreach (GameObject tail in tailParts)
		{
			Debug.Log ("aan");
			tail.GetComponent <SpriteRenderer> ().enabled = true;
		}
	}
}

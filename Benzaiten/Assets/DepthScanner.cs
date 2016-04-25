using UnityEngine;
using System.Collections;

public class DepthScanner : MonoBehaviour
{
	public int sortingOrder;
	private SpriteRenderer thisSR;


	private void Start ()
	{
		thisSR = GetComponent <SpriteRenderer> ();
	}

	void LateUpdate ()
	{
		sortingOrder = Mathf.RoundToInt ((transform.position.y * 0.5f) * 100) * -1;
		thisSR.sortingOrder = sortingOrder;
	

		foreach (Transform child in transform)
		{
			if (child.GetComponent <SpriteRenderer> () != null)
			{
				child.GetComponent <SpriteRenderer> ().sortingOrder = sortingOrder;
			}


			foreach (Transform grandChild in child.transform)
			{
				if (grandChild.GetComponent <SpriteRenderer> () != null)
				{
					grandChild.GetComponent <SpriteRenderer> ().sortingOrder = sortingOrder;
				}


				foreach (Transform greatGrandChild in grandChild.transform)
				{
					greatGrandChild.GetComponent <SpriteRenderer> ().sortingOrder = sortingOrder;
				}

			}
		}
	}
		
}

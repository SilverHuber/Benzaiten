using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class textLerp : MonoBehaviour
{
	public int index = 0;
	public List<GameObject> signs = new List<GameObject> ();
	// Use this for initialization

	void Start ()
	{
		

		foreach (Transform child in transform)
		{
			signs.Add (child.gameObject);
		}	

		StartCoroutine (LerpSigns ());

		//foreach(GameObject)
	}
	
	// Update is called once per frame
	void Update ()
	{


	}


	IEnumerator LerpSigns ()
	{
		if (index < signs.Count)
		{
			signs [index].SetActive (true);
			index++;
			Debug.Log (index);
			yield return new WaitForSeconds (0.1f);
			Debug.Log ("next loop");
		
			if (index == signs.Count)
			{
				gameObject.transform.parent.gameObject.GetComponent <Animator> ().SetBool ("Talking", false);


			}
			StartCoroutine (LerpSigns ());
		}
	}
}

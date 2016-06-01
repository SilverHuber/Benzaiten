using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Temple : MonoBehaviour
{

	private RestoreObject thisRO;

	public List<SpriteRenderer> itemsToFadeAway = new List<SpriteRenderer> ();
	public List<SpriteRenderer> itemsToFadeIn = new List<SpriteRenderer> ();
	public List<GameObject> ObjectsToDeactivate = new List<GameObject> ();
	public List<GameObject> ObjectsToActivate = new List<GameObject> ();

	bool _changedMusic = false;



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
			//print ("leaves");
			foreach (SpriteRenderer sR in itemsToFadeAway)
			{
				Color color = sR.color;
				color.a -= 0.03f;
				sR.color = color;
			}
			if (!_changedMusic) {
				Invoke ("ChangeMusicState", 3.0f);
				_changedMusic = true;
			}
			//print ("leaves");
			foreach (SpriteRenderer sR in itemsToFadeIn)
			{
				Color color = sR.color;
				color.a += 0.03f;
				sR.color = color;
			}

			foreach (GameObject Obj in ObjectsToDeactivate)
			{
				Obj.SetActive (false);
			}

			foreach (GameObject Obj in ObjectsToActivate)
			{
				Obj.SetActive (true);
			}
		}

	
	}

	void ChangeMusicState ()
	{
	
		MainSoundScript.Instance.SetMusicState ("Temple_Main", false, 2);
		MainSoundScript.Instance.currentAmbientMain = "Temple_Main";
	
	}
}

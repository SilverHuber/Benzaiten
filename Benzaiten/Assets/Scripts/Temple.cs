using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Temple : MonoBehaviour
{

	private RestoreObject thisRO;
	private TextSender thisTS;
	private bool textHasBeenSent;
	public List<SpriteRenderer> itemsToFadeAway = new List<SpriteRenderer> ();
	public List<SpriteRenderer> itemsToFadeIn = new List<SpriteRenderer> ();
	public List<GameObject> ObjectsToDeactivate = new List<GameObject> ();
	public List<GameObject> ObjectsToActivate = new List<GameObject> ();
	private NPCBehave femArch;
	bool _changedMusic = false;
	private MyText textTypeScript;
	private GameObject player;
	// Use this for initialization
	void Start ()
	{
		textTypeScript = GameObject.FindGameObjectWithTag ("Text").GetComponent <MyText> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		textHasBeenSent = false;
		thisRO = GetComponent <RestoreObject> ();
		thisTS = GetComponent <TextSender> ();
		foreach (Transform child in transform)
		{
			itemsToFadeAway.Add (child.GetComponent <SpriteRenderer> ());

		}

		femArch = GameObject.Find ("FemaleArch").GetComponent <NPCBehave> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
		if (thisRO.blessed == true)
		{
			player.GetComponent <Ghost> ().currentColor = player.GetComponent <Ghost> ().halfRestoredColor;
			//print ("leaves");
			foreach (SpriteRenderer sR in itemsToFadeAway)
			{
				Color color = sR.color;
				color.a -= 0.03f;
				sR.color = color;
			}
			if (!_changedMusic)
			{
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

			if (textHasBeenSent == false)
			{
				femArch.GetComponent <Animator> ().SetTrigger ("Surprised");
				thisTS.sendText = true;
				textHasBeenSent = true;
				StartCoroutine (DisableThis ());

			}

		}



	
	}

	void ChangeMusicState ()
	{
	
		MainSoundScript.Instance.SetMusicState ("Temple_Main", false, 2);
		MainSoundScript.Instance.currentAmbientMain = "Temple_Main";
	
	}

	IEnumerator DisableThis ()
	{
		yield return new WaitForSeconds (7);
		textTypeScript.TypeLine ("It seems that the more the humans of this world believe in me, the more I become part of it.", "Benzaiten");
		this.enabled = false;
	}


}
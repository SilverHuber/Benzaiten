using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FluteMode : MonoBehaviour
{
	
	public bool flutemode = false;
	public GameObject interactiveObject;

	private int currentSequenceNote;
	private float timeSinceLastNote;

	// de sequence die door de speler word ingetypt
	public List<string> currentSequence = new List <string> ();

	// de sequences die corresponderen met een effect
	public List<string> healingSequence = new List<string> ();
	public List<string> restoreSequence = new List<string> ();
	public List<string> shortSequence = new List<string> ();

	// voor het gemak even variabelen van gemaakt
	private string a = "A";
	private string b = "B";
	private string c = "C";
	private string d = "D";
	private string e = "E";

	private void Start ()
	{
		currentSequenceNote = 0;

		healingSequence.InsertRange (healingSequence.Count, new string[] { a, b, c, d, e });
		restoreSequence.InsertRange (restoreSequence.Count, new string[] { a, a, b, a, a });
	}
	
	// Update is called once per frame
	private void Update ()
	{
		
		if (Input.GetKeyDown (KeyCode.Q) && flutemode == false)
		{
			flutemode = true;
			currentSequenceNote = 0;
			currentSequence.Clear ();

			// ANIM: grab flute
		} else if ((Input.GetKeyDown (KeyCode.Q) && flutemode == true))
		{
			flutemode = false;
			// ANIM: deposit flute
		}


		if (flutemode)
		{
			timeSinceLastNote += Time.deltaTime;

			if (Input.GetKeyDown (KeyCode.Alpha1) && currentSequenceNote < 5)
			{
				//SOUND: play Note A
				MainSoundScript.Instance.PlaySFX("Shaku_D");

				// ANIM: play flute
				currentSequence.Add (a);
				currentSequenceNote++;
				timeSinceLastNote = 0;
			}

			if (Input.GetKeyDown (KeyCode.Alpha2) && currentSequenceNote < 5)
			{
				//SOUND: play Note B
				MainSoundScript.Instance.PlaySFX("Shaku_F");

				// ANIM: play flute
				currentSequence.Add (b);
				currentSequenceNote++;
				timeSinceLastNote = 0;
			}

			if (Input.GetKeyDown (KeyCode.Alpha3) && currentSequenceNote < 5)
			{
				//SOUND: play Note C
				MainSoundScript.Instance.PlaySFX("Shaku_G");

				// ANIM: play flute
				currentSequence.Add (c);
				currentSequenceNote++;
				timeSinceLastNote = 0;
			}
			if (Input.GetKeyDown (KeyCode.Alpha4) && currentSequenceNote < 5)
			{
				//SOUND: play Note D
				MainSoundScript.Instance.PlaySFX("Shaku_A");

				// ANIM: play flute
				currentSequence.Add (d);
				currentSequenceNote++;
				timeSinceLastNote = 0;
			}

			if (Input.GetKeyDown (KeyCode.Alpha5) && currentSequenceNote < 5)
			{
				//SOUND: play Note E
				MainSoundScript.Instance.PlaySFX("Shaku_C");

				// ANIM: play flute
				currentSequence.Add (e);
				currentSequenceNote++;
				timeSinceLastNote = 0;
			}











		
			print ("check");

			if (IsListEqual (currentSequence, healingSequence))
			{
<<<<<<< HEAD
				// SOUND : Play healing sequence
				// ANIM: play sequence animation
				print ("equal to healing");
=======
				print ("check");

				if (IsListEqual (currentSequence, healingSequence))
				{
					// SOUND : Play healing sequence
					//PLACEHOLDER
					MainSoundScript.Instance.SetMusicState("RainSong", true, 3);
					MainSoundScript.Instance.PlaySFX("SFX_Correct");


					// ANIM: play sequence animation
					print ("equal to healing");
					flutemode = false;
				}

				if (IsListEqual (currentSequence, restoreSequence))
				{
					// SOUND : Play restore sequence
					// ANIM: play sequence animation
					print ("equal to restore");
					flutemode = false;

				}

				if (IsListEqual (currentSequence, shortSequence))
				{
					// SOUND : Play short sequence
					// ANIM: play sequence animation
					print ("equal to short");
					flutemode = false;

				}
>>>>>>> 9b3508457076731195c8f5f91bd430644cd1bc0f
			
			}

			if (IsListEqual (currentSequence, restoreSequence))
			{
				// SOUND : Play restore sequence
				// ANIM: play sequence animation
				print ("equal to restore");
				interactiveObject.GetComponent <RestoreObject> ().blessed = true;
				flutemode = false;
				currentSequence.Clear ();
			}

			if (IsListEqual (currentSequence, shortSequence))
			{
				// SOUND : Play short sequence
				// ANIM: play sequence animation
				print ("equal to short");
			}
			

		}

	}






	private bool IsListEqual<T> (List<T> x, List<T> y)
	{
		// Als de count niet even lang is zijn ze sowieso niet equal
		if (x.Count != y.Count)
		{
			flutemode = false;
			return false;
		}

		for (int i = 0; i < x.Count; i++)
		{
			if (!x [i].Equals (y [i]))
			{
				flutemode = false;
				return false;

			}
		}
		// Als we hier uitkomen weten we dat de lists hetzelfde zijn
		return true;
	}


}

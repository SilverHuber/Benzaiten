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

	//Restoration Song
	[Header("Songs")]
	[Tooltip("Restoration Song")]
	public List<string> restoreSequence = new List<string> ();
	[Tooltip("Healing Song")]
	public List<string> healingSequence = new List<string> ();
	[Tooltip("Build Song")]
	public List<string> buildSequence = new List<string> ();
	[Tooltip("Test Song")]
	public List<string> testSequence = new List<string> ();

	// voor het gemak even variabelen van gemaakt
	private string a = "A";
	private string b = "B";
	private string c = "C";
	private string d = "D";
	private string e = "E";

	private bool SeqCorrect = false;

	private void Start ()
	{
		currentSequenceNote = 0;

		//healingSequence.InsertRange (healingSequence.Count, new string[] { b, a, d });
		//restoreSequence.InsertRange (restoreSequence.Count, new string[] { d, e, c });
		//buildSequence.InsertRange (buildSequence.Count, new string[] { b, a, d , d, e, c });
	}
	
	// Update is called once per frame
	private void Update ()
	{
		
		if (Input.GetKeyDown (KeyCode.Q) && flutemode == false)
		{
			flutemode = true;
			currentSequenceNote = 0;
			currentSequence.Clear ();
			SeqCorrect = false;
			timeSinceLastNote = 0;

			MainSoundScript.Instance.PlaySFX ("SFX_FluteMode");

			// ANIM: grab flute
		} else if ((Input.GetKeyDown (KeyCode.Q) && flutemode == true))
		{
			flutemode = false;
			// ANIM: deposit flute
		}


		if (flutemode)
		{
			timeSinceLastNote += Time.deltaTime;

			if (Input.GetKeyDown (KeyCode.Alpha1) && currentSequenceNote < 6)
			{
				//SOUND: play Note A
				print ("check");
				MainSoundScript.Instance.PlaySFX("Shaku_D");

				// ANIM: play flute
				currentSequence.Add (a);
				currentSequenceNote++;
				timeSinceLastNote = 0;
			}

			if (Input.GetKeyDown (KeyCode.Alpha2) && currentSequenceNote < 6)
			{
				//SOUND: play Note B
				MainSoundScript.Instance.PlaySFX("Shaku_F");

				// ANIM: play flute
				currentSequence.Add (b);
				currentSequenceNote++;
				timeSinceLastNote = 0;
			}

			if (Input.GetKeyDown (KeyCode.Alpha3) && currentSequenceNote < 6)
			{
				//SOUND: play Note C
				MainSoundScript.Instance.PlaySFX("Shaku_G");

				// ANIM: play flute
				currentSequence.Add (c);
				currentSequenceNote++;
				timeSinceLastNote = 0;
			}
			if (Input.GetKeyDown (KeyCode.Alpha4) && currentSequenceNote < 6)
			{
				//SOUND: play Note D
				MainSoundScript.Instance.PlaySFX("Shaku_A");

				// ANIM: play flute
				currentSequence.Add (d);
				currentSequenceNote++;
				timeSinceLastNote = 0;
			}

			if (Input.GetKeyDown (KeyCode.Alpha5) && currentSequenceNote < 6)
			{
				//SOUND: play Note E
				MainSoundScript.Instance.PlaySFX("Shaku_C");

				// ANIM: play flute
				currentSequence.Add (e);
				currentSequenceNote++;
				timeSinceLastNote = 0;
			}






	

			if (timeSinceLastNote > 1.5f && currentSequenceNote >= 2 )
			{

				// SOUND : Play healing sequence
				// ANIM: play sequence animation

				print ("check");

				if (IsListEqual (currentSequence, healingSequence))
				{
					// SOUND : Play healing sequence
					MainSoundScript.Instance.SetMusicState("HealingSong", true, 3);
					MainSoundScript.Instance.PlaySFX("SFX_Correct");


					// ANIM: play sequence animation
					print ("equal to healing song");
					SeqCorrect = true;
					flutemode = false;
				}

				if (IsListEqual (currentSequence, restoreSequence))
				{
					// SOUND : Play restore sequence
					MainSoundScript.Instance.SetMusicState("RestorationSong", true, 3);
					MainSoundScript.Instance.PlaySFX("SFX_Correct");

					// ANIM: play sequence animation
					print ("equal to restoration song");
					SeqCorrect = true;
					flutemode = false;

				}

				if (IsListEqual (currentSequence, buildSequence))
				{
					// SOUND : Play restore sequence
					MainSoundScript.Instance.PlaySFX("SFX_Correct");

					//Placeholder
					MainSoundScript.Instance.SetMusicState("RainSong", true, 3);
					// ANIM: play sequence animation
					print ("equal to build song // still a placeholder ");
					SeqCorrect = true;
					flutemode = false;

				}

				if (IsListEqual (currentSequence, testSequence))
				{
					// SOUND : Play short sequence

					MainSoundScript.Instance.PlaySFX("SFX_Correct");

					// ANIM: play sequence animation
					print ("equal to test");
					SeqCorrect = true;
					flutemode = false;

				}

				if ((timeSinceLastNote > 1.5f && currentSequenceNote >= 6 && SeqCorrect == false) || timeSinceLastNote > 4.0f ) {
				flutemode = false;
					print ("sequence is wrong or waited to long");
					MainSoundScript.Instance.PlaySFX("SFX_NotCorrect");

				}


			
			}
			if (timeSinceLastNote > 5.0f) {
				flutemode = false;
				print ("sequence is wrong or waited too long");
				MainSoundScript.Instance.PlaySFX ("SFX_NotCorrect");
			}



//			if (IsListEqual (currentSequence, restoreSequence))
//			{
//				// SOUND : Play restore sequence
//				// ANIM: play sequence animation
//				print ("equal to restore");
//				interactiveObject.GetComponent <RestoreObject> ().blessed = true;
//				flutemode = false;
//				currentSequence.Clear ();
//			}
//
//			if (IsListEqual (currentSequence, shortSequence))
//			{
//				// SOUND : Play short sequence
//				// ANIM: play sequence animation
//				print ("equal to short");
//			}
			

		}

	}






	private bool IsListEqual<T> (List<T> x, List<T> y)
	{
		// Als de count niet even lang is zijn ze sowieso niet equal
		if (x.Count != y.Count)
		{
			
			return false;
		}

		for (int i = 0; i < x.Count; i++)
		{
			if (!x [i].Equals (y [i]))
			{
				
				return false;

			}
		}
		// Als we hier uitkomen weten we dat de lists hetzelfde zijn
		return true;
	}


}

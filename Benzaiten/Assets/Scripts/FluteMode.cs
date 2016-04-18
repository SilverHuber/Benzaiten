using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FluteMode : MonoBehaviour
{
	
	public bool flutemode = false;


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

		healingSequence.InsertRange (healingSequence.Count, new string[] { a, a, a, a, a });
		restoreSequence.InsertRange (restoreSequence.Count, new string[] { a, a, b, a, a });
	}
	
	// Update is called once per frame
	private void Update ()
	{
		
		if (Input.GetKeyDown (KeyCode.Q) && flutemode == false)
		{
			flutemode = true;
			// ANIM: grab flute
		} else if ((Input.GetKeyDown (KeyCode.Q) && flutemode == true))
		{
			flutemode = false;
			currentSequenceNote = 0;
			currentSequence.Clear ();
			// ANIM: deposit flute
		}


		if (flutemode)
		{
			timeSinceLastNote += Time.deltaTime;

			if (Input.GetKeyDown (KeyCode.Alpha1) && currentSequenceNote < 5)
			{
				//SOUND: play Note A
				// ANIM: play flute
				currentSequence.Add (a);
				currentSequenceNote++;
				timeSinceLastNote = 0;
			}

			if (Input.GetKeyDown (KeyCode.Alpha2) && currentSequenceNote < 5)
			{
				//SOUND: play Note B
				// ANIM: play flute
				currentSequence.Add (b);
				currentSequenceNote++;
				timeSinceLastNote = 0;
			}

			if (Input.GetKeyDown (KeyCode.Alpha3) && currentSequenceNote < 5)
			{
				//SOUND: play Note C
				// ANIM: play flute
				currentSequence.Add (c);
				currentSequenceNote++;
				timeSinceLastNote = 0;
			}
			if (Input.GetKeyDown (KeyCode.Alpha4) && currentSequenceNote < 5)
			{
				//SOUND: play Note D
				// ANIM: play flute
				currentSequence.Add (d);
				currentSequenceNote++;
				timeSinceLastNote = 0;
			}

			if (Input.GetKeyDown (KeyCode.Alpha5) && currentSequenceNote < 5)
			{
				//SOUND: play Note E
				// ANIM: play flute
				currentSequence.Add (e);
				currentSequenceNote++;
				timeSinceLastNote = 0;
			}











			if (timeSinceLastNote > 4 || currentSequenceNote == 5)
			{
				print ("check");

				if (IsListEqual (currentSequence, healingSequence))
				{
					// SOUND : Play healing sequence
					// ANIM: play sequence animation
					print ("equal to healing");
				}

				if (IsListEqual (currentSequence, restoreSequence))
				{
					// SOUND : Play restore sequence
					// ANIM: play sequence animation
					print ("equal to restore");
				}

				if (IsListEqual (currentSequence, shortSequence))
				{
					// SOUND : Play short sequence
					// ANIM: play sequence animation
					print ("equal to short");
				}
			
			}
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

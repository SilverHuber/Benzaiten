using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FluteMode : MonoBehaviour
{
	private Animator thisAnimator;
	public bool flutemode = false;
	public List <GameObject> interactiveObjects;
	public ButtonMovement thisButtonMovement;

	private int currentSequenceNote;
	private float timeSinceLastNote;

	public List <SpriteRenderer> NoteSymbols = new List<SpriteRenderer> ();
	public List<Sprite> playedNotes = new List<Sprite> ();
	public List<Sprite> succesNotes = new List<Sprite> ();
	public List<Sprite> failedNotes = new List<Sprite> ();
	private Color visible = new Color (1, 1, 1, 1);


	public bool Arduino1pressed;
	public bool Arduino2pressed;
	public bool Arduino3pressed;
	public bool Arduino4pressed;

	// de sequence die door de speler word ingetypt
	public List<string> currentSequence = new List <string> ();

	// de sequences die corresponderen met een effect

	//Restoration Song
	[Header ("Songs")]
	[Tooltip ("Restoration Song")]
	public List<string> restoreSequence = new List<string> ();
	[Tooltip ("Healing Song")]
	public List<string> healingSequence = new List<string> ();
	[Tooltip ("Build Song")]
	public List<string> buildSequence = new List<string> ();
	[Tooltip ("Test Song")]
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
		thisAnimator = GetComponent <Animator> ();
		thisButtonMovement = GetComponent <ButtonMovement> ();

		currentSequenceNote = 0;
		Arduino1pressed = false;
		Arduino2pressed = false;
		Arduino3pressed = false;
		Arduino4pressed = false;

		playedNotes.AddRange (Resources.LoadAll<Sprite> ("Symbols/Played/"));
		succesNotes.AddRange (Resources.LoadAll<Sprite> ("Symbols/Succes/"));
		failedNotes.AddRange (Resources.LoadAll<Sprite> ("Symbols/Fail/"));


		foreach (Transform child in transform)
		{
			if (child.name == "Symbols")
			{
				foreach (Transform symbol in child.transform)
				{
					NoteSymbols.Add (symbol.GetComponent <SpriteRenderer> ());
					symbol.GetComponent <SpriteRenderer> ().enabled = false;
				}
			}
		}
	}
	
	// Update is called once per frame
	private void Update ()
	{
		thisButtonMovement.enabled = true;

		if (Input.GetKeyDown (KeyCode.Q) && flutemode == false)
		{
			flutemode = true;
			currentSequenceNote = 0;
			currentSequence.Clear ();
			SeqCorrect = false;
			timeSinceLastNote = 0;
			thisAnimator.SetBool ("SummonDrake", false);

			MainSoundScript.Instance.PlaySFX ("SFX_FluteMode");

			thisAnimator.SetBool ("PlayingFlute", true);
		} else if ((Input.GetKeyDown (KeyCode.Q) && flutemode == true))
		{
			flutemode = false;
			thisAnimator.SetBool ("PlayingFlute", false);
			StartCoroutine (FadeSymbols ());
		}


		if (flutemode)
		{
			thisButtonMovement.enabled = false;
			timeSinceLastNote += Time.deltaTime;

		

			if (currentSequenceNote < 5)
			{
				if (Input.GetKeyDown (KeyCode.Alpha1) || Arduino1pressed)
				{
					
					//SOUND: play Note A
					print ("check");
					MainSoundScript.Instance.PlaySFX ("Shaku_D");

					// ANIM: play flute
					NoteSymbols [currentSequenceNote].sprite = playedNotes [0];
					NoteSymbols [currentSequenceNote].enabled = true;
					NoteSymbols [currentSequenceNote].color = visible;
					currentSequence.Add (a);
					currentSequenceNote++;
					timeSinceLastNote = 0;

				}

				if (Input.GetKeyDown (KeyCode.Alpha2) || Arduino2pressed)
				{
				
					//SOUND: play Note B
					MainSoundScript.Instance.PlaySFX ("Shaku_F");
					NoteSymbols [currentSequenceNote].sprite = playedNotes [1];
					NoteSymbols [currentSequenceNote].enabled = true;
					NoteSymbols [currentSequenceNote].color = visible;

					// ANIM: play flute
					currentSequence.Add (b);
					currentSequenceNote++;
					timeSinceLastNote = 0;
				}

				if (Input.GetKeyDown (KeyCode.Alpha3))
				{
					//SOUND: play Note C
					MainSoundScript.Instance.PlaySFX ("Shaku_G");
					NoteSymbols [currentSequenceNote].sprite = playedNotes [2];
					NoteSymbols [currentSequenceNote].enabled = true;
					NoteSymbols [currentSequenceNote].color = visible;

					// ANIM: play flute
					currentSequence.Add (c);
					currentSequenceNote++;
					timeSinceLastNote = 0;
				}
				if (Input.GetKeyDown (KeyCode.Alpha4))
				{
					//SOUND: play Note D
					MainSoundScript.Instance.PlaySFX ("Shaku_A");
					NoteSymbols [currentSequenceNote].sprite = playedNotes [3];
					NoteSymbols [currentSequenceNote].enabled = true;
					NoteSymbols [currentSequenceNote].color = visible;

					// ANIM: play flute
					currentSequence.Add (d);
					currentSequenceNote++;
					timeSinceLastNote = 0;
				}

				if (Input.GetKeyDown (KeyCode.Alpha5))
				{
					//SOUND: play Note E
					MainSoundScript.Instance.PlaySFX ("Shaku_C");
					NoteSymbols [currentSequenceNote].sprite = playedNotes [4];
					NoteSymbols [currentSequenceNote].enabled = true;
					NoteSymbols [currentSequenceNote].color = visible;

					// ANIM: play flute
					currentSequence.Add (e);
					currentSequenceNote++;
					timeSinceLastNote = 0;
				}


			}






	

			if (timeSinceLastNote > 1.5f && currentSequenceNote >= 2)
			{
				

				if (IsListEqual (currentSequence, healingSequence))
				{
					// SOUND : Play healing sequence
					MainSoundScript.Instance.SetMusicState ("HealingSong", true, 3);
					MainSoundScript.Instance.PlaySFX ("SFX_Correct");

					for (int i = 0; i < currentSequence.Count; i++)
					{
						if (currentSequence [i] == "A")
							NoteSymbols [i].sprite = succesNotes [0];
						if (currentSequence [i] == "B")
							NoteSymbols [i].sprite = succesNotes [1];
						if (currentSequence [i] == "C")
							NoteSymbols [i].sprite = succesNotes [2];
						if (currentSequence [i] == "D")
							NoteSymbols [i].sprite = succesNotes [3];
						if (currentSequence [i] == "E")
							NoteSymbols [i].sprite = succesNotes [4];
					}
					StartCoroutine (FadeSymbols ());
					thisAnimator.SetBool ("SummonDrake", true);

					// ANIM: play sequence animation
					print ("equal to healing song");
					SeqCorrect = true;
					flutemode = false;
				}

				if (IsListEqual (currentSequence, restoreSequence))
				{
					// SOUND : Play restore sequence
					MainSoundScript.Instance.SetMusicState ("RestorationSong", true, 3);
					MainSoundScript.Instance.PlaySFX ("SFX_Correct");
					thisAnimator.SetBool ("SummonDrake", true);

					// ANIM: play sequence animation
					print ("equal to restoration song");
					SeqCorrect = true;
					flutemode = false;


					foreach (GameObject restoreObject in interactiveObjects)
					{
						restoreObject.GetComponent <RestoreObject> ().blessed = true;
					}

					for (int i = 0; i < currentSequence.Count; i++)
					{
						if (currentSequence [i] == "A")
							NoteSymbols [i].sprite = succesNotes [0];
						if (currentSequence [i] == "B")
							NoteSymbols [i].sprite = succesNotes [1];
						if (currentSequence [i] == "C")
							NoteSymbols [i].sprite = succesNotes [2];
						if (currentSequence [i] == "D")
							NoteSymbols [i].sprite = succesNotes [3];
						if (currentSequence [i] == "E")
							NoteSymbols [i].sprite = succesNotes [4];
					}
					StartCoroutine (FadeSymbols ());

				}

				if (IsListEqual (currentSequence, buildSequence))
				{
					// SOUND : Play restore sequence
					MainSoundScript.Instance.PlaySFX ("SFX_Correct");
					thisAnimator.SetBool ("SummonDrake", true);

					//Placeholder
					MainSoundScript.Instance.SetMusicState ("RainSong", true, 3);
					// ANIM: play sequence animation
					print ("equal to build song // still a placeholder ");
					SeqCorrect = true;
					flutemode = false;

				}

				if (IsListEqual (currentSequence, testSequence))
				{
					// SOUND : Play short sequence

					MainSoundScript.Instance.PlaySFX ("SFX_Correct");

					// ANIM: play sequence animation
					print ("equal to test");
					SeqCorrect = true;
					flutemode = false;

				}









				if ((timeSinceLastNote > 1.5f && currentSequenceNote >= 6 && SeqCorrect == false) || timeSinceLastNote > 4.0f)
				{
					flutemode = false;
					print ("sequence is wrong or waited to long");
					MainSoundScript.Instance.PlaySFX ("SFX_NotCorrect");
					thisAnimator.SetBool ("PlayingFlute", false);
					for (int i = 0; i < currentSequence.Count; i++)
					{
						if (currentSequence [i] == "A")
							NoteSymbols [i].sprite = failedNotes [0];
						if (currentSequence [i] == "B")
							NoteSymbols [i].sprite = failedNotes [1];
						if (currentSequence [i] == "C")
							NoteSymbols [i].sprite = failedNotes [2];
						if (currentSequence [i] == "D")
							NoteSymbols [i].sprite = failedNotes [3];
						if (currentSequence [i] == "E")
							NoteSymbols [i].sprite = failedNotes [4];
					}

					StartCoroutine (FadeSymbols ());
				}


			
			}
			if (timeSinceLastNote > 5.0f)
			{
				flutemode = false;
				print ("sequence is wrong or waited too long");
				MainSoundScript.Instance.PlaySFX ("SFX_NotCorrect");
				thisAnimator.SetBool ("PlayingFlute", false);

			}

			if (flutemode == false)
			{
				thisAnimator.SetBool ("PlayingFlute", false);
				StartCoroutine (FadeSymbols ());

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


	private IEnumerator FadeSymbols ()
	{
		yield return new WaitForSeconds (0.7f);
		while (NoteSymbols [NoteSymbols.Count - 1].color.a > 0.01f)
		{
			foreach (SpriteRenderer sR in NoteSymbols)
			{
			
				Color color = sR.color;
				color.a -= 0.03f;
				sR.color = color;

		
			}
			yield return null;

		}
		foreach (SpriteRenderer sR in NoteSymbols)
		{
			sR.enabled = false;
		}

	}

}

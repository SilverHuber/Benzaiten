﻿using UnityEngine;
using System.Collections;

public class MusicStateSwitch : MonoBehaviour
{


	public string ChangeToState;

	// Use this for initialization

	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other)
	{

		if (other.name == "Player")
		{
			
			if (ChangeToState == "City")
			{
				MainSoundScript.Instance.PlaySFX ("SFX_TempleAmbience_Stop");
				MainSoundScript.Instance.PlaySFX ("SFX_CityAmbience");
				MainSoundScript.Instance.SetMusicState ("City", false, 2);
				MainSoundScript.Instance.currentAmbientMain = "City";
				print ("changed state to" + ChangeToState);
				AkSoundEngine.PostEvent("SFX_River_Stop", gameObject);

			}
			if (ChangeToState == "Temple_Main")
			{
				MainSoundScript.Instance.PlaySFX ("SFX_CityAmbience_Stop");
				MainSoundScript.Instance.PlaySFX ("SFX_TempleAmbience");
				MainSoundScript.Instance.SetMusicState ("Temple_Main", false, 2);
				MainSoundScript.Instance.currentAmbientMain = "Temple_Main";
				//MainSoundScript.Instance.PlaySFX ("SFX_WaterStream_Stop");
				print ("changed state to" + ChangeToState);


			}
			if (ChangeToState == "Temple_Inside")
			{
				MainSoundScript.Instance.PlaySFX ("SFX_TempleAmbience_Stop");
				print ("changed state to" + ChangeToState);



			}


		}

	}
}

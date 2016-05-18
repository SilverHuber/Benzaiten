﻿using UnityEngine;
using System.Collections;

public class MainSoundScript : MonoBehaviour {

	public static MainSoundScript Instance {get; set;}

	void Awake() {
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}
	}

	//parameters

	//stategroup of music
	public string musicSwitchGroup;

	[HideInInspector]
	public string currentAmbientMain = "Temple_Mystery";


	// Use this for initialization
	void Start () {

		musicSwitchGroup = "Music_switch";

		//Start Music and set Intro state
		//PlayMusic("Music");
		//SetMusicState ("Intro", true, 2);
	
	}


	//play a oneshot SFX
	public void PlaySFX(string sfxName) {
		if (sfxName != null) {
			AkSoundEngine.PostEvent (sfxName, this.gameObject);
		}
	}



	//play Certain musiccontainers
	public void PlayMusic(string musicName) {
		if (musicName != null) {
			
			AkSoundEngine.PostEvent (musicName, gameObject);
		}
	}

	//Stes used for songs and adaptive music
	public void SetMusicState(string stateName, bool toMain, int waitForSec ) {
		if (stateName != null) {

			StartCoroutine(SetMusicStateCoroutine(stateName, toMain, waitForSec));
		}
	}
		
	
	//Coroutine for States/Songs
	IEnumerator SetMusicStateCoroutine(string stateName, bool toMain, int waitForSec)
	{

		if (stateName != null) {
			
			AkSoundEngine.SetState (musicSwitchGroup, stateName);

			if (toMain) {
				if (waitForSec > 0) {
					yield return new WaitForSeconds (waitForSec);
				} else {
					yield return new WaitForSeconds (3);

				}
				AkSoundEngine.SetState (musicSwitchGroup, currentAmbientMain);
			}
		
		
		}

	}
					
}

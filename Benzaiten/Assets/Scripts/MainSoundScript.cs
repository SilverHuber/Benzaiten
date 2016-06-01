using UnityEngine;
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
	public string currentFootStepSwitchGroup;
	public bool FootStepOn = false;

	//stategroup of music
	public string musicSwitchGroup;

	[HideInInspector]
	public string currentAmbientMain;


	// Use this for initialization
	void Start () {

		musicSwitchGroup = "Music_switch";


		//Start Music and set Intro state
		//PlayMusic("Music");
		//SetMusicState ("Intro", true, 2);
	
	}

	void Update () {


	}


	//play a oneshot SFX
	public void PlaySFX(string sfxName) {
		if (sfxName != null) {
			AkSoundEngine.PostEvent (sfxName, this.gameObject);
		}
	}

	public void PlayTalkSFX(string characterName) {
		if (characterName != null) {
			if (characterName == "Kenji"){
				AkSoundEngine.PostEvent ("Talk_Kenji", this.gameObject);
			}
			if (characterName == "FemaleArch"){
				AkSoundEngine.PostEvent ("Talk_Archeologist_Female", this.gameObject);
			}
			if (characterName == "MaleArch"){
				AkSoundEngine.PostEvent ("Talk_Archeologist_Male", this.gameObject);
			}

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
			AkSoundEngine.SetState (musicSwitchGroup, stateName);
			print ("setting state to" + stateName);
			StopCoroutine ("SetMusicStateCoroutine");
			if (toMain) {
				StartCoroutine (SetMusicStateCoroutine (stateName, toMain, waitForSec));
			}
		}
	}

	public void SetFootstepSwitch(string switchName) {
		AkSoundEngine.SetSwitch("Footstep", switchName, gameObject);
		if (currentFootStepSwitchGroup != switchName) {
			AkSoundEngine.PostEvent ("Footstep_Stop", gameObject);
			FootStepOn = false;
		}
		currentFootStepSwitchGroup = switchName;
	}
		


	void SetToMain (){
		AkSoundEngine.SetState (musicSwitchGroup, currentAmbientMain);
	
	}
		
	
	//Coroutine for States/Songs
	IEnumerator SetMusicStateCoroutine(string stateName, bool toMain, int waitForSec)
	{
		//if (stateName != null) {}
				if (waitForSec > 0) {
					yield return new WaitForSeconds (waitForSec);
				} else {
					yield return new WaitForSeconds (3);
				}
		SetToMain ();
	}
		

			
}

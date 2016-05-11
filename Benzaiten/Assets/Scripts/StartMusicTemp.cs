using UnityEngine;
using System.Collections;

public class StartMusicTemp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		MainSoundScript.Instance.SetMusicState ("Main", false, 0);
		MainSoundScript.Instance.PlayMusic ("Music");
		MainSoundScript.Instance.PlaySFX ("SFX_CityAmbience");

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

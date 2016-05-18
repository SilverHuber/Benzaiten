using UnityEngine;
using System.Collections;

public class StartMusicTemp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		MainSoundScript.Instance.SetMusicState ("Temple_Mystery", false, 0);
		MainSoundScript.Instance.PlayMusic ("Music");


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

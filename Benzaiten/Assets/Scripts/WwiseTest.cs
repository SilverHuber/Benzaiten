using UnityEngine;
using System.Collections;

public class WwiseTest : MonoBehaviour {
	bool shaku_D;
	bool shaku_Eb;
	bool shaku_G;
	bool previousShaku_D = false; 
	bool previousShaku_Eb = false; 
	bool previousShaku_G = false; 

	// Use this for initialization
	void Start () {

		//Start Music and set Intro state
		AkSoundEngine.SetState ("Music_switch", "intro");
		AkSoundEngine.PostEvent ("Music", this.gameObject);
	
	}
	
	// Update is called once per frame
	void Update () {

		//Set State to Main Ambiance Loop
		if (Time.time > 1) {
			AkSoundEngine.SetState ("Music_switch", "Main");
		}
		 
		//Set State to Rain Song when user input is correct
		if (Input.GetKeyDown(KeyCode.A)) {
			StartCoroutine (RainSong());
			Debug.Log ("Im pressing A!");
		}
		//If song input is correct, play SFX_Correct
		if (Input.GetKeyDown(KeyCode.S)) {

			AkSoundEngine.PostEvent ("SFX_Correct", this.gameObject);
		} 
		//If song input is correct, play SFX_OldMan
		if (Input.GetKeyDown(KeyCode.D)) {
			AkSoundEngine.PostEvent ("SFX_OldMan", this.gameObject);
		} 
		//If song input is correct, play SFX_Rain
		if (Input.GetKeyDown(KeyCode.F)) {
			AkSoundEngine.PostEvent ("SFX_Rain", this.gameObject);
		} 
			//If song input is correct, play SFX_Shaku_D
			if (Input.GetKey (KeyCode.G)) {
				shaku_D = true;
			}
			else{
				shaku_D = false;
				AkSoundEngine.PostEvent ("Stop_D", this.gameObject);
				previousShaku_D = false;
			}
			if (shaku_D != previousShaku_D){
				AkSoundEngine.PostEvent ("SFX_Shaku_D", this.gameObject);
				previousShaku_D = shaku_D;
			}

			//If song input is correct, play SFX_Shaku_Eb
			if (Input.GetKey (KeyCode.H)) {
				shaku_Eb = true;
			}
			else{
			shaku_Eb = false;
			AkSoundEngine.PostEvent ("Stop_Eb", this.gameObject);
			previousShaku_Eb = false;
			}
		if (shaku_Eb != previousShaku_Eb){
			AkSoundEngine.PostEvent ("SFX_Shaku_Eb", this.gameObject);
			previousShaku_Eb = shaku_Eb;
			}

			//If song input is correct, play SFX_Shaku_G
			if (Input.GetKey (KeyCode.J)) {
				shaku_G = true;
			}
			else{
				shaku_G = false;
				AkSoundEngine.PostEvent ("Stop_G", this.gameObject);
				previousShaku_G = false;
			}
			if (shaku_G != previousShaku_G){
				AkSoundEngine.PostEvent ("SFX_Shaku_G", this.gameObject);
				previousShaku_G = shaku_G;
			}
		
		
		
		
		
	}
	
	//Coroutine for RainSong
	IEnumerator RainSong()
	{

			AkSoundEngine.SetState ("Music_switch", "RainSong");
			yield return new WaitForSeconds(3);
			AkSoundEngine.SetState ("Music_switch", "Main");


	}
}

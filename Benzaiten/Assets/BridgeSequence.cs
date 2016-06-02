using UnityEngine;
using System.Collections;

public class BridgeSequence : MonoBehaviour
{
	Camera mainCam;
	public Transform kenji;
	public Transform maleArch;
	public GameObject player;
	public Transform finalRoadDestination;
	private bool scenePlayed;
	private MyText textTypeScript;
	[HideInInspector]
	public bool restored;
	private bool restoreScenePlayed;


	void Start ()
	{
		player = GameObject.Find ("Player");
		textTypeScript = GameObject.FindGameObjectWithTag ("Text").GetComponent <MyText> ();
		mainCam = Camera.main;
		scenePlayed = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (restored)
		{
			if (!restoreScenePlayed)
			{
				StartCoroutine (BridgeRestoredScene ());
				restoreScenePlayed = true;
			}
		}
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (scenePlayed == false)
		{
			if (other.name == "Player")
			{
				other.GetComponent <ButtonMovement> ().enabled = false;
				other.GetComponent <FluteMode> ().enabled = false;
				other.GetComponent <BoxCollider2D> ().enabled = false;
				other.GetComponent <Animator> ().SetBool ("Walking", false);
				StartCoroutine (BridgeScene (other.gameObject));
			}
		}
	}


	IEnumerator BridgeScene (GameObject player)
	{
		scenePlayed = true;
		mainCam.GetComponent <CameraScript> ().target = kenji;
		yield return new WaitForSeconds (0.2f);
		textTypeScript.TypeLine ("Watta hell happened to dis bridge brah?", "Kenji");
		textTypeScript.TypeLine ("I dont know Kenji... Let's see if we can contact headoffice to fix this shizzz", "MaleArch");
		yield return new WaitForSeconds (12);
		kenji.GetComponent <NPCBehave> ().staticCharacter = false;
		maleArch.GetComponent <NPCBehave> ().staticCharacter = false;
		yield return new WaitForSeconds (5);
		player.GetComponent <ButtonMovement> ().enabled = true;
		player.GetComponent <FluteMode> ().enabled = true;
		player.GetComponent <BoxCollider2D> ().enabled = true;
		mainCam.GetComponent <CameraScript> ().target = player.transform;
	}


	IEnumerator BridgeRestoredScene ()
	{
		scenePlayed = true;
		player.GetComponent <ButtonMovement> ().enabled = false;
		player.GetComponent <FluteMode> ().enabled = false;
		player.GetComponent <BoxCollider2D> ().enabled = false;
		yield return new WaitForSeconds (3f);
		player.GetComponent <Animator> ().SetBool ("Walking", false);
		yield return new WaitForSeconds (0.2f);
		kenji.GetComponent <NPCBehave> ().centerOfWalkingRadius = player.transform;
		maleArch.GetComponent <NPCBehave> ().centerOfWalkingRadius = player.transform;
		maleArch.GetComponent <NPCBehave> ().walkingRadius = 0;
		maleArch.GetComponent <NPCBehave> ().walkingRadius = 0;
		yield return new WaitForSeconds (6);
		textTypeScript.TypeLine ("The Bridge... It has been restored... Lady, have you seen what happened?", "Kenji");
		textTypeScript.TypeLine ("....... (What is happening! I can't talk!)", "Benzaiten");
		textTypeScript.TypeLine ("Hmmm? Can't speak? If I can help you with anything, holler at ya boy. ", "Kenji");
		yield return new WaitForSeconds (15);
		kenji.GetComponent <NPCBehave> ().centerOfWalkingRadius = finalRoadDestination;
		maleArch.GetComponent <NPCBehave> ().centerOfWalkingRadius = finalRoadDestination;
		yield return new WaitForSeconds (3);
		player.GetComponent <ButtonMovement> ().enabled = true;
		player.GetComponent <FluteMode> ().enabled = true;
		player.GetComponent <BoxCollider2D> ().enabled = true;
		mainCam.GetComponent <CameraScript> ().target = player.transform;
	}
}

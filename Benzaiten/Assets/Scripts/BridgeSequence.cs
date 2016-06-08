using UnityEngine;
using System.Collections;

public class BridgeSequence : MonoBehaviour
{
	Camera mainCam;
	public Transform kenji;
	public Transform maleArch;
	public GameObject player;
	public Transform kenjibenzPos;
	public Transform malebenzPos;

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
		textTypeScript.TypeLine ("Wait- Wasn't there a bridge over here a few hours ago?", "MaleArch");
		textTypeScript.TypeLine ("Hmmm...Could it have been an eartquake? I didn't feel any tremors in the tectonic plates.", "Kenji");
		textTypeScript.TypeLine ("Let's contact headquarters.", "Kenji");
		yield return new WaitForSeconds (16);
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
		player.GetComponent <Ghost> ().currentColor = player.GetComponent <Ghost> ().fullyRestoredColor;
		yield return new WaitForSeconds (3f);
		player.GetComponent <Animator> ().SetBool ("Walking", false);
		yield return new WaitForSeconds (0.2f);

		kenji.GetComponent <NPCBehave> ().centerOfWalkingRadius = kenjibenzPos;
		maleArch.GetComponent <NPCBehave> ().centerOfWalkingRadius = malebenzPos;
		maleArch.GetComponent <NPCBehave> ().walkingRadius = 0;
		kenji.GetComponent <NPCBehave> ().walkingRadius = 0;
		yield return new WaitForSeconds (6);

		player.GetComponent <SpriteRenderer> ().flipX = true;
		textTypeScript.TypeLine ("The Bridge... It has been restored... Miss, have you seen what happened?", "Kenji");
		textTypeScript.TypeLine ("....... (Huh? I can't speak!)", "Benzaiten");
		textTypeScript.TypeLine ("Hmmm? Are you mute?", "Kenji");
		textTypeScript.TypeLine ("Oh I'm sorry! Well, my name is Kenji Miyamoto. Could you thank the person who fixed the bridge for us?", "Kenji");
		textTypeScript.TypeLine ("Could this be Benzaiten's doing?", "MaleArch");
		yield return new WaitForSeconds (19);
		kenji.GetComponent <NPCBehave> ().centerOfWalkingRadius = finalRoadDestination;
		maleArch.GetComponent <NPCBehave> ().centerOfWalkingRadius = finalRoadDestination;
		yield return new WaitForSeconds (3);
		textTypeScript.TypeLine ("This seems like the work of an unpure spirit.", "Benzaiten");
		player.GetComponent <SpriteRenderer> ().flipX = false;
		player.GetComponent <ButtonMovement> ().enabled = true;
		player.GetComponent <FluteMode> ().enabled = true;
		player.GetComponent <BoxCollider2D> ().enabled = true;
		mainCam.GetComponent <CameraScript> ().target = player.transform;
	}
}

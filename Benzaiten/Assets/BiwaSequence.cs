using UnityEngine;
using System.Collections;

public class BiwaSequence : MonoBehaviour
{


	Camera mainCam;
	public Transform kenji;
	public Transform kenjiStartPosition;
	public GameObject player;
	public GameObject roadblock;
	public Transform roadLocation;

	public Transform finalRoadDestination;
	private bool scenePlayed;
	private MyText textTypeScript;
	public bool restored;
	private bool restoreScenePlayed;


	void Start ()
	{
		player = GameObject.Find ("Player");
		textTypeScript = GameObject.FindGameObjectWithTag ("Text").GetComponent <MyText> ();
		mainCam = Camera.main;
		scenePlayed = false;
	}


	void OnTriggerEnter2D (Collider2D other)
	{
		if (scenePlayed == false)
		{
			if (restored)
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
		Destroy (roadblock);
		player.GetComponent <ButtonMovement> ().enabled = false;
		player.GetComponent <FluteMode> ().enabled = false;
		player.GetComponent <BoxCollider2D> ().enabled = false;
		kenji.transform.position = kenjiStartPosition.position;
		kenji.GetComponent <NPCBehave> ().centerOfWalkingRadius = finalRoadDestination;
		mainCam.GetComponent <CameraScript> ().target = kenji;
		yield return new WaitForSeconds (0.2f);
		textTypeScript.TypeLine ("Come back you thief! That is Benzaiten's Biwa!", "Kenji");
		yield return new WaitForSeconds (2f);
		kenji.GetComponent <NPCBehave> ().speed = 3f;
		kenji.GetComponent <NPCBehave> ().centerOfWalkingRadius = finalRoadDestination;
		kenji.GetComponent <NPCBehave> ().staticCharacter = false;
		yield return new WaitForSeconds (2);
		mainCam.GetComponent <CameraScript> ().target = player.transform;
		textTypeScript.TypeLine ("Did Kenji have my Biwa all along? Doesn't matter, I should help him!", "Benzaiten");
		kenji.transform.position = roadLocation.position;
		kenji.GetComponent <NPCBehave> ().staticCharacter = true;
		yield return new WaitForSeconds (3);
		player.GetComponent <ButtonMovement> ().enabled = true;
		player.GetComponent <FluteMode> ().enabled = true;
		player.GetComponent <BoxCollider2D> ().enabled = true;
		mainCam.GetComponent <CameraScript> ().target = player.transform;




	}



}


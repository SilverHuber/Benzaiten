using UnityEngine;
using System.Collections;

public class SpinnenSequence : MonoBehaviour
{

	Camera mainCam;
	public Transform kenji;
	public Transform yinmei;
	public Transform yinmeiCam;
	public Transform yinmeiEndPos;
	public GameObject player;

	public Transform finalRoadDestination;
	private bool scenePlayed;
	private MyText textTypeScript;



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
			
			if (other.name == "Player")
			{
				other.GetComponent <ButtonMovement> ().enabled = false;
				MainSoundScript.Instance.PlaySFX ("Footstep_Stop");

				other.GetComponent <FluteMode> ().enabled = false;
				other.GetComponent <BoxCollider2D> ().enabled = false;
				other.GetComponent <Animator> ().SetBool ("Walking", false);
				StartCoroutine (BridgeScene (other.gameObject));
			}
		}
	}


	IEnumerator BridgeScene (GameObject player)
	{
		
		MainSoundScript.Instance.SetMusicState ("Yanmei", false, 0);
		scenePlayed = true;
		kenji.GetComponent <SpriteRenderer> ().flipX = false;
		player.GetComponent <ButtonMovement> ().enabled = false;

		player.GetComponent <FluteMode> ().enabled = false;
		player.GetComponent <BoxCollider2D> ().enabled = false;
		mainCam.GetComponent <CameraScript> ().target = yinmeiCam;
		yield return new WaitForSeconds (3f);
		kenji.GetComponent <SpriteRenderer> ().flipX = false;

		yinmei.GetComponent <Animator> ().SetBool ("Beckon", true);
		player.GetComponent <ButtonMovement> ().enabled = false;
		player.GetComponent <Animator> ().SetBool ("Walking", false);
		textTypeScript.TypeLine ("Hear my voice and fall into my arms, Kenji Miyamoto", "Yinmei");
		textTypeScript.TypeLine ("Hnng-", "Kenji");
		textTypeScript.TypeLine ("Come to me and I will play the Biwa for you.", "Yinmei");
		textTypeScript.TypeLine ("Yes, my mistress...", "Kenji");
		yield return new WaitForSeconds (12f);
		kenji.GetComponent <NPCBehave> ().walkingRadius = 0;
		kenji.GetComponent <NPCBehave> ().centerOfWalkingRadius = yinmeiEndPos;
		kenji.GetComponent <NPCBehave> ().speed = 2;
		yinmei.GetComponent <NPCBehave> ().speed = 2.5f;
		kenji.GetComponent <NPCBehave> ().staticCharacter = false;
		kenji.GetComponent <Animator> ().speed = 1f;
		kenji.GetComponent <Animator> ().SetBool ("Seduced", true);
		yield return new WaitForSeconds (2);
		mainCam.GetComponent <CameraScript> ().target = kenji;
		yield return new WaitForSeconds (7);
		yinmei.GetComponent <NPCBehave> ().centerOfWalkingRadius = yinmeiEndPos;
		yinmei.GetComponent <NPCBehave> ().staticCharacter = false;
		yield return new WaitForSeconds (7);
		player.GetComponent <ButtonMovement> ().enabled = true;
		player.GetComponent <FluteMode> ().enabled = true;
		player.GetComponent <BoxCollider2D> ().enabled = true;
		mainCam.GetComponent <CameraScript> ().target = player.transform;
		Destroy (yinmei.gameObject);
		MainSoundScript.Instance.SetMusicState ("City", false, 0);




	}



}

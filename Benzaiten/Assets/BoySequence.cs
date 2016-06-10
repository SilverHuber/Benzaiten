using UnityEngine;
using System.Collections;

public class BoySequence : MonoBehaviour
{

	private RestoreObject thisRO;
	private bool coroutineStarted;
	private Animator thisAnimator;
	public Animator catAnimator;
	private MyText textTypeScript;
	public BiwaSequence bridgeseq;
	private GameObject player;
	private bool saidEncounterText;
	public Sound_Boy boySoundScript;

	void Start ()
	{
		saidEncounterText = false;
		thisAnimator = GetComponent <Animator> ();
		coroutineStarted = false;
		thisRO = GetComponent <RestoreObject> ();
		catAnimator = GameObject.Find ("Cat").GetComponent <Animator> ();
		textTypeScript = GameObject.FindGameObjectWithTag ("Text").GetComponent <MyText> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		boySoundScript = gameObject.GetComponent<Sound_Boy> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (thisRO.blessed == true && coroutineStarted == false)
		{
			StartCoroutine (BoyPlay ());
			coroutineStarted = true;
			bridgeseq.restored = true;
		}



	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name == "Player" && saidEncounterText == false)
		{
			StartCoroutine (BoyEncounter ());
			MainSoundScript.Instance.PlaySFX ("Footstep_Stop");
			saidEncounterText = true;
		}
	}



	IEnumerator BoyEncounter ()
	{
		
		player.GetComponent <ButtonMovement> ().enabled = false;
		player.GetComponent <FluteMode> ().enabled = false;
		player.GetComponent <BoxCollider2D> ().enabled = false;
		player.GetComponent <Animator> ().SetBool ("Walking", false);
		textTypeScript.TypeLine ("Oh poor Toma, I wish I could help you!", "Boy");
		textTypeScript.TypeLine ("Oh miss- My poor cat is dying!", "Boy");
		textTypeScript.TypeLine ("My grandma told me to play this melody whenever someone is ill. But it's not working... I must be doing something wrong", "Boy");
		yield return new WaitForSeconds (13);
		player.GetComponent <ButtonMovement> ().enabled = true;
		player.GetComponent <FluteMode> ().enabled = true;
		player.GetComponent <BoxCollider2D> ().enabled = true;

	}

	IEnumerator BoyPlay ()
	{
		thisAnimator.SetBool ("Restored", true);
		catAnimator.SetBool ("Restored", true);
		player.GetComponent <ButtonMovement> ().enabled = false;
		player.GetComponent <FluteMode> ().enabled = false;
		player.GetComponent <BoxCollider2D> ().enabled = false;
		yield return new WaitForSeconds (2);
		textTypeScript.TypeLine ("Woah! How did you do that? You must be Benzaiten; the goddess my grandma told me so many stories about!", "Boy");
		textTypeScript.TypeLine ("Thank you so much!", "Boy");
		textTypeScript.TypeLine ("Miauw!", "Toma");
		boySoundScript.helpedBoy = true;
		yield return new WaitForSeconds (10);
		player.GetComponent <ButtonMovement> ().enabled = true;
		player.GetComponent <FluteMode> ().enabled = true;
		player.GetComponent <BoxCollider2D> ().enabled = true;

	}



}

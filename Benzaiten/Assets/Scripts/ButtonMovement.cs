using UnityEngine;
using System.Collections;

public class ButtonMovement : MonoBehaviour
{
	public float speed;
	private Animator thisAnimator;
	private SpriteRenderer thisSpriteRenderer;
	bool footStepOn = false;

	// hallo

	private void Start ()
	{
		thisAnimator = this.gameObject.GetComponent <Animator> ();
		thisSpriteRenderer = this.gameObject.GetComponent <SpriteRenderer> ();
		speed = 4f;
	}

	void Update (){
		
	//sound footsteps
		if (Input.GetKey (KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) {
			//print ("input");
			if (MainSoundScript.Instance.FootStepOn == false) {
				print ("footsteps are on");
				MainSoundScript.Instance.PlaySFX ("Footstep_Start");
				MainSoundScript.Instance.FootStepOn = true;
			}
		} else 
		{
			//print ("NOinput");
			if (MainSoundScript.Instance.FootStepOn == true) {
				MainSoundScript.Instance.PlaySFX ("Footstep_Stop");
				MainSoundScript.Instance.FootStepOn = false;
				print ("footsteps are off");
			}


		}
	
	}

	private void FixedUpdate ()
	{
		if (Input.anyKey)
		{
    
			if (Input.GetKey (KeyCode.D))
			{
				transform.position += Vector3.right * speed * Time.deltaTime;
				thisAnimator.SetBool ("Walking", true);
				thisSpriteRenderer.flipX = true;

			}


			if (Input.GetKey (KeyCode.A))
			{
				transform.position += Vector3.left * speed * Time.deltaTime;
				thisAnimator.SetBool ("Walking", true);
				thisSpriteRenderer.flipX = false;
			}

			if (Input.GetKey (KeyCode.S))
			{
				transform.position += Vector3.down * speed * Time.deltaTime;
				thisAnimator.SetBool ("Walking", true);
			}

			if (Input.GetKey (KeyCode.W))
			{
				transform.position += Vector3.up * speed * Time.deltaTime;
				thisAnimator.SetBool ("Walking", true);
			}


				

		} else
		{
			thisAnimator.SetBool ("Walking", false);
		}
	}

}

	


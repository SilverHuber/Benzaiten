using UnityEngine;
using System.Collections;

public class ButtonMovement : MonoBehaviour
{
	public float speed;
	private Animator thisAnimator;
	private SpriteRenderer thisSpriteRenderer;
	bool footStepOn = false;
	private FluteMode thisFluteScript;
	private Arduino thisArduinoScript;
	// hallo

	private void Start ()
	{
		thisFluteScript = this.GetComponent<FluteMode> ();
		thisArduinoScript = this.GetComponent<Arduino> ();
		thisAnimator = this.gameObject.GetComponent <Animator> ();
		thisSpriteRenderer = this.gameObject.GetComponent <SpriteRenderer> ();
		speed = 4f;
	}

	void Update ()
	{
		
		//sound footsteps
		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.D) || thisArduinoScript.arduinoButtonCheck)
		{
			thisAnimator.SetBool ("Walking", true);
			
			//print ("input");
			if (MainSoundScript.Instance.FootStepOn == false)
			{
				print ("footsteps are on");
				MainSoundScript.Instance.PlaySFX ("Footstep_Start");
				MainSoundScript.Instance.FootStepOn = true;
			}
		} else
		{
			thisAnimator.SetBool ("Walking", false);

			//print ("NOinput");
			if (MainSoundScript.Instance.FootStepOn == true)
			{
				MainSoundScript.Instance.PlaySFX ("Footstep_Stop");
				MainSoundScript.Instance.FootStepOn = false;
				print ("footsteps are off");
			}


		}
	
	}

	private void FixedUpdate ()
	{
//		if (Input.anyKey || thisArduinoScript.arduinoButtonCheck)
//		{
    
		if (Input.GetKey (KeyCode.D) || thisFluteScript.Arduino7pressed)
		{
			transform.position += Vector3.right * speed * Time.deltaTime;
			thisSpriteRenderer.flipX = true;

		}


		if (Input.GetKey (KeyCode.A) || thisFluteScript.Arduino8pressed)
		{
			transform.position += Vector3.left * speed * Time.deltaTime;
			thisSpriteRenderer.flipX = false;
		}

		if (Input.GetKey (KeyCode.S) || thisFluteScript.Arduino6pressed)
		{
			transform.position += Vector3.down * speed * Time.deltaTime;
		}

		if (Input.GetKey (KeyCode.W) || thisFluteScript.Arduino9pressed)
		{
			transform.position += Vector3.up * speed * Time.deltaTime;
		}

		if (Input.GetKeyDown (KeyCode.Escape))
		{
			Application.Quit ();
		}


				
//
//		} else
//		{
//			thisAnimator.SetBool ("Walking", false);
//		}
	}

}

	


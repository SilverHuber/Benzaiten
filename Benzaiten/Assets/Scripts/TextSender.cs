using UnityEngine;
using System.Collections;

public class TextSender : MonoBehaviour
{
	private MyText textTypeScript;
	public Collider2D thisCollider;
	public string textToType;
	public string character;
	public bool onTriggertext;
	public bool colliderNeeded;
	public bool sendText;
	private bool textHasBeenSended;

	void Start ()
	{
		textHasBeenSended = false;
		if (colliderNeeded)
		{
			thisCollider = GetComponent <Collider2D> ();
		}
		textTypeScript = GameObject.FindGameObjectWithTag ("Text").GetComponent <MyText> ();

		if (colliderNeeded)
		{
			if (onTriggertext)
				thisCollider.isTrigger = true;
			else if (!onTriggertext)
				thisCollider.isTrigger = false;
		}
	}

	void Update ()
	{
		if (sendText)
		{
			if (textHasBeenSended == false)
			{
				textTypeScript.TypeLine (textToType, character);
				textHasBeenSended = true;
			}
		}

	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name == "Player")
		{
			if (onTriggertext)
			if (textTypeScript.typing == false)
				textTypeScript.TypeLine (textToType, character);
		}
	}

	void OnCollisionEnter2D ()
	{
		
		print ("fda"); 
		if (onTriggertext == false)
		if (textTypeScript.typing == false)
			textTypeScript.TypeLine (textToType, character);
		
	}
}

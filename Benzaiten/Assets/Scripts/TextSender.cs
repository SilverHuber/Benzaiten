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
	public bool TextOnlyOnce;
	private bool allreadySaid;

	void Start ()
	{
		allreadySaid = false;
		textHasBeenSended = false;
		if (colliderNeeded)
		{
			if (thisCollider == null)
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
		if (other.name == "Player" && allreadySaid == false)
		{
			if (onTriggertext)
			{
				textTypeScript.TypeLine (textToType, character);
				if (TextOnlyOnce)
					allreadySaid = true;
			}
		}
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.name == "Player" && allreadySaid == false)
		if (onTriggertext == false)
		{
			textTypeScript.TypeLine (textToType, character);
			if (TextOnlyOnce)
				allreadySaid = true;
		}

	}
}

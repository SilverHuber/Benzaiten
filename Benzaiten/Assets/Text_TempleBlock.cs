using UnityEngine;
using System.Collections;

public class Text_TempleBlock : MonoBehaviour
{
	private MyText textTypeScript;
	public Collider2D thisCollider;
	public string textToType;
	public string character;
	public bool onTriggertext;


	void Start ()
	{
		thisCollider = GetComponent <Collider2D> ();
		textTypeScript = GameObject.FindGameObjectWithTag ("Text").GetComponent <MyText> ();
		if (onTriggertext)
			thisCollider.isTrigger = true;
		else if (!onTriggertext)
			thisCollider.isTrigger = false;
	}

	void Update ()
	{
	

	}

	void OnTriggerEnter2D ()
	{
		if (onTriggertext)
			textTypeScript.TypeLine (textToType, character);
	
	}

	void OnCollisionEnter2D ()
	{
		if (onTriggertext == false)
			textTypeScript.TypeLine (textToType, character);
	}
}

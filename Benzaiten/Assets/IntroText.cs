using UnityEngine;
using System.Collections;

public class IntroText : MonoBehaviour
{
	private MyText textTypeScript;

	// Use this for initialization
	void Start ()
	{
		textTypeScript = GameObject.FindGameObjectWithTag ("Text").GetComponent <MyText> ();
		textTypeScript.TypeLine ("I've been ressurected! These people are exploring my tomb... Let's see if can make this place like in the old days.", "Benzaiten");
		textTypeScript.TypeLine ("I still have my magical flute! If only I remebered the songs I used to play...", "Benzaiten");

	}
	
	// Update is called once per frame
	void Update ()
	{

	}
}

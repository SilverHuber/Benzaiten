using UnityEngine;
using System.Collections;

public class IntroText : MonoBehaviour
{
	private MyText textTypeScript;

	// Use this for initialization
	void Start ()
	{
		textTypeScript = GameObject.FindGameObjectWithTag ("Text").GetComponent <MyText> ();
		textTypeScript.TypeLine ("Wait- what happened?", "Benzaiten");
		textTypeScript.TypeLine ("Have I been resurrected? What happened to my temple?", "Benzaiten");
		textTypeScript.TypeLine ("I don't know where my Biwa is, but at least I still have my Shakuhachi. If I only remembered the melodies I used to play...", "Benzaiten");
		textTypeScript.TypeLine ("Maybe that human over there can tell me what happened to my temple.", "Benzaiten");


	}
	
	// Update is called once per frame
	void Update ()
	{

	}
}

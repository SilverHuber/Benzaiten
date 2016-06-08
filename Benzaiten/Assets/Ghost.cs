using UnityEngine;
using System.Collections;

public class Ghost : MonoBehaviour
{

	public Color startColor;
	public Color halfRestoredColor;
	public Color fullyRestoredColor;
	public Color currentColor;
	private SpriteRenderer thisSpriteRenderer;

	// Use this for initialization
	void Start ()
	{
		currentColor = startColor;
		thisSpriteRenderer = GetComponent <SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update ()
	{

		thisSpriteRenderer.color = currentColor;

	
	}
}

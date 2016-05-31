using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class movie : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		((MovieTexture)GetComponent<RawImage> ().mainTexture).Play ();

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!((MovieTexture)GetComponent<RawImage> ().mainTexture).isPlaying)
		{
			Debug.Log ("movie end");
			Application.LoadLevel (1);
		}
	}
}
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class movie : MonoBehaviour
{
	AsyncOperation async;
	// Use this for initialization
	void Start ()
	{
		((MovieTexture)GetComponent<RawImage> ().mainTexture).Play ();

	}
	
	// Update is called once per frame
	void Update ()
	{
		Cursor.visible = false;

		if (Input.GetKeyDown (KeyCode.Escape))
		{
			Application.Quit ();
		}

		if (!((MovieTexture)GetComponent<RawImage> ().mainTexture).isPlaying)
		{
			Debug.Log ("movie end");
			Application.LoadLevel (2);
			//StartCoroutine ("load");
		}
	}

	IEnumerator load ()
	{
		Debug.LogWarning ("ASYNC LOAD STARTED - " +
		"DO NOT EXIT PLAY MODE UNTIL SCENE LOADS... UNITY WILL CRASH");
		async = Application.LoadLevelAsync (2);
		async.allowSceneActivation = false;
		yield return async;
	}

	public void ActivateScene ()
	{
		async.allowSceneActivation = true;
	}
		
	
}
using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour
{

	public Transform moveTo;
	public SpriteRenderer blackscreen;
	public Camera mainCam;
	public string cameraMode;

	void Start ()
	{
		mainCam = Camera.main;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}


	void OnTriggerEnter2D (Collider2D other)
	{
		
		if (other.name == "Player")
		{
			StartCoroutine (Transportplayer (other.transform));
		}

	}


	IEnumerator Transportplayer (Transform player)
	{
		
		while (blackscreen.color.a < 0.99f)
		{
			Color color = blackscreen.color;
			color.a += 0.03f;
			blackscreen.color = color;
			yield return null;
		}
		if (cameraMode == "Road")
		{
			mainCam.GetComponent <CameraScript> ().currentCameraMode = CameraScript.CameraModes.Road;
		}
		if (cameraMode == "Temple")
		{
			mainCam.GetComponent <CameraScript> ().currentCameraMode = CameraScript.CameraModes.Follow;
		}
		if (cameraMode == "City")
		{
			mainCam.GetComponent <CameraScript> ().currentCameraMode = CameraScript.CameraModes.City;
		}
		if (cameraMode == "FinalRoad")
		{
			mainCam.GetComponent <CameraScript> ().currentCameraMode = CameraScript.CameraModes.FinalRoad;
		}

		yield return new WaitForSeconds (0.5f);

		player.transform.position = moveTo.position;
		player.GetComponent <ButtonMovement> ().enabled = false;
		yield return new WaitForSeconds (0.5f);


		while (blackscreen.color.a > 0.001f)
		{
			Color color = blackscreen.color;
			color.a -= 0.03f;
			blackscreen.color = color;
			yield return null;
		}
		player.GetComponent <ButtonMovement> ().enabled = true;

	}

}

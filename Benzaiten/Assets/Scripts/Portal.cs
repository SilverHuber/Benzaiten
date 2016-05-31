using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour
{

	public Transform moveTo;
	public SpriteRenderer blackscreen;

	// Use this for initialization
	void Start ()
	{
	
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

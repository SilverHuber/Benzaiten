using UnityEngine;
using System.Collections;

public class Final : MonoBehaviour
{
	public SpriteRenderer blackscreen;
	private bool close;
	// Use this for initialization
	void Start ()
	{
		close = false;
	}

	void Update ()
	{
		if (close)
		{
			while (blackscreen.color.a < 0.99f)
			{
				Color color = blackscreen.color;
				color.a += 0.03f;
				blackscreen.color = color;
			}
		}
	}


	void OnTriggerEnter2D (Collider2D other)
	{
		print ("Entered");
		if (other.name == "Player")
			StartCoroutine (Transportplayer (other.transform));
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
	}
}

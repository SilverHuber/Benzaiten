using UnityEngine;
using System.Collections;

public class TriggerBox : MonoBehaviour
{

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name == "Player")
		{
			GetComponent <Animator> ().SetBool ("Pulse", true);
		}
	}


	void OnTriggerExit2D (Collider2D other)
	{
		if (other.name == "Player")
		{
			GetComponent <Animator> ().SetBool ("Pulse", false);
		}
	}
}

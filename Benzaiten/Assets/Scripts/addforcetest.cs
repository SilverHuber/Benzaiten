using UnityEngine;
using System.Collections;

public class addforcetest : MonoBehaviour
{

	private Rigidbody2D thisRB;
	public float wind;
	public int minWindForce;
	public int maxWindForce;

	void Start ()
	{
		thisRB = this.gameObject.GetComponent <Rigidbody2D> ();
		StartCoroutine (WindSimulator ());
	}



	private IEnumerator WindSimulator ()
	{
		wind = Random.Range (minWindForce, maxWindForce);
		Debug.Log ("windy");
		thisRB.AddForce (Vector2.left * wind);
		yield return  new WaitForSeconds (Random.Range (0.1f, 1));
		StartCoroutine (WindSimulator ());
	}
}

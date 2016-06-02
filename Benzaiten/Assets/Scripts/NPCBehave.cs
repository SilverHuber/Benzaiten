using UnityEngine;
using System.Collections;

public class NPCBehave : MonoBehaviour
{
	public bool staticCharacter;
	private Vector2 newPos;
	private Animator thisAnimator;
	private SpriteRenderer thisSpriteRenderer;

	bool defineWaypoint;
	public Transform centerOfWalkingRadius;
	public float walkingRadius;
	public int timeBetweenWalks;
	public float speed;
	private bool moving;

	void Start ()
	{
		//speed = 3;
		thisAnimator = GetComponent <Animator> ();
		thisSpriteRenderer = GetComponent <SpriteRenderer> ();

//		if (!staticCharacter)
//			StartCoroutine (Wandering (new Vector2 (centerOfWalkingRadius.position.x + Random.Range (-walkingRadius, walkingRadius), centerOfWalkingRadius.position.y + Random.Range (-walkingRadius, walkingRadius))));
	}

	void Update ()
	{
		if (!staticCharacter && moving == false)
		{
			moving = true;
			StartCoroutine (Wandering (new Vector2 (centerOfWalkingRadius.position.x + Random.Range (-walkingRadius, walkingRadius), centerOfWalkingRadius.position.y + Random.Range (-walkingRadius, walkingRadius))));
		}
	}


	/// <summary>
	/// Makes the instance wander to the given vector2.
	/// </summary>
	private IEnumerator Wandering (Vector2 newPos)
	{


		Vector2 currentPos = transform.position;

		while (Vector2.Distance (currentPos, newPos) > 0.3)
		{
			if (currentPos.x < newPos.x)
			{
				thisSpriteRenderer.flipX = true;
			}

			if (currentPos.x > newPos.x)
			{
				thisSpriteRenderer.flipX = false;
			}

			Debug.Log ("Wandering");
			transform.position = Vector2.MoveTowards (transform.position, newPos, speed * Time.deltaTime);
			thisAnimator.SetBool ("Walking", true);



			if (Vector2.Distance (transform.position, newPos) < 0.4)
			{
				break;
			} else if (Vector2.Distance (currentPos, newPos) > 0.4)
			{
				yield return null;
			}
				
		}

		thisAnimator.SetBool ("Walking", false);
		yield return new WaitForSeconds (Random.Range (2, timeBetweenWalks));
		StartCoroutine (Wandering (new Vector2 (centerOfWalkingRadius.position.x + Random.Range (-walkingRadius, walkingRadius), centerOfWalkingRadius.position.y + Random.Range (-walkingRadius, walkingRadius))));

	}








}






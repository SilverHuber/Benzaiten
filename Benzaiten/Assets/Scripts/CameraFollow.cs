using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
	public bool shouldFollow = true;
	private Transform player;
	public Transform target;
	private Vector3 player_Pos;
	private Vector3 targetPos;
	private float smooth = 0.07f;

	private void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}


	private void FixedUpdate ()
	{
		if (shouldFollow)
		{
			if (target = null)
			{ 

				player_Pos.x = player.position.x;
				player_Pos.y = player.position.y;
				player_Pos.z = transform.position.z;
				transform.position = Vector3.Lerp (transform.position, player_Pos, smooth);   
			} else if (target != null)
			{
				targetPos.x = target.position.x;
				targetPos.y = target.position.y;
				targetPos.z = transform.position.z;
				transform.position = Vector3.Lerp (transform.position, targetPos, smooth);   
			}
		} else
		{
			
			//stay
		}


	}
}

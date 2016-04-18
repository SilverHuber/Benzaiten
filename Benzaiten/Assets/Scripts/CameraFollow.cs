using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
	public bool shouldFollow = true;
	private Transform Player;
	private Vector3 Player_Pos;
	private float Smooth = 0.07f;

	private void Start ()
	{
		Player = GameObject.FindGameObjectWithTag ("Player").transform;
	}


	private void FixedUpdate ()
	{
		if (shouldFollow)
		{
			Player_Pos.x = Player.position.x;
			Player_Pos.y = Player.position.y;
			Player_Pos.z = transform.position.z;
			transform.position = Vector3.Lerp (transform.position, Player_Pos, Smooth);    
		} else
		{
			//stay
		}


	}
}

﻿using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{
	private Transform player;
	public Transform target;
	private Vector3 player_Pos;
	private Vector3 targetPos;
	private float smooth = 0.07f;

	public enum CameraModes
	{
		Follow,
		Road,
		City,
		FinalRoad,
	}

	;

	public CameraModes currentCameraMode;


	private void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		currentCameraMode = CameraModes.Follow;
	}


	private void FixedUpdate ()
	{
		Cursor.visible = false;


		switch (currentCameraMode)
		{
		case CameraModes.Follow:
			
			targetPos.x = target.position.x;
			targetPos.y = target.position.y;
			targetPos.z = transform.position.z;
			transform.position = Vector3.Lerp (transform.position, targetPos, smooth);   

			break;
		case CameraModes.Road:
			 

			targetPos.x = target.position.x;
			targetPos.y = -1.13f;
			targetPos.z = transform.position.z;
			if (targetPos.x > 79.5f)
			{
				targetPos.x = 79.5f;
			}
			if (targetPos.x < 67.7f)
			{
				
				targetPos.x = 67.7f;
			}
			transform.position = Vector3.Lerp (transform.position, targetPos, smooth);   

			break;
		case CameraModes.City:
			targetPos.x = target.position.x;
			targetPos.y = target.position.y;
			targetPos.z = transform.position.z;
			if (targetPos.x > 6.6f)
			{
				targetPos.x = 6.6f;
			}
			if (targetPos.x < -6.6f)
			{

				targetPos.x = -6.6f;
			}

			if (targetPos.y > 3.91f)
			{
				targetPos.y = 3.91f;
			}
			if (targetPos.y < -3.58f)
			{

				targetPos.y = -3.58f;
			}
			transform.position = Vector3.Lerp (transform.position, targetPos, smooth);   
			break;
		case CameraModes.FinalRoad:
			targetPos.x = target.position.x;
			targetPos.y = target.position.y;
			targetPos.z = transform.position.z;
			if (targetPos.x > -41.20012f)
			{
				targetPos.x = -41.20012f;
			}
			if (targetPos.x < -53.2784f)
			{

				targetPos.x = -53.2784f;
			}

			if (targetPos.y > -1.635244f)
			{
				targetPos.y = -1.635244f;
			}
			if (targetPos.y < -3.58f)
			{

				targetPos.y = -3.58f;
			}
			transform.position = Vector3.Lerp (transform.position, targetPos, smooth);   
			break;

		}
		
	}



}


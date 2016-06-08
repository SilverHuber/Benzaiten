#if ! (UNITY_DASHBOARD_WIDGET || UNITY_WEBPLAYER || UNITY_WII || UNITY_NACL || UNITY_FLASH || UNITY_BLACKBERRY) // Disable under unsupported platforms.
//////////////////////////////////////////////////////////////////////
//
// Copyright (c) 2014 Audiokinetic Inc. / All Rights Reserved
//
//////////////////////////////////////////////////////////////////////
using UnityEngine;
using System;
using System.Collections;

public class AkTriggerEnter : AkTriggerBase
{
	void OnTriggerEnter(Collider in_other)
	{
		print ("enteredsoundtrigger!!!");
		if(triggerDelegate != null) 
		{
			triggerDelegate(in_other.gameObject);
		}
	}
	void OnTriggerEnter2D (Collider2D in_other)
	{
	
	if(triggerDelegate != null) 
	{
			if (in_other.gameObject.name == "Player") {
				print ("enteredsoundtrigger!!!");
				triggerDelegate (in_other.gameObject);
			}
	}
	}
}

#endif // #if ! (UNITY_DASHBOARD_WIDGET || UNITY_WEBPLAYER || UNITY_WII || UNITY_NACL || UNITY_FLASH || UNITY_BLACKBERRY) // Disable under unsupported platforms.
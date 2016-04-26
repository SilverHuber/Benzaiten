using UnityEngine;
using System.Collections;

public class RestoreObject : MonoBehaviour
{
	public bool blessed;
	// Use this for initialization
	void Start ()
	{
		blessed = false;
		this.gameObject.tag = "RestoreObject";
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

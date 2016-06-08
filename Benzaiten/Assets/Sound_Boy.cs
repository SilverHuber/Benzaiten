using UnityEngine;
using System.Collections;

public class Sound_Boy : MonoBehaviour {

	public GameObject player;
	Vector3 distanceToPlayerVector;
	float distanceToPlayer;
	public bool helpedBoy = false;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
		distanceToPlayerVector = player.transform.position - gameObject.transform.position;
		distanceToPlayer = distanceToPlayerVector.magnitude;

		if (!helpedBoy) {
			if (distanceToPlayer < 20) {
				print (distanceToPlayer);
				AkSoundEngine.SetRTPCValue ("DistanceToViolin", distanceToPlayer);
			}
		} else {
			AkSoundEngine.SetRTPCValue ("DistanceToViolin", 20.0f);

		}
	
	}
}

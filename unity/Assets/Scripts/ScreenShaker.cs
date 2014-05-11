using UnityEngine;
using System.Collections;

public class ScreenShaker : MonoBehaviour {

	float timeForNextShake = 0;
	float nextShakeMinDelay = 1.5f;
	float nextShakeMaxDelay = 7f;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    if (Time.time > timeForNextShake) {
			timeForNextShake = Time.time + Random.Range (nextShakeMinDelay, nextShakeMaxDelay);
			GameObject.Find ("Main Camera").animation.Play ();
			GameObject.Find ("BottleManager").GetComponent<BottleManager>().drop();
		}
	}
}

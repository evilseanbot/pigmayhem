using UnityEngine;
using System.Collections;

public class ScreenShaker : MonoBehaviour {

	float timeForNextShake = 0;
	public float nextShakeMinDelay = 0.5f;
	public float nextShakeMaxDelay = 2f;
	public float timeTwirling = 1f;
	public AudioClip rumble;
	public AudioClip poof;

	// Use this for initialization
	void Start () {
		timeForNextShake = Time.time + 5f;   
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//if (active) {
			while (Time.time > timeForNextShake) {
					timeForNextShake += Random.Range (nextShakeMinDelay, nextShakeMaxDelay);
					//GameObject.Find ("Main Camera").animation.Play ();
					GameObject.Find ("BottleManager").GetComponent<BottleManager> ().drop ();
			}
		//}
	}

	void shake() {

	}

	public void playRumble() {
		AudioSource.PlayClipAtPoint (rumble, new Vector3 (0, 0, -10));
		AudioSource.PlayClipAtPoint (poof, new Vector3 (0, 0, -10));

	}
}

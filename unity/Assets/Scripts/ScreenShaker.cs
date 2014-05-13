using UnityEngine;
using System.Collections;

public class ScreenShaker : MonoBehaviour {

	float timeForNextDrop = 0;
	public float nextDropMinDelay = 0.5f;
	public float nextDropMaxDelay = 2f;
	public float timeTwirling = 1f;
	public AudioClip rumble;
	public AudioClip poof;

	// Use this for initialization
	void Start () {
		timeForNextDrop = Time.time + 5f;   
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		while (Time.time > timeForNextDrop) {
			timeForNextDrop += Random.Range (nextDropMinDelay, nextDropMaxDelay);
			GameObject.Find ("BottleManager").GetComponent<BottleManager> ().drop ();
		}
	}
	
	public void playRumble() {
		AudioSource.PlayClipAtPoint (rumble, new Vector3 (0, 0, -10));
		AudioSource.PlayClipAtPoint (poof, new Vector3 (0, 0, -10));

	}

	public void shake() {
		nextDropMaxDelay /= 1.75f;
		nextDropMinDelay /= 1.75f;
		timeTwirling /= 1.75f;
		
		playRumble();

	}
}

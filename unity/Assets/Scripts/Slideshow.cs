using UnityEngine;
using System.Collections;

public class Slideshow : MonoBehaviour {

	public string nextLevel;
	public GameObject fadeOut;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.anyKeyDown) {
			Invoke ("loadNextLevel", 2f);
			Instantiate (fadeOut, new Vector3(0, 0, -8f), Quaternion.Euler (0, 0, 0));
		}
	}

	void loadNextLevel() {
		Application.LoadLevel (nextLevel);
	}
}

using UnityEngine;
using System.Collections;

public class Cauldron : MonoBehaviour {
	public int bottlesAdded = 0;
	public GameObject fadeOut;
	public bool fadedOut = false;
	// Use this for initialization

	public GameObject smoke2;
	public GameObject smoke1;
	public GameObject smoke0;


	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (bottlesAdded >= 10 && !fadedOut) {
			fadedOut = true;
			Invoke ("addFadeOut", 4f);
			Invoke ("loadNextLevel", 6f);
		}
	}

	void addFadeOut() {
		Instantiate (fadeOut, new Vector3(0, 0, -5), Quaternion.Euler(0, 0, 0));
	}


	void loadNextLevel() {

		Application.LoadLevel ("end");
	}

	public void emitNumber() {
		if (bottlesAdded == 1) {
			Instantiate (smoke2, new Vector3 (2f, -1f, 0), Quaternion.Euler (0, 0, 0));
		} else if (bottlesAdded == 2) {
			Instantiate (smoke1, new Vector3 (2f, -1f, 0), Quaternion.Euler (0, 0, 0));
		} else if (bottlesAdded == 3) {
		Instantiate (smoke0, new Vector3 (2f, -1f, 0), Quaternion.Euler (0, 0, 0));
	}

	}
}

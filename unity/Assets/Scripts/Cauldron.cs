using UnityEngine;
using System.Collections;

public class Cauldron : MonoBehaviour {
	public int bottlesAdded = 0;
	public GameObject fadeOut;
	public bool fadedOut = false;

	public GameObject[] smoke;
	
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
		int bottlesLeft = 10 - bottlesAdded;

		if (bottlesLeft >= 0 && bottlesLeft <= 9) {

			Instantiate (smoke [bottlesLeft], new Vector3 (transform.position.x, transform.position.y+0.5f, 0), Quaternion.Euler (0, 0, 0));
		}

	}
}

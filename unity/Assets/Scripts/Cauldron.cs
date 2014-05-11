using UnityEngine;
using System.Collections;

public class Cauldron : MonoBehaviour {
	public int bottlesAdded = 0;
	public GameObject fadeOut;
	public bool fadedOut = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (bottlesAdded >= 3 && !fadedOut) {
			Instantiate (fadeOut, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
			fadedOut = true;
		}
	}
}

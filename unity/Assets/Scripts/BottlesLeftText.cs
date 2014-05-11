using UnityEngine;
using System.Collections;

public class BottlesLeftText : MonoBehaviour {
	public int bottlesLeft = 1000;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		string bottlesLeftString = bottlesLeft.ToString ();
		gameObject.GetComponent<TextMesh> ().text = "x" + bottlesLeftString;
	}
}

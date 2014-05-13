using UnityEngine;
using System.Collections;

public class BottlesLeftText : MonoBehaviour {
	public int bottlesLeft = 1000;
	TextMesh text;

	// Use this for initialization
	void Start () {
		text = GetComponent<TextMesh> ();
	}
	
	// Update is called once per frame
	void Update () {
		string bottlesLeftString = bottlesLeft.ToString ();
		text.text = "x" + bottlesLeftString;
	}
}

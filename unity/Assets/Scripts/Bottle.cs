using UnityEngine;
using System.Collections;

public class Bottle : MonoBehaviour {

	public float fallDelay = 0.5f;
	bool dropping = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (dropping) {
			rigidbody2D.AddTorque (0.05f);

		}
	
	}

	public void drop() {
		gameObject.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1);
		transform.FindChild ("YetiLightMask").GetComponent<SpriteRenderer> ().enabled = true;
		Invoke ("fall", fallDelay);
		dropping = true;
	}

	public void fall() {
		rigidbody2D.gravityScale = 1;
	}
}

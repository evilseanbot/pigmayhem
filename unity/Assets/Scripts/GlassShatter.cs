using UnityEngine;
using System.Collections;

public class GlassShatter : MonoBehaviour {

	public bool broken = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "wall") {
			broken = true;
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
			transform.FindChild ("YetiLightMask").gameObject.GetComponent<SpriteRenderer>().enabled = false;
			transform.localRotation = Quaternion.Euler (0, 0, 0);
			rigidbody2D.fixedAngle = true;
			transform.FindChild ("BottomOfBottle").FindChild ("Glass Shatter").gameObject.GetComponent<ParticleSystem>().Play ();
		}
	}
}

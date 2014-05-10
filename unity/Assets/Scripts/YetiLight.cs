using UnityEngine;
using System.Collections;

public class YetiLight : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D collision) {
		Debug.Log (collision.gameObject.GetComponent<SpriteRenderer> ().color);
		gameObject.GetComponent<SpriteRenderer> ().color = collision.gameObject.GetComponent<SpriteRenderer> ().color;
	}

	void OnTriggerExit2D() {
		gameObject.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1);

	}
}

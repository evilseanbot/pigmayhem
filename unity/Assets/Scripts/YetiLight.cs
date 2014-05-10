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
		if (collision.gameObject.tag == "light") {
		    gameObject.GetComponent<SpriteRenderer> ().color = collision.gameObject.GetComponent<SpriteRenderer> ().color;
		}

		/*if (collision.gameObject.tag == 'exit') {

		}*/
	}

	void OnTriggerExit2D() {
		gameObject.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1);

	}
}

using UnityEngine;
using System.Collections;

public class Bottle : MonoBehaviour {

	public float fallDelay = 0.5f;
	Vector3 cauldronPos;
	bool dropping = false;
	public bool thrown = false;

	// Use this for initialization
	void Start () {
		cauldronPos = GameObject.Find ("Cauldron").transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (dropping) {
			rigidbody2D.AddTorque (0.05f);

		}

		if (thrown) {
			transform.position = Vector3.MoveTowards (transform.position, 
	          new Vector3 (cauldronPos.x, transform.position.y, transform.position.z),
	          0.1f);
			rigidbody2D.AddTorque (-3f * Time.deltaTime);

		}
	
	}

	public void drop() {
		dropping = true;
		gameObject.GetComponent<BoxCollider2D> ().enabled = true;
		gameObject.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1);
		transform.FindChild ("YetiLightMask").GetComponent<SpriteRenderer> ().enabled = true;
		Invoke ("fall", fallDelay);
	}

	public void fall() {
		rigidbody2D.gravityScale = 1;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "yeti") {
			if (dropping && !thrown) {
				if (!gameObject.GetComponent<GlassShatter>().broken) {
					transform.position = Vector3.MoveTowards (transform.position, 
						new Vector3 (transform.position.x, transform.position.y+5f, transform.position.z),
						1f);

					thrown = true;

					//gameObject.GetComponent<BoxCollider2D>().enabled = false;
					gameObject.GetComponent<BoxCollider2D>().isTrigger = true;

					rigidbody2D.AddTorque (-30f);
					dropping = false;
					rigidbody2D.AddForce (new Vector2(0, 300f));
				}
			}
		}

	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.tag == "cauldron") {
			if (thrown) {
				GameObject.Find ("CauldronBubble").particleSystem.Play ();
				GameObject cauldronLight = GameObject.Find ("CauldronLight");
				cauldronLight.animation.Play ();
				cauldronLight.transform.localScale = new Vector3(6,6, 1);
				GameObject.Find ("Cauldron").GetComponent<Cauldron>().bottlesAdded += 1;
				GameObject.Destroy (gameObject);
			}
		}
	}
}

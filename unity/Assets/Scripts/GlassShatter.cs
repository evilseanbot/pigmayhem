using UnityEngine;
using System.Collections;

public class GlassShatter : MonoBehaviour {

	public bool broken = false;
	public AudioClip shatterSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "wall" && !broken) {
			broken = true;
			AudioSource.PlayClipAtPoint (shatterSound, new Vector3(0, 0, 0), 0.5f);
			gameObject.GetComponent<SpriteRenderer>().color =  new Color (0.25f, 0.25f, 0.25f, 1f);
			transform.FindChild ("YetiLightMask").gameObject.GetComponent<SpriteRenderer>().enabled = false;
			transform.localRotation = Quaternion.Euler (0, 0, 0);
			rigidbody2D.fixedAngle = true;
			transform.FindChild ("BottomOfBottle").FindChild ("Glass Shatter").gameObject.GetComponent<ParticleSystem>().Play ();
			gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
			rigidbody2D.velocity = new Vector2 (0, 0);
			rigidbody2D.gravityScale = 0;

			//GameObject.Find ("BottleManager").GetComponent<BottleManager> ().spawnBottle ();
			GameObject.Find ("BottleManager").GetComponent<BottleManager> ().spawnBottle ();
			float removeTime = Mathf.Max (gameObject.GetComponent<Bottle>().fallDelay * 10f, 0.25f);
			GameObject.Find ("BottlesLeftText").GetComponent<BottlesLeftText>().bottlesLeft--;
			Invoke ("remove", removeTime);
		}
	}

	void remove() {
		Destroy (gameObject);
	}
}

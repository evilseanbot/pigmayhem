using UnityEngine;
using System.Collections;

public class Bottle : MonoBehaviour {

	public float fallDelay = 0.5f;
	Vector3 cauldronPos;
	public bool dropping = false;
	public bool thrown = false;
	public bool magic;
	public Color darkColor;
	public Color lightColor;
	public float audioVolume;

	public bool forceMagic;
	public Sprite magicBottleSprite;
	
	public AudioClip collect;

	// Use this for initialization
	void Start () {
		cauldronPos = GameObject.Find ("Cauldron").transform.position;
		audioVolume = GameObject.Find ("BottleManager").GetComponent<BottleManager> ().bottleAudioVolume;
		determineMagic ();
		gameObject.GetComponent<SpriteRenderer> ().color = new Color (0.25f, 0.25f, 0.25f, 1f);
		fallDelay = GameObject.Find ("ScreenShaker").GetComponent<ScreenShaker> ().timeTwirling;
	}

	void determineMagic() {
		int magicFreq = (int) GameObject.Find ("BottleManager").GetComponent<BottleManager> ().magicFreq;

		if (Random.Range (0, magicFreq+1) <= 0) {
			magic = true;
		} else {
			magic = false;
		}
		
		if (forceMagic) {
			magic = true;
		}
		
		if (magic) {
			darkColor = new Color (0.06f, 0.06f, 0.25f);
			lightColor = new Color (0.25f, 0.25f, 1, 0.5f);
			GetComponent<SpriteRenderer>().sprite = magicBottleSprite;
		} else {
			darkColor = new Color (0.12f, 0.06f, 0);
			lightColor = new Color (0.5f, 0.25f, 0, 0.5f);
		}

		transform.FindChild ("BottomOfBottle").FindChild ("Glass Shatter").particleSystem.startColor = lightColor;
	}
	
	void FixedUpdate () {
		if (dropping) {
			rigidbody2D.AddTorque (3f * Time.deltaTime);
		}

		if (thrown) {
			transform.position = Vector3.MoveTowards (transform.position, 
	          new Vector3 (cauldronPos.x, transform.position.y, transform.position.z),
	          0.1f);
			rigidbody2D.AddTorque (-3f * Time.deltaTime);
		}
	
	}

	void enterForeground() {
		GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1);
		transform.Translate (0, 0, -1f);
	}

	public void drop() {
		dropping = true;
		GetComponent<BoxCollider2D> ().enabled = true;
		enterForeground ();
		Invoke ("fall", fallDelay);
	}

	public void fall() {
		rigidbody2D.gravityScale = 1;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "yeti") {
			if (dropping && !thrown) {
				if (!gameObject.GetComponent<GlassShatter>().broken) {
					if (magic) {
						transform.Translate(0, -5f, 0);

						thrown = true;
						gameObject.GetComponent<BoxCollider2D>().isTrigger = true;

						rigidbody2D.AddTorque (-30f);
						dropping = false;
						rigidbody2D.velocity = new Vector2(0, 0);
						rigidbody2D.AddForce (new Vector2(0, 500f));
						rigidbody2D.gravityScale = 2;
					} else {
						//AudioSource.PlayClipAtPoint (collect, new Vector3(0, 0, -10), audioVolume/3f);
						deleteBottle();
					}
				}
			}
		}

	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.tag == "cauldron") {
			if (thrown) {

				GameObject.Find ("CauldronBubble").particleSystem.Play ();
				//GameObject cauldronLight = GameObject.Find ("CauldronLight");
				//cauldronLight.animation.Play ();
				//cauldronLight.transform.localScale = new Vector3(6,6, 1);

				Cauldron cauldron = GameObject.Find ("Cauldron").GetComponent<Cauldron>();
				cauldron.bottlesAdded += 1;
				cauldron.emitNumber();

				GameObject.Find ("Main Camera").animation.Play ();

				ScreenShaker screenShaker = GameObject.Find ("ScreenShaker").GetComponent<ScreenShaker>();
				screenShaker.shake();

				BottleManager bottleManager = GameObject.Find ("BottleManager").GetComponent<BottleManager>();
				bottleManager.magicFreq *= 1.87f;
				bottleManager.bottleAudioVolume *= 0.80f;

				turnOffBottlesIfWon(bottleManager, cauldron);

				deleteBottle();
			}
		}
	}

	void turnOffBottlesIfWon(BottleManager bottleManager, Cauldron cauldron) {
		int bottlesCollected = cauldron.bottlesAdded;
		
		if (bottlesCollected >= 10) {
			bottleManager.isActive = false;
		}

	}

	void deleteBottle() {
		GameObject.Find ("BottleManager").GetComponent<BottleManager> ().spawnBottle (false);
		GameObject.Destroy (gameObject);
	}
}

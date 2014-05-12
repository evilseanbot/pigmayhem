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

		int magicFreq = (int) GameObject.Find ("BottleManager").GetComponent<BottleManager> ().magicFreq;
		audioVolume = GameObject.Find ("BottleManager").GetComponent<BottleManager> ().bottleAudioVolume;

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
			lightColor = new Color (0.25f, 0.25f, 1);
			gameObject.GetComponent<SpriteRenderer>().sprite = magicBottleSprite;
		} else {
			darkColor = new Color (0.12f, 0.06f, 0);
			lightColor = new Color (0.5f, 0.25f, 0);
		}

		gameObject.GetComponent<SpriteRenderer> ().color = new Color (0.25f, 0.25f, 0.25f, 1f); //darkColor;
		transform.FindChild ("BottomOfBottle").FindChild ("Glass Shatter").particleSystem.startColor = lightColor;

		fallDelay = GameObject.Find ("ScreenShaker").GetComponent<ScreenShaker> ().timeTwirling;
	}
	
	// Update is called once per frame
	void Update () {
		//audioVolume = GameObject.Find ("BottleManager").GetComponent<BottleManager> ().bottleAudioVolume;

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
		gameObject.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 1); //lightColor;
		//transform.FindChild ("YetiLightMask").GetComponent<SpriteRenderer> ().enabled = true;
		transform.position = Vector3.MoveTowards (transform.position, 
		                                          new Vector3 (transform.position.x, transform.position.y, transform.position.z-1f),
		                                          1f);
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
						transform.position = Vector3.MoveTowards (transform.position, 
							new Vector3 (transform.position.x, transform.position.y+5f, transform.position.z),
							1f);

						thrown = true;

						//gameObject.GetComponent<BoxCollider2D>().enabled = false;
						gameObject.GetComponent<BoxCollider2D>().isTrigger = true;

						rigidbody2D.AddTorque (-30f);
						dropping = false;
						rigidbody2D.velocity = new Vector2(0, 0);
						rigidbody2D.AddForce (new Vector2(0, 250f));
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
				GameObject cauldronLight = GameObject.Find ("CauldronLight");
				cauldronLight.animation.Play ();
				cauldronLight.transform.localScale = new Vector3(6,6, 1);
				GameObject.Find ("Cauldron").GetComponent<Cauldron>().bottlesAdded += 1;
				GameObject.Find ("Cauldron").GetComponent<Cauldron>().emitNumber();

				GameObject.Find ("Main Camera").animation.Play ();

				GameObject screenShaker = GameObject.Find ("ScreenShaker");
				screenShaker.GetComponent<ScreenShaker>().nextShakeMaxDelay /= 1.5f;
				screenShaker.GetComponent<ScreenShaker>().nextShakeMinDelay /= 1.5f;
				screenShaker.GetComponent<ScreenShaker>().timeTwirling /= 1.5f;

				screenShaker.GetComponent<ScreenShaker>().playRumble();

				GameObject.Find ("BottleManager").GetComponent<BottleManager>().magicFreq *= 1.5f;
				GameObject.Find ("BottleManager").GetComponent<BottleManager>().bottleAudioVolume *= 0.80f;

				int bottlesCollected = GameObject.Find ("Cauldron").GetComponent<Cauldron>().bottlesAdded;

				if (bottlesCollected >= 10) {
					GameObject.Find ("BottleManager").GetComponent<BottleManager>().isActive = false;
				}


				deleteBottle();
			}
		}
	}

	void deleteBottle() {
		GameObject.Find ("BottleManager").GetComponent<BottleManager> ().spawnBottle ();
		//GameObject.Find ("BottleManager").GetComponent<BottleManager> ().spawnBottle ();
		GameObject.Destroy (gameObject);
	}
}

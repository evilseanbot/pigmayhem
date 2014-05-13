using UnityEngine;
using System.Collections;

public class GlassShatter : MonoBehaviour {

	public bool broken = false;
	public AudioClip shatterSound;

	public Sprite brokenBottle;
	public Sprite magicBrokenBottle;
	
	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "wall" && !broken) {
			broken = true;

			float audioVolume = gameObject.GetComponent<Bottle>().audioVolume;
			AudioSource.PlayClipAtPoint (shatterSound, new Vector3(0, 0, 0), audioVolume);

			transform.localRotation = Quaternion.Euler (0, 0, 0);
			rigidbody2D.fixedAngle = true;
		    transform.FindChild ("BottomOfBottle").FindChild ("Glass Shatter").gameObject.GetComponent<ParticleSystem>().Play ();

			GetComponent<BoxCollider2D>().isTrigger = true;
			rigidbody2D.velocity = new Vector2 (0, 0);
			rigidbody2D.gravityScale = 0;

			//GameObject.Find ("BottleManager").GetComponent<BottleManager> ().spawnBottle ();
			GameObject.Find ("BottleManager").GetComponent<BottleManager> ().spawnBottle (false);
			float removeTime = Mathf.Max (gameObject.GetComponent<Bottle>().fallDelay * 10f, 0.25f);
			GameObject.Find ("BottlesLeftText").GetComponent<BottlesLeftText>().bottlesLeft--;

			SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

			if (gameObject.GetComponent<Bottle>().magic) {
				spriteRenderer.sprite = magicBrokenBottle;
			} else {
				spriteRenderer.sprite = brokenBottle;
			}

			Invoke ("remove", removeTime);
		}
	}

	void remove() {
		Destroy (gameObject);
	}
}

using UnityEngine;
using System.Collections;

public class YetiControls : MonoBehaviour {
	public float walkSpeed = 8f;

	public Sprite climbLeft;
	public Sprite climbRight;

	public Sprite leftHead;
	public Sprite rightHead;
	public Sprite fowardHead;

	float progression = 0f;

	SpriteRenderer headRenderer;
	SpriteRenderer bodyRenderer;

	// Use this for initialization
	void Start () {
		headRenderer = transform.FindChild ("YetiHead").GetComponent<SpriteRenderer> ();
		bodyRenderer = transform.FindChild ("YetiBody").GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float thisWalkSpeed = walkSpeed * Time.deltaTime;
		float xVel = 0f;
		float yVel = 0f;

	    if ( Input.GetKey ("right") ) {
			xVel = thisWalkSpeed;
		} else if ( Input.GetKey ("left") ) {
			xVel = -thisWalkSpeed;
		}

		if ( Input.GetKey ("up") ) {
			yVel = thisWalkSpeed;
		} else if ( Input.GetKey ("down") ) {
			yVel = -thisWalkSpeed;
		}

		transform.Translate (xVel, yVel, 0);

		if (xVel < 0) {
			headRenderer.sprite = leftHead;
		} else if (xVel > 0) {
			headRenderer.sprite = rightHead;
		} else {
			headRenderer.sprite = fowardHead;
		}

		if (xVel != 0 || yVel != 0) {
			animate ();
		}
	}

	void animate() {
		progression += Time.deltaTime;

		if (progression > 0.3f) {
			bodyRenderer.sprite = climbLeft;
			progression = 0;
		} else if (progression > 0.15f) {
			bodyRenderer.sprite = climbRight;
		}
	}
}

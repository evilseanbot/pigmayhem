using UnityEngine;
using System.Collections;

public class YetiControls : MonoBehaviour {
	public float walkSpeed = 8f;

	public Sprite climbLeft;
	public Sprite climbRight;

	float progression = 0f;

	// Use this for initialization
	void Start () {
	
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

		transform.position = Vector3.MoveTowards(transform.position, 
			new Vector3(transform.position.x+xVel, transform.position.y+yVel, transform.position.z),
			1f);
		if (xVel != 0 || yVel != 0) {
			animate ();
		}
	}

	void animate() {
		progression += Time.deltaTime;

		if (progression > 0.4f) {
			transform.FindChild ("YetiBody").GetComponent<SpriteRenderer>().sprite = climbLeft;
			progression = 0;
		} else if (progression > 0.2f) {
			transform.FindChild ("YetiBody").GetComponent<SpriteRenderer>().sprite = climbRight;
		}
	}
}

using UnityEngine;
using System.Collections;

public class BabaFidget : MonoBehaviour {

	public Sprite head1;
	public Sprite head2;
	public Sprite head3;
	public Sprite body1;
	public Sprite body2;

	SpriteRenderer headRenderer;
	SpriteRenderer bodyRenderer;

	// Use this for initialization
	void Start () {
		headRenderer = transform.FindChild ("BabaYagaHead").GetComponent<SpriteRenderer>();
		bodyRenderer = transform.FindChild ("Body").GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		int change = Random.Range (0, 30);
		if (change == 0) {
			fidget();
		}
	}

	void fidget() {
		int animChange = Random.Range (0, 5);
		
		
		if (animChange == 0) {
			headRenderer.sprite = head1;
		} else if (animChange == 1) {
			headRenderer.sprite  = head2;
		} else if (animChange == 2) {
			headRenderer.sprite = head3;
		} else if (animChange == 3) {
			bodyRenderer.sprite = body1;
		} else if (animChange == 4) {
			bodyRenderer.sprite = body2;
			
		}

	}
}

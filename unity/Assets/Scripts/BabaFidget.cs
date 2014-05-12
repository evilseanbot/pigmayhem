using UnityEngine;
using System.Collections;

public class BabaFidget : MonoBehaviour {

	public Sprite head1;
	public Sprite head2;
	public Sprite head3;
	public Sprite body1;
	public Sprite body2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		int change = Random.Range (0, 30);

		if (change == 0) {
			int animChange = Random.Range (0, 5);

			if (animChange == 0) {
				transform.FindChild ("BabaYagaHead").GetComponent<SpriteRenderer>().sprite = head1;

			} else if (animChange == 1) {
				transform.FindChild ("BabaYagaHead").GetComponent<SpriteRenderer>().sprite = head2;

			} else if (animChange == 2) {
				transform.FindChild ("BabaYagaHead").GetComponent<SpriteRenderer>().sprite = head3;

			} else if (animChange == 3) {
				transform.FindChild ("Body").GetComponent<SpriteRenderer>().sprite = body1;

			} else if (animChange == 4) {
				transform.FindChild ("Body").GetComponent<SpriteRenderer>().sprite = body2;
				
			}
		}
	
	}
}

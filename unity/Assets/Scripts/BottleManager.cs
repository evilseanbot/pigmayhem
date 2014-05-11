using UnityEngine;
using System.Collections;

public class BottleManager : MonoBehaviour {
	float timeForNextBottle = 0;
	float nextBottleDelay = 3f;
	public GameObject bottle;

	
	// Update is called once per frame
	public void drop() {
		GameObject[] bottles = GameObject.FindGameObjectsWithTag ("bottle");
		
		ArrayList unbrokenBottles = new ArrayList();
		
		foreach (GameObject i in bottles) {
			if (!i.GetComponent<GlassShatter>().broken) {
				unbrokenBottles.Add(i);
			}
		}
		
		int bottlePick = (int) Random.Range (0, unbrokenBottles.Count);
		Debug.Log (bottlePick);
		
		GameObject pickedBottle = (GameObject) unbrokenBottles[bottlePick];
		pickedBottle.GetComponent<Bottle>().drop();

	}

	void Update () {
		if (Input.GetKeyDown ("x")) {
		}

		if (Time.time > timeForNextBottle) {
			timeForNextBottle = Time.time + nextBottleDelay;

			float xPos = Random.Range (-2.4f, 8.4f);
			float yPos = Random.Range (-0.6f, 3.6f);

			Instantiate (bottle, new Vector3(xPos, yPos, 1), Quaternion.Euler(0, 0, 0));
		}
	
	}
}

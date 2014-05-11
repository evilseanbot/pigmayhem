using UnityEngine;
using System.Collections;

public class BottleManager : MonoBehaviour {
	float timeForNextBottle = 0;
	float nextBottleDelay = 0.5f;
	public GameObject bottle;
	public float mundaneBottlesToGo = 2;
	public float magicFreq = 3;

	
	// Update is called once per frame
	public void drop() {
		GameObject[] bottles = GameObject.FindGameObjectsWithTag ("bottle");

		bool shouldBeMagic;

		if (mundaneBottlesToGo > 0) {
			mundaneBottlesToGo--;
			shouldBeMagic = false;
		} else {
			mundaneBottlesToGo = magicFreq - 1;
			shouldBeMagic = true;
		}

		ArrayList unbrokenBottles = new ArrayList();
		
		foreach (GameObject i in bottles) {
			if (!i.GetComponent<GlassShatter>().broken) {
				if (i.GetComponent<Bottle>().magic == shouldBeMagic) {
					if (i.GetComponent<Bottle>().dropping == false) {
    				    unbrokenBottles.Add(i);
					}
				}
			}
		}

		if (unbrokenBottles.Count > 0) {
			
						int bottlePick = (int)Random.Range (0, unbrokenBottles.Count);

						GameObject pickedBottle = (GameObject)unbrokenBottles [bottlePick];
						pickedBottle.GetComponent<Bottle> ().drop ();

		}

	}

	void Update () {
		/*
		if (Time.time > timeForNextBottle) {
			timeForNextBottle = Time.time + nextBottleDelay;

			float xPos = Random.Range (-2.4f, 8.4f);
			float yPos = Random.Range (-0.6f, 3.6f);

			Instantiate (bottle, new Vector3(xPos, yPos, 1), Quaternion.Euler(0, 0, 0));
		}
		*/
	
	}

	public void spawnBottle() {
		float xPos = Random.Range (-2.4f, 8.4f);
	    float yPos = (float) (int) Random.Range (-1, 4);
		
		Instantiate (bottle, new Vector3(xPos, yPos, 1), Quaternion.Euler(0, 0, 0));
	}
}

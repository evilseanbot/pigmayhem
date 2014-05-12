using UnityEngine;
using System.Collections;

public class BottleManager : MonoBehaviour {
	float timeForNextBottle = 0;
	float nextBottleDelay = 0.5f;
	public GameObject bottle;
	public GameObject forceMagicBottle;
	public float mundaneBottlesToGo = 2;
	public float magicFreq = 3;
	public bool isActive = true;
	public float bottleAudioVolume = 1f;

	
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
		} else if (shouldBeMagic) {
			float xPos = Random.Range (-2.3f, 6.4f);
			int shelf = (int) Random.Range (0, 3);
			float yPos = 2.4f - ((float)shelf * 1.3f);

			Instantiate (forceMagicBottle, new Vector3(xPos, yPos, 1), Quaternion.Euler(0, 0, 0));
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
		if (isActive) {
				float xPos = Random.Range (-2.3f, 6.4f);
				int shelf = (int)Random.Range (0, 3);
				float yPos = 2.4f - ((float)shelf * 1.3f);

				Instantiate (bottle, new Vector3 (xPos, yPos, 1), Quaternion.Euler (0, 0, 0));
		}
	}
}

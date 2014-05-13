using UnityEngine;
using System.Collections;

public class BottleManager : MonoBehaviour {
	public GameObject bottle;
	public GameObject forceMagicBottle;
	public float mundaneBottlesToGo = 2;
	public float magicFreq = 3;
	public bool isActive = true;
	public float bottleAudioVolume = 1f;

	
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
			spawnBottle (true);
		}

	}
	
	public void spawnBottle(bool forceMagic) {
		if (isActive) {
			float xPos = Random.Range (-2.3f, 6.4f);
			int shelf = (int)Random.Range (0, 3);
			float yPos = 2.4f - ((float)shelf * 1.3f);

			if (forceMagic) {
    			Instantiate (forceMagicBottle, new Vector3 (xPos, yPos, 1), Quaternion.Euler (0, 0, 0));
			} else {
				Instantiate (bottle, new Vector3 (xPos, yPos, 1), Quaternion.Euler (0, 0, 0));
			}
		}
	}
}

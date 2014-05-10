using UnityEngine;
using System.Collections;

public class BottleManager : MonoBehaviour {


	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("x")) {
			GameObject[] bottles = GameObject.FindGameObjectsWithTag ("bottle");

			ArrayList unbrokenBottles = new ArrayList();

			foreach (GameObject i in bottles) {
				if (!i.GetComponent<GlassShatter>().broken) {
					unbrokenBottles.Add(i);
				}
			}

			GameObject pickedBottle = (GameObject) unbrokenBottles[0];
			pickedBottle.GetComponent<Bottle>().drop();

			//Debug.Log (unbrokenBottles[0].GetComponent<Bottle>());
			//unbrokenBottles[0].GetComponent<Bottle>().drop();

			//bottles[0].GetComponent<Bottle>().drop();


		}
	
	}
}

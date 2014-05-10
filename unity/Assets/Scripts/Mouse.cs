using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour {

	Vector3 target = new Vector3(0, 0, 0);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
			if (Input.GetMouseButtonDown (0)) {
			    Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				target = ray.origin;

			}
	}

	public Vector3 getTarget() {
		return target;
	}
}

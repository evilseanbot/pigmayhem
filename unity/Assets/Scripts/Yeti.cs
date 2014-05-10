using UnityEngine;
using System.Collections;

public class Yeti : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject myInterface = GameObject.Find ("Interface");
		Vector3 target = myInterface.GetComponent<Mouse>().getTarget();

		if (transform.position.x < target.x - 1f) {

			transform.position = Vector3.MoveTowards(transform.position, 
			                                         new Vector3(transform.position.x+0.5f, transform.position.y, transform.position.z),
			                                         1f);
		} else if (transform.position.x > target.x + 1f) {
			transform.position = Vector3.MoveTowards(transform.position, 
			                                         new Vector3(transform.position.x-0.5f, transform.position.y, transform.position.z),
			                                         1f);
		}	
	}
}

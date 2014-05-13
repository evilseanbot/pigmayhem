using UnityEngine;
using System.Collections;

public class SongChanger : MonoBehaviour {

	public AudioClip gameMusic;

	// Use this for initialization
	void Start () {
		if (GameObject.Find ("SongPlayer") != null) {
			GameObject.Find ("SongPlayer").GetComponent<AudioSource> ().Stop ();
			GameObject.Find ("SongPlayer").GetComponent<AudioSource> ().audio.clip = gameMusic;
			GameObject.Find ("SongPlayer").GetComponent<AudioSource> ().Play ();
		}
	}	
}

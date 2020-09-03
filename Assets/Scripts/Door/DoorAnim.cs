using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnim : MonoBehaviour {

	Animation anim;
	AudioSource audio;

	void Start () {
		anim = GetComponent<Animation> ();
		audio = GetComponent<AudioSource> ();
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.S)) {
			anim["DoorClosing"].speed = 1.0f;
			anim.Play ("DoorClosing");
			audio.Play();
		}

		if (Input.GetKeyDown (KeyCode.A)) {
			anim ["DoorClosing"].speed = -1.0f;
			anim ["DoorClosing"].time = anim ["DoorClosing"].length;
			anim.Play ("DoorClosing");
			audio.Play();
		}
			
	}
}

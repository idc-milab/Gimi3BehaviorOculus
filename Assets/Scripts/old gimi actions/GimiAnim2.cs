using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimiAnim2 : MonoBehaviour {

	Animation anim;
//	AudioSource audio;
//	GameObject gimi;

	void Start () {
		anim = GetComponent<Animation> ();
//		audio = GetComponent<AudioSource> ();
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Keypad1) || Input.GetKeyDown (KeyCode.Alpha1)) {
			anim.Play ("Armature_Action.001");
//			audio.Play();
		}


	}
}

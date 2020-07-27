using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimiAnim : MonoBehaviour {

	Animation anim;
	AudioSource audio;
//	GameObject gimi;

	void Start () {
		anim = GetComponent<Animation> ();
		audio = GetComponent<AudioSource> ();
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Keypad1) || Input.GetKeyDown (KeyCode.Alpha1)) {
			anim.Play ("Anim1-PHAL_ANIM");
			audio.Play();
		}

		if (Input.GetKeyDown (KeyCode.Keypad2) || Input.GetKeyDown (KeyCode.Alpha2)) {
			anim.Play ("Anim2-PHLL_ANIM");
			audio.Play ();
		}

		if (Input.GetKeyDown (KeyCode.Keypad3) || Input.GetKeyDown (KeyCode.Alpha3)) {
			anim.Play ("Anim3-PVAL_ANIM");
			audio.Play ();
		}

		if (Input.GetKeyDown (KeyCode.Keypad4) || Input.GetKeyDown (KeyCode.Alpha4)) {
			anim.Play ("Anim4-PVLL_ANIM");
			audio.Play ();
		}

		if (Input.GetKeyDown (KeyCode.Keypad5) || Input.GetKeyDown (KeyCode.Alpha5)) {
			anim.Play ("Anim5-VHAL_ANIM");
			audio.Play ();
		}

		if (Input.GetKeyDown (KeyCode.Keypad6) || Input.GetKeyDown (KeyCode.Alpha6)) {
			anim.Play ("Anim6-VHLL_ANIM");
			audio.Play ();
		}

		if (Input.GetKeyDown (KeyCode.Keypad7) || Input.GetKeyDown (KeyCode.Alpha7)) {
			anim.Play ("Anim7-VVAL_ANIM");
			audio.Play ();
		}

		if (Input.GetKeyDown (KeyCode.Keypad8) || Input.GetKeyDown (KeyCode.Alpha8)) {
			anim.Play ("Anim8-VVLL_ANIM");
			audio.Play ();
		}

		if(Input.GetKeyDown(KeyCode.Keypad9) || Input.GetKeyDown(KeyCode.Alpha9))
			anim.Play("Anim1-PHAL_ANIM");
//			anim.Play("Armature_Action.001");

		if(Input.GetKeyDown(KeyCode.Keypad0) || Input.GetKeyDown(KeyCode.Alpha0))
            anim.Play("Anim8-VVLL_ANIM");
            //anim.Play("TestAnimation");

    }
}

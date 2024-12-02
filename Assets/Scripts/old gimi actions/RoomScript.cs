using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour {

	AudioSource audio;
	GameObject gimi;
	GameObject phal;
	GameObject pval;
    GameObject phll;
    GameObject pvll;
    GameObject vhal;
    GameObject vhll;
    GameObject vval;
    GameObject vvll;


    void Start () {
		audio = GetComponent<AudioSource> ();
//		gimi = GameObject.Find("GIMI");
		phal = GameObject.Find("GIMI_PHAL");
		pval = GameObject.Find("GIMI_PVAL");
        phll = GameObject.Find("GIMI_PHLL");
        pvll = GameObject.Find("GIMI_PVLL");
        vhal = GameObject.Find("GIMI_VHAL");
        vhll = GameObject.Find("GIMI_VHLL");
        vval = GameObject.Find("GIMI_VVAL");
        vvll = GameObject.Find("GIMI_VVLL");
        phal.SetActive(false);
		pval.SetActive(false);
        phll.SetActive(false);
        pvll.SetActive(false);
        vhal.SetActive(false);
        vhll.SetActive(false);
        vval.SetActive(false);
        vvll.SetActive(false);
    }

	void Update () {
		if (!audio.isPlaying && Input.GetKeyDown(KeyCode.P))
			audio.Play();

        //		if (Input.GetKeyDown (KeyCode.Z))
        //			gimi.SetActive(false);
        //
        //		if (Input.GetKeyDown (KeyCode.X))
        //			gimi.SetActive(true);

        if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
            phal.SetActive(true);
        //			gimiphal.MegaCacheOBJ.animate = true;
        if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
            pval.SetActive(true);
        if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3))
            phll.SetActive(true);
        if (Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Alpha4))
            pvll.SetActive(true);
        if (Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.Alpha5))
            vhal.SetActive(true);
        if (Input.GetKeyDown(KeyCode.Keypad6) || Input.GetKeyDown(KeyCode.Alpha6))
            vhll.SetActive(true);
        if (Input.GetKeyDown(KeyCode.Keypad7) || Input.GetKeyDown(KeyCode.Alpha7))
            vval.SetActive(true);
        if (Input.GetKeyDown(KeyCode.Keypad8) || Input.GetKeyDown(KeyCode.Alpha8))
            vvll.SetActive(true);


        if (Input.GetKeyDown (KeyCode.Q))
			phal.SetActive(false);

		if (Input.GetKeyDown (KeyCode.W))
			pval.SetActive(false);

		if (Input.GetKeyDown (KeyCode.E))
			phll.SetActive(false);
        if (Input.GetKeyDown(KeyCode.R))
            pvll.SetActive(false);
        if (Input.GetKeyDown(KeyCode.T))
            vhal.SetActive(false);
        if (Input.GetKeyDown(KeyCode.Y))
            vhll.SetActive(false);
        if (Input.GetKeyDown(KeyCode.U))
            vval.SetActive(false);
        if (Input.GetKeyDown(KeyCode.I))
            vvll.SetActive(false);
    }
}

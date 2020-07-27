using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    
    bool Gimion = false;
    GameObject toactive;
    // Use this for initialization
    void Start () {

        Gimion = false;
	}
    
    public void StartGimi(GameObject giminame)
    {
        toactive = GameObject.Find(giminame.ToString());
        toactive.SetActive(!Gimion);
        Gimion = !Gimion;
    }

	// Update is called once per frame
	void Update () {
		
	}
}

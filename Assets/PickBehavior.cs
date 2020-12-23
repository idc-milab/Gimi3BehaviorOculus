using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static OVRInput;

public class PickBehavior : MonoBehaviour
{
    public static Controller controller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, Controller.All) > 1)
        {
            SceneManager.LoadScene("scaryRoom");

        }
        
    }
}

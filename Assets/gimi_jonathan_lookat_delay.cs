// C#
using System;
using UnityEngine;


public class gimi_jonathan_lookat_delay : MonoBehaviour

{

    
    public Transform target;
    Quaternion orginalPosition;

    [SerializeField]
    bool track = false;

    private void Awake()
    {
        track = false;
    }

    private void Start()
    {
        track = false;
        print("stasrt" + track.ToString());
        orginalPosition = transform.rotation ;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //orginalPosition = gameObject.transform.position;
            track = true;
            print("enter trigger" + track.ToString());
            print("starttracking");
        }
        
    }

    
    private void OnTriggerExit(Collider other)
    {
        track = false;
        print(track.ToString());
        print("endtracking"); 
    }
    void Update()
    {
        
        if (track)
        {

            transform.LookAt(target);
        }
        else
        {
            transform.rotation = orginalPosition;
        }

    }
    
}
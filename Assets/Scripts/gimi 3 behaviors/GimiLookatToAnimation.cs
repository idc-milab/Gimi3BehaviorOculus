using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimiLookatToAnimation : MonoBehaviour
{


    public Transform target;
    public Transform startPoint;
    public Transform endpoint;
    private float time = 0.0f;
    private Animator animator;
    private Animation anim;
    public float sleepTime = 3.0f;
    public float trackTime = 2.0f;
    public float transionSpeedToTarget = 5.0f;
    public float transitionSpeedToStart = 3.0f;
    [SerializeField]
    private bool track = false;

    private void Awake()
    {
        track = false;
    }


    private void OnEnable() { }


    void Update()
    {
        /*
        time += Time.deltaTime;

        if (time >= sleepTime && time < sleepTime + trackTime)
        {
            SmoothLookAt(target.position, transitionSpeedToStart);

        }
        if (track && anim.isPlaying)
        {
            return;
        }
        /*
        if (time >= sleepTime && time < sleepTime+trackTime)
        {
            SmoothLookAt(target.position,transionSpeedToTarget);
        }

        if (time >= sleepTime + trackTime && !track)
        { 
            SmoothLookAt(endpoint.position,transitionSpeedToStart);
        }
        
        //transform.LookAt(endpoint);
        if (time >= sleepTime + trackTime+3f &&!track) { 
            track = true;
            animator.enabled = true;
        }
        if (!anim.isPlaying && track)
        {
            animator.Play("AmitGimi animation");
            return;
        }*/



    }
    void SmoothLookAt(Vector3 newDirection, float speed)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(newDirection - transform.position), Time.deltaTime * speed);
    }

}

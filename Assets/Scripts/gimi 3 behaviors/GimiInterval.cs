// C#
using System;
using UnityEngine;


public class GimiInterval : MonoBehaviour

{
    public Transform target;
    public Transform startPoint;
    private float time = 0.0f;
    private Animation anim;
    public float sleepTime = 3.0f;
    public float trackTime = 3.0f;
    public float transitionSpeedToTarget = 5.0f;
    public float transitionSpeedToStart = 3.0f;
    [SerializeField]
    private bool track = false;

    private void Awake()
    {
        track = false;
    }

    private void Start()
    {
        track = false;
        transform.LookAt(startPoint);

    }


    void Update()
    {
        /*if (!track) {
            transform.rotation = orginalPosition;
        }*/

        time += Time.deltaTime;

        if (time >= sleepTime && time < sleepTime + trackTime)
        {
            SmoothLookAt(target.position, transitionSpeedToTarget);

        }
        if (time >= (sleepTime + trackTime) && time < sleepTime + trackTime + 2)
        {
            SmoothLookAt(startPoint.position, transitionSpeedToStart);

        }
        if (time >= (sleepTime + trackTime + 2f))
        {
            //transform.LookAt(startPoint);
            time = time - (sleepTime + trackTime);
        }


    }
    void SmoothLookAt(Vector3 newDirection, float speed)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(newDirection - transform.position), Time.deltaTime * speed);
    }
}
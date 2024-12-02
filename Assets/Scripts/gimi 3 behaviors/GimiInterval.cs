// C#
using System;
using UnityEngine;


public class GimiInterval : MonoBehaviour

{
    public Transform target;
    public Transform startPoint;
    public float time = 0.0f;
    public float sleepTime = 3.0f;
    public float trackTime = 3.0f;
    public float transitionSpeedToTarget = 5.0f;
    public float transitionSpeedToStart = 3.0f;
    [SerializeField]
    private void Awake()
    {
        
    }
    void Update()
    {

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
            time = time - (sleepTime + trackTime);
        }


    }
    void SmoothLookAt(Vector3 newDirection, float speed)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(newDirection - transform.position), Time.deltaTime * speed);
    }
}
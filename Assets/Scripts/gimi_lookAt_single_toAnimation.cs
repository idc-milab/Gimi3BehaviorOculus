using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gimi_lookAt_single_toAnimation : MonoBehaviour
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

    private void Start()
    {
        track = false;
        transform.LookAt(startPoint);
        animator = gameObject.GetComponent<Animator>();
        anim = gameObject.GetComponent<Animation>();
        
    }

    void Update()
    {
        
        if (!anim.isPlaying && track)
        {
            animator.Play("AmitGimi animation");
            return;
        }
        if (track && anim.isPlaying)
        {
            return;
        }
       
        time += Time.deltaTime;

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
       
        

    }
    void SmoothLookAt(Vector3 newDirection, float speed)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(newDirection - transform.position), Time.deltaTime * speed);
    }
    bool IsLookingAtObject(Transform looker, Vector3 targetPos, float FOVAngle)    {
 
         Vector3 direction = targetPos - looker.position;
         float ang = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
         float lookerAngle = looker.eulerAngles.z;
         float checkAngle = 0f;
 
         if (ang >= 0f )
             checkAngle = ang - lookerAngle - 90f;
         else if (ang < 0f )
             checkAngle = ang - lookerAngle + 270f;
         
         if (checkAngle < -180f )
             checkAngle = checkAngle  + 360f;
 
         if (checkAngle <= FOVAngle*.5f && checkAngle >= -FOVAngle*.5f)
             return true;
         else
             return false;
     }
}

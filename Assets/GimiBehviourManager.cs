using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimiBehviourManager : MonoBehaviour
{
    private float distance;
    private float time = 0.0f;
    private float startsleeptime = 0f;
    public Transform HDM;
    public float transitionSpeedToStart = 3.0f;
    public Transform AnimationStart;
    public Transform IntervalStart;
    public int IntimateDistance=2;
    public int SocialDistance = 3;

    private bool? currentRunningBehavior; // null=animation True=stalking False=inteval

    // Start is called before the first frame update
    void Start()
    {
        currentRunningBehavior = null;
    }

    // Update is called once per frame
    void Update()
    {
        distance = (float)Vector3.Distance(this.transform.position, HDM.position);
        if (distance >= SocialDistance)//animation distance
        {
            Debug.Log("if animation pass");
            enableAndDisableScripts(null);
            return;
        }
        
        if(distance > IntimateDistance && distance < SocialDistance)//interval distance
        {
            Debug.Log("if interval pass");
            enableAndDisableScripts(false);
            return;
        }
        if(distance <= IntimateDistance)
        {
            Debug.Log("if stalker pass");
            enableAndDisableScripts(true);//stalking distace
            return;
        }
    }

    void SmoothLookAt(Vector3 newDirection, float speed,float startMovementTime)
    {
        time += Time.deltaTime;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(newDirection - transform.position), Time.deltaTime * speed);
        if (time <= (startsleeptime+2f))
        {
            //transform.LookAt(startPoint);
        }
    }

    void enableAndDisableScripts(bool? wantedState)
    {
        if (currentRunningBehavior == wantedState)
        {
            Debug.Log("same state");
            return;
        }
        if (wantedState == null)
        {
            Debug.Log("animation activate");
            SmoothLookAt(AnimationStart.position, transitionSpeedToStart,Time.deltaTime);
            this.GetComponent<GimiStalker>().enabled = false;
            this.GetComponent<GimiInterval>().enabled = false;
            this.GetComponent<Animator>().enabled = true;
            this.GetComponent<GimiLookatToAnimation>().enabled = true;
            currentRunningBehavior = null;
            return;
        }
        if (wantedState == false)
        {
            Debug.Log("interval activate");
            SmoothLookAt(IntervalStart.position, transitionSpeedToStart, Time.deltaTime);
            this.GetComponent<GimiStalker>().enabled = false;
            this.GetComponent<GimiInterval>().enabled = true;
            this.GetComponent<Animator>().Play ("AmitGimi animation", -1 ,normalizedTime: -0.1f);
            this.GetComponent<Animator>().enabled = false;
            this.GetComponent<GimiLookatToAnimation>().enabled = false;
            currentRunningBehavior = false;
            return;
        }
        if (wantedState == true)
        {
            Debug.Log("stalking activate");
            
            SmoothLookAt(HDM.transform.position, transitionSpeedToStart, Time.deltaTime);
            this.GetComponent<GimiStalker>().enabled = true;
            this.GetComponent<GimiInterval>().enabled = false;
            this.GetComponent<Animator>().enabled = false;
            this.GetComponent<GimiLookatToAnimation>().enabled = false;
            currentRunningBehavior = true;
            return;
        }
        

    }
}

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
    public double IntimateDistance = 1;
    public double SocialDistance = 3;
    public double bufferDistance = 0.5;
    private bool bufferBool = false;
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
        //        Debug.Log("distance is : " + distance);
        if (distance >= SocialDistance + bufferDistance)//animation distance
        {
            Debug.Log("if animation pass");
            enableAndDisableScripts(null);
            return;
        }

        if (distance > IntimateDistance + bufferDistance && distance < SocialDistance - bufferDistance)//interval distance
        {
            Debug.Log("if interval pass");
            enableAndDisableScripts(false);
            return;
        }
        if (distance <= IntimateDistance - bufferDistance)
        {
            Debug.Log("if stalker pass");
            enableAndDisableScripts(true);//stalking distace
            return;
        }
        else
        {
            Debug.Log("_____In Buffer__________");
            if (currentRunningBehavior == null)
            {
                SmoothLookAt(AnimationStart.position, transitionSpeedToStart, Time.deltaTime);
                Debug.Log("_______looking to animation___________");
            }
            if (currentRunningBehavior == true) { SmoothLookAt(HDM.position, transitionSpeedToStart, Time.deltaTime); }

            this.GetComponent<GimiInterval>().enabled = false;
            this.GetComponent<Animator>().enabled = false;
            this.GetComponent<GimiStalker>().enabled = false;
            this.GetComponent<Animator>().Play("AmitGimi animation", -1, normalizedTime: 0.0f);
            bufferBool = true;

        }
    }

    void SmoothLookAt(Vector3 newDirection, float speed, float startMovementTime)
    {
        time += Time.deltaTime;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(newDirection - transform.position), Time.deltaTime * speed);
        if (time <= (startMovementTime + 3f))
        {
            //transform.LookAt(startPoint);
        }
    }

    void enableAndDisableScripts(bool? wantedState)
    {
        if (currentRunningBehavior == wantedState && !bufferBool)
        {
            //Debug.Log("same state");
            return;
        }
        if (wantedState == null)
        {
            //Debug.Log("animation activate");
            SmoothLookAt(AnimationStart.position, transitionSpeedToStart, Time.deltaTime);
            this.GetComponent<GimiStalker>().enabled = false;
            this.GetComponent<GimiInterval>().enabled = false;

            //this.GetComponent<GimiLookatToAnimation>().enabled = true;
            this.GetComponent<Animator>().enabled = true;
            bufferBool = false;
            currentRunningBehavior = null;
            return;
        }
        if (wantedState == false)
        {
            //Debug.Log("interval activate");
            this.GetComponent<GimiStalker>().enabled = false;
            this.GetComponent<Animator>().Play("AmitGimi animation", -1, normalizedTime: 0.0f);
            this.GetComponent<Animator>().enabled = false;
            //this.GetComponent<GimiLookatToAnimation>().enabled = false;
            SmoothLookAt(IntervalStart.position, transitionSpeedToStart, Time.deltaTime);
            this.GetComponent<GimiInterval>().enabled = true;
            currentRunningBehavior = false;
            bufferBool = false;
            return;
        }
        if (wantedState == true)
        {
            //Debug.Log("stalking activate");
            this.GetComponent<GimiInterval>().enabled = false;
            this.GetComponent<Animator>().enabled = false;
            this.GetComponent<Animation>().enabled = false;
            //this.GetComponent<GimiLookatToAnimation>().enabled = false;
            SmoothLookAt(HDM.transform.position, transitionSpeedToStart, Time.deltaTime);
            this.GetComponent<GimiStalker>().enabled = true;
            currentRunningBehavior = true;
            bufferBool = false;
            return;
        }


    }
}

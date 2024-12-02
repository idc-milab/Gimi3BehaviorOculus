using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GimiBehavior : MonoBehaviour {

	public PlayableDirector currTimeline;
	public float threshhold; //trigger pf movement
	public float stoppingPoint; //end of movement


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		currTimeline.Evaluate();
		float distance = GetDistanceFromGimi ();
		if (distance < threshhold && distance > stoppingPoint) {
//			currTimeline.Play ();
			SetAnimationTime (distance - stoppingPoint);
		}
	}

	public float GetDistanceFromGimi () {
		float distance = Vector3.Distance(this.transform.position, Camera.main.transform.position);
		return distance;
	}

	public void SetAnimationTime (float distance) {
		float distanceAnimation = threshhold - stoppingPoint; 
		float targetTime = (distanceAnimation - distance) / distanceAnimation * (float)currTimeline.duration;
		currTimeline.time = targetTime;
	}	
}

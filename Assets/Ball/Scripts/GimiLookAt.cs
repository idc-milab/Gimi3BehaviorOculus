using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimiLookAt : MonoBehaviour {

	public float speed;
	public int toggle;
	public Transform target;
	private bool look;
	private Quaternion rotation;
	private Vector3 targetPos;
	public object player;

	private Vector3 targetPosition;
	private int startAnimation;
	private Vector3 toggle1Position;
	public float threshhold; //trigger of movement
	public float t;
	private float startTime;
	public Transform smallSphere;

    void Start() => player = player;

    void Update () {
		if (toggle == 1)
			LookAt ();
		if (toggle == 2)
			LookAt ();
	}

	/*void OnTriggerEnter(Collider other){

		if (other.gameObject.CompareTag ("Player")) {
			if (!player.m_IsWalking && toggle == 2)
				speed = 5;
			look = true;
			Debug.Log(gameObject.tag + " entered Trigger tagged " + other.gameObject.tag + " and look is " + look);
			if (toggle == 1) {
				toggle1Position = (target.position - transform.position);
				toggle1Position = new Vector3 (targetPosition.x, targetPosition.y + 0.5f, targetPosition.z);
			}
		}
	}*/

	void OnTriggerExit(Collider other){

		if (other.gameObject.CompareTag("Player")){
			if(toggle != 1)
				look = false;
			speed = 1;
		}
	}

	void LookAt(){
		if (toggle != 1) {
			targetPosition = (target.position - transform.position);
			targetPosition = new Vector3 (targetPosition.x, targetPosition.y + 3f, targetPosition.z);
		} else
			targetPosition = toggle1Position;
		if (look) {
			rotation = Quaternion.LookRotation (targetPosition);
		} else if (!look ) {
			rotation = Quaternion.LookRotation (transform.position - target.position);
		}
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * speed);
	}
		
}
//
//
//	void Start (){
//		startTime = Time.time;
//	}
//
//	void Update () {
//		float distance = GetDistanceFromGimi ();
//
//		if (distance < threshhold) {
//			//Quaternion relativePos = Quaternion.LookRotation (transform.position - target.position); 
//			Quaternion relativePos = Quaternion.LookRotation (target.position);
//			t = (Time.time - startTime) / 1.0f;
//			transform.rotation = Quaternion.Slerp (transform.rotation, relativePos, t);	
//
//	}
//		
//	public float GetDistanceFromGimi () {
//		float distance = Vector3.Distance(this.transform.position, Camera.main.transform.position);
//		return distance;
//	}

//	void Start  (){
//		startTime = Time.time;
//		newHere = false;
//	}
//
//	void Update () {
//		float distance = GetDistanceFromGimi ();
//
//		if (distance < threshhold) {
//			if (!newHere) {
//				newHere = true;
//				startTime = Time.time;
//			}
//			//Quaternion relativePos = Quaternion.LookRotation (transform.position - target.position); 
//			Quaternion relativePos = Quaternion.LookRotation (target.position);
//			t = (Time.time - startTime) / 1.0f;
//			smallSphere.rotation = Quaternion.Slerp (transform.rotation, relativePos, t);
//			//transform.rotation = Quaternion.Slerp (transform.rotation, relativePos, t);	
//		} else {
//			newHere = false;
//		}
//	}
//
//	public float GetDistanceFromGimi () {
//		float distance = Vector3.Distance(this.transform.position, Camera.main.transform.position);
//		return distance;
//	}
//
//
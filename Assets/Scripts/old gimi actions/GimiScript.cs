using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimiScript : MonoBehaviour {

	Animation anim;
//	int gimiMovement = Animator.StringToHash("ArmatureAction");
	public Transform target;
	public float speed;
	private bool look;
	private Quaternion rotation;

	void Start () {

	}
	
	void Update () {
		
//		transform.LookAt(target);
//		if (look) {
//			rotation = Quaternion.LookRotation (target.position - transform.position);
//		} else if (!look) {
//			rotation = Quaternion.LookRotation (transform.position - target.position);
//		}
//		Debug.Log (target.position);
//		Debug.Log (transform.position);
//
//		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * speed);
//		Vector3 rotate = transform.rotation.eulerAngles;
//		rotate.x = 0;
//		rotate.z = 0;
//		rotate.y = 10;
//		transform.rotation = Quaternion.Euler (rotate);

	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag("Player")){
//			Debug.Log(gameObject.tag + " entered Trigger tagged " + other.gameObject.tag);
//			anim.SetTrigger (gimiMovement);
//			Debug.Log (target.position);
//			Debug.Log (transform.position);
//			rotation = Quaternion.LookRotation (target.position - transform.position);
//			Vector3 rotate = transform.rotation.eulerAngles;
//			rotate.x = 0;
//			rotate.z = 0;
////			rotate.y = 10;
//			transform.rotation = Quaternion.Euler (rotate);
//			anim.Play();
			look = true;

		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.CompareTag("Player")){
			//			Debug.Log(gameObject.tag + " entered Trigger tagged " + other.gameObject.tag);
			//			anim.SetTrigger (gimiMovement);
//			anim.Rebind();
			look = false;

		}
	}
}

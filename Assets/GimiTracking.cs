using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimiTracking : MonoBehaviour {

	public float speed;
	public int toggle;
	public Transform target;
	private bool look;
	private Quaternion rotation;
	private Vector3 targetPos;
	public object player;
	//	public FirstPersonController other;

	//	CharacterController player;
	private Vector3 targetPosition;
	private int startAnimation;
	private Vector3 toggle1Position;
    //	private Animator anim;

    //	private AudioSource audio;

    void Start() =>
        //		audio = GetComponent<AudioSource> ();
        // find the current instance of the player script:
        //		anim = GetComponent<Animator> ();
        //		player = GetComponent<CharacterController>();
        player = player;//		player = GameObject.Find("FPSController").GetComponent<FirstPersonController>();//		rotation = Quaternion.LookRotation (transform.position - target.position);//		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * speed);

    void Update () {
		if (toggle == 1)
			LookAt ();
		//			if(startAnimation)
		//			LookAt ();

		//			//				targetPosition = new Vector3 (targetPosition.x, targetPosition.y + 3f, targetPosition.z);
		//			targetPosition = (target.position - transform.position);
		//			targetPosition = new Vector3 (targetPosition.x, targetPosition.y + 3f, targetPosition.z);
		//
		//			transform.rotation = Quaternion.Euler(targetPosition.x, targetPosition.y, targetPosition.z);
		//			toggle = 0;

		//			if (look) {
		////				toggle = 0;
		//				//				float step = speed * Time.deltaTime;
		//				transform.rotation = Quaternion.Slerp (transform.position, Quaternion.Euler(targetPosition), Time.deltaTime * speed);
		//			}
		//		}
		if (toggle == 2)
			LookAt ();
		//		targetPosition = (target.position - transform.position);
		//		targetPosition = new Vector3 (targetPosition.x, targetPosition.y + 3f, targetPosition.z);
		//
		//		if (look) {
		//			rotation = Quaternion.LookRotation (targetPosition);
		//		} else if (!look ) {
		//			rotation = Quaternion.LookRotation (transform.position - target.position);
		//		}
		//
		//		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * speed);
		//		Vector3 rotate = transform.rotation.eulerAngles;
		//		rotate.x = rotate.x + -35.0f;
		//		transform.rotation = Quaternion.Euler (rotate);

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

			//				anim.Play("ArmatureAction");
			//				startAnimation = true;
			//			if (!audio.isPlaying)
			//				audio.Play ();


		}
	}*/

	void OnTriggerExit(Collider other){

		if (other.gameObject.CompareTag("Player")){
			if(toggle != 1)
				look = false;
			speed = 1;
			//			audio.Stop ();
			//			Debug.Log(gameObject.tag + " entered Trigger tagged " + other.gameObject.tag + " and look is " + look);

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

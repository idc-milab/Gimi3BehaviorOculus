using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour {

//	// Use this for initialization
//	void Start () {
//		
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		
//	}


	// simple lerp up and down movement
	Transform targeti;
	Transform targetu;
	float moveSpeed = 0.7f;
	float upMaxDistance = 0.0f;
	AudioClip openCloseSound;
	private Vector3 initPositioni;
	private Vector3 initPositionu;
	private bool openDoor = false;

	void Start() {
		initPositioni = targeti.position;
		initPositionu = targetu.position;
	}

	void Update () {
		if (!targeti) {
			return;
		}
		if (!targetu) {
			return;
		}
		if (openDoor == true) {
//			transform.position = new Vector3 (transform.position.x, 0, transform.position.z);
			targeti.position = new Vector3 (targeti.position.x, targeti.position.y, Mathf.Min(upMaxDistance, targeti.position.z+moveSpeed * Time.deltaTime));

//			targeti.position.z = Mathf.Min(upMaxDistance, targeti.position.z+moveSpeed * Time.deltaTime);
			targetu.position = new Vector3 (targeti.position.x, targeti.position.y, Mathf.Max(upMaxDistance, targetu.position.z-moveSpeed * Time.deltaTime));

//			targetu.position.z = Mathf.Max(upMaxDistance, targetu.position.z-moveSpeed * Time.deltaTime);
		}
		else {
			targeti.position = new Vector3 (targeti.position.x, targeti.position.y, Mathf.Max(initPositioni.z, targeti.position.z-moveSpeed * Time.deltaTime));

//			targeti.position.z = Mathf.Max(initPositioni.z, targeti.position.z-moveSpeed * Time.deltaTime);
			targetu.position = new Vector3 (targeti.position.x, targeti.position.y, Mathf.Min(initPositionu.z, targetu.position.z+moveSpeed * Time.deltaTime));

//			targetu.position.z = Mathf.Min(initPositionu.z, targetu.position.z+moveSpeed * Time.deltaTime);
		}
	}

	IEnumerator OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			yield return new WaitForSeconds (1);
			openDoor = true;  
//		audio.PlayOneShot(openCloseSound);
		}
	}

	IEnumerator OnTriggerExit(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			yield return new WaitForSeconds (1);
			openDoor = false;  
//		audio.PlayOneShot(openCloseSound);
		}
	}
}



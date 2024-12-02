using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimiAwake : MonoBehaviour {

//	public float speed;

//	private Rigidbody rb;

//	void Start ()
//	{
//		rb = GetComponent<Rigidbody>();
//	}


	void OnTriggerEnter(Collider other){
		AudioSource audio = GetComponent<AudioSource> ();
//		GameObject gimi = GameObject.Find("Gimi");
		Debug.Log(gameObject.tag + " entered Trigger tagged " + other.gameObject.tag);
		if (!audio.isPlaying && other.gameObject.CompareTag("Gimi")){
			audio.Play();
		}
	}
}


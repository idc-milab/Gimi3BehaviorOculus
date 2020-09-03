using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost_movement : MonoBehaviour {

    public GameObject Gimi;
    public float currnetDistance;
    public float threshold;
    public float deltaDistance;
    public GameObject player;
    public Vector3 originalposition;
    float prevDistance;
    bool forward;
    // Use this for initialization
    void Start () {
        originalposition = transform.position;
    }

    // Update is called once per frame
    void Update () {
        prevDistance = currnetDistance;
        currnetDistance = GetDistanceFromGimi();
        forward = currnetDistance < prevDistance;
        if (currnetDistance > threshold && currnetDistance != prevDistance) {
            if (!forward) {
                deltaDistance = (threshold - currnetDistance) * Time.deltaTime;
                transform.position += new Vector3(0, deltaDistance, 0);
            } else {
                deltaDistance = (currnetDistance - threshold) * Time.deltaTime;
                transform.position += new Vector3(0, deltaDistance, 0);
            }
        } else if (currnetDistance < threshold) {
            transform.position = player.transform.position;
        }
	}

    public float GetDistanceFromGimi() {
        float distance = Vector3.Distance(Gimi.transform.position, player.transform.position);
        return distance;
    }
}

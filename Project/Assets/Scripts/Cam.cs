using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour {

    public Transform player;

	// Use this for initialization
	void Start () {
        transform.position = player.position - new Vector3(0, 0, 10);
    }

    // Update is called once per frame
    void LateUpdate () {
        transform.position = player.position - new Vector3(0, 0, 10);
    }
}

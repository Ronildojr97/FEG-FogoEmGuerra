using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceRotation : MonoBehaviour {

    private Camera cam;
	// Use this for initialization
	void Start () {
		
	}
    private void Awake()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update () {
		transform.LookAt(transform.position + cam.transform.rotation * Vector3.forward, cam.transform.rotation * Vector3.up);
	}
}

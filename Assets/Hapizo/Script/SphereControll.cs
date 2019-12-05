using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereControll : MonoBehaviour {

	GameObject getCamera;
	look cameraPos;
	Vector3 cameraPosF;

	// Use this for initialization
	void Start () {
		getCamera = GameObject.FindGameObjectWithTag( "MainCamera" );
	}
	
	// Update is called once per frame
	void Update () {
		cameraPos = getCamera.GetComponent<look>();
		cameraPosF = cameraPos.Camerafoward;
		this.gameObject.transform.position = cameraPosF;
	}
}

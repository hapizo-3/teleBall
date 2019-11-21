using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveScript : MonoBehaviour {

	public Vector3 forward;
	public Quaternion q;

	// Use this for initialization
	void Start () {
		forward = transform.forward;
		q = this.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log( "x/" + forward.x + " , y/" + forward.y + " ,z/" + forward.z 
						+ "\n               ,qx/" + q.x + " ,qy/" + q.y + " ,qz/" + q.z );
		this.gameObject.transform.position += this.gameObject.transform.forward * Time.deltaTime;
		//this.gameObject.transform.position += Vector3.forward * Time.deltaTime;
	}
}

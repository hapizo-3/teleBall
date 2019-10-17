using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	//float rotateSpeed = 0.0f;
	public float speed = 15f;

	// Use this for initialization
	//void Start () {

	//}

	// Update is called once per frame
	void Update() {

		var velox = speed * Input.GetAxisRaw( "Horizontal" );
		GetComponent<Rigidbody>().velocity = new Vector3( velox, 0f, 0f );

		//transform.position = new Vector3(

		//	transform.position.x + Input.GetAxis( "Horizontal" ),
		//	0 + 1.125f,
		//	transform.position.z + Input.GetAxis( "Vertical" )
		//);

		//rotateSpeed = 0.0f;

		//if( Input.GetKey( "right" ) )
		//{
		//	rotateSpeed = 5.0f;
		//}

		//if( Input.GetKey( "left" ) )
		//{
		//	rotateSpeed = -5.0f;
		//}

		//transform.Rotate( 0, rotateSpeed, 0 );

	}
}

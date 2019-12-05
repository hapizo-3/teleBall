using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleballCollisionEx : MonoBehaviour {

	[SerializeField] public float aimThrowSize;
	[SerializeField] public float keyThrowSize;

	public GameObject teleportParticle;

	GameObject playerObject;
	PlayerMove pObject;

	Vector3 CameraForward;

	Rigidbody rbs;

	float throwSize;

	// Use this for initialization
	void Start () {
		//Debug.Log( "teleballStart : " + Time.frameCount );
		rbs = GetComponent<Rigidbody>();
		playerObject = GameObject.FindGameObjectWithTag( "Player" );
		Transform CameraTransform = GameObject.FindGameObjectWithTag( "MainCamera" ).transform;

		if( Input.GetMouseButtonDown( 0 ) )
		{
			CameraForward = CameraTransform.transform.forward;
			throwSize = aimThrowSize;
		} 
		else if( Input.GetKeyDown( KeyCode.A ) )
		{
			CameraForward = -CameraTransform.transform.right;
			throwSize = keyThrowSize;
		} 
		else if( Input.GetKeyDown( KeyCode.D ) )
		{
			CameraForward = CameraTransform.transform.right;
			throwSize = keyThrowSize;
		} 
		else if( Input.GetKeyDown( KeyCode.S ) )
		{
			CameraForward = -CameraTransform.transform.forward;
			throwSize = keyThrowSize;
		}

		CameraForward.x *= throwSize;
		CameraForward.y *= throwSize;
		CameraForward.z *= throwSize;

		//投げる処理
		rbs.AddForce( CameraForward.x, CameraForward.y, CameraForward.z, ForceMode.Impulse );
		throwSize = 0;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter( Collision other )
	{
		float x = this.gameObject.transform.position.x;
		float y = this.gameObject.transform.position.y;
		float z = this.gameObject.transform.position.z;

		Quaternion q = Quaternion.Euler( -90f, 0f, 0f );

		if( other.gameObject.tag == "Ground" )
		{
			pObject = playerObject.GetComponent<PlayerMove>();
			pObject.GetTeleballPosition( x, y, z, other.gameObject );
			pObject.DisplayCollisionObject( other.gameObject );

			Instantiate( teleportParticle, new Vector3( x, y, z ), Quaternion.identity * q );
			Destroy( this.gameObject );
		}

	}
}

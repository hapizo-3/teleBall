using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Const;

public class teleBallCollision : MonoBehaviour {

	public GameObject teleportParticle;
	public look lk;

	public GameObject playerObject;
	PlayerMove pObject;

	public float moveSize = 5;

	void Start()
	{

		playerObject = GameObject.FindGameObjectWithTag( "Player" );

		Rigidbody rbs = GetComponent<Rigidbody>();

		Transform PlayerT = GameObject.FindGameObjectWithTag( "Player" ).transform;
		Transform CameraT = GameObject.FindGameObjectWithTag( "MainCamera" ).transform;

		Vector3 CameraForward = CameraT.transform.position - CameraT.transform.forward;
		Vector3 CameraNorm = CameraT.transform.forward;

		Debug.Log( CameraNorm );

		CameraNorm.x *= 40;
		CameraNorm.y *= 40;
		CameraNorm.z *= 40;

		Vector3 PlayerR = PlayerT.eulerAngles;
		Vector3 CameraR = CameraT.eulerAngles;

		float PlayerHor = CameraR.x;
	//Debug.Log( PlayerHor );
		float PlayerVec = PlayerR.y;

		if( PlayerHor >= 180 )
		{
			PlayerHor = PlayerHor - 360;
		}

		float radRY = PlayerHor * Const.CO.PI / 180;
		float radRX = PlayerVec * Const.CO.PI / 180;

		float radY = Mathf.Sin( radRY );

		float sinX = Mathf.Sin( radRX );
		float cosZ = Mathf.Cos( radRX );

		//絶対値取得
		float absX = Mathf.Abs( sinX );
		float absY = Mathf.Abs( radY );
		float absZ = Mathf.Abs( cosZ );

		//Yの傾いている差分を求める
		float difX = absY - absX;
		float difZ = absY - absZ;

		difX = Mathf.Abs( difX );
		difZ = Mathf.Abs( difZ );

		float py = moveSize * radY;

		float px = moveSize * sinX;
		float pz = moveSize * cosZ;

		//float 
		//Debug.Log( "x/ " + sinX + "y/ " + radY + "z/ " + cosZ );

		//rbs.AddForce( px, -py, pz, ForceMode.Impulse );
		rbs.AddForce( CameraNorm.x, CameraNorm.y, CameraNorm.z, ForceMode.Impulse );
	}

	void Update()
	{
		Rigidbody rb = GetComponent<Rigidbody>();
		//rb.AddForce( 0, 4, 2, ForceMode.Acceleration );
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
			//pObject.GetTeleballPosition( x, y, z );

			Instantiate( teleportParticle, new Vector3( x, y, z ), Quaternion.identity * q );
			Destroy( this.gameObject );
		}

	}

}

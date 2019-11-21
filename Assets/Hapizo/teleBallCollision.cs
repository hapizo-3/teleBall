using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Const;

public class teleBallCollision : MonoBehaviour {

	public GameObject teleportParticle;
	public look lk;

	float rx = 0;
	float ry = 0;
	float rz = 0;

	void Start()
	{
		Rigidbody rbs = GetComponent<Rigidbody>();

		Transform PlayerT = GameObject.FindGameObjectWithTag( "Player" ).transform;
		Transform CameraT = GameObject.FindGameObjectWithTag( "MainCamera" ).transform;

		Vector3 PlayerR = PlayerT.eulerAngles;
		Vector3 CameraR = CameraT.eulerAngles;

		float PlayerHor = CameraR.x;
		float PlayerVec = PlayerR.y;

		if( PlayerHor >= 180 )
		{
			PlayerHor = PlayerHor - 360;
		}

		float radRY = PlayerHor * Const.CO.PI / 180;
		float radRX = PlayerVec * Const.CO.PI / 180;

		float radY = Mathf.Sin( radRY );

		float sinX = Mathf.Sin( radRX );
		float cosY = Mathf.Cos( radRX );

		float py = 30 * radY;

		float px = 30 * sinX;
		float pz = 30 * cosY;

		rbs.AddForce( px, -py, pz, ForceMode.Impulse );
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
		//float rx = other.gameObject.transform.eulerAngles.x;
		//float ry = other.gameObject.transform.eulerAngles.y;
		//float rz = other.gameObject.transform.eulerAngles.z;
		//Quaternion rq = Quaternion.Euler( x, y, z );

		Quaternion q = Quaternion.Euler( -90f, 0f, 0f );

		//回転取得のためのTransform取得
		//Transform CameraR = GameObject.FindGameObjectWithTag( "MainCamera" ).transform;
		//Transform PlayerR = 
		
		//回転取得のためのVector3取得
		//Vector3 CameraRV = CameraR.eulerAngles;
		//Vector3 PlayerRV = PlayerR.eulerAngles;

		//回転取得
		//float PlayerRX = CameraRV.x;
		//float PlayerRY = PlayerRV.y;

		//弧度法変換
		//float radRY = PlayerRY * Const.CO.PI / 180;
		//Debug.Log( radRY );

		//正弦・余弦変換
		//float cosX = Mathf.Cos( radRY );
		//float sinY = Mathf.Sin( radRY );

		//座標取得
		//float px = 20 * cosX /*-( Const.CO.PI / 2 )*/ ;
		//float pz = 20 * -( sinY ) * ( Const.CO.PI / 2 );

		if( other.gameObject.tag == "Ground" )
		{
			Instantiate( teleportParticle, new Vector3( x, y, z ), Quaternion.identity * q );
			//Instantiate( teleportParticle, new Vector3( px, y, pz ), Quaternion.identity * q );
			Destroy( this.gameObject );
		}

	}

}

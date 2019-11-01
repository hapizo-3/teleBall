using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Const;

public class teleBallCollision : MonoBehaviour {

	public GameObject teleportParticle;
	//public GameObject playertmp;
	//public int frame;
	public look lk;

	void Start()
	{
		Rigidbody rbs = GetComponent<Rigidbody>();
		rbs.AddForce( 0, 0.5f, 30, ForceMode.Impulse );
	}

	void Update()
	{
		Rigidbody rb = GetComponent<Rigidbody>();

		rb.AddForce( 0, 4, 2, ForceMode.Acceleration );
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
		//Transform PlayerR = GameObject.FindGameObjectWithTag( "Player" ).transform;
		
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
	
	public float speed = 15f;
	public float teleportSpeed = 30f;

	public Vector3 playerPosition;
	Rigidbody playerRb;

	GameObject gmObject;
	GameManager gManager;

	Collider Pcollider;

	Vector3 nowPosition;

	[SerializeField] GameObject teleportParticle;
	Quaternion q = Quaternion.Euler( -90f, 0f, 0f );

	float teleBallX = 0;
	float teleBallY = 0;
	float teleBallZ = 0;
	bool teleportFlag = false;

	int i = 0;
	public int j = 30;

	float distance = 0;

	void Start()
	{
		playerRb = this.transform.GetComponent<Rigidbody>();
		gmObject = GameObject.FindGameObjectWithTag( "GameManager" );
		FlyPlayer();
	}

	void Update() {
		gManager = gmObject.GetComponent<GameManager>();

		if( gManager.teleMove == true )
		{
			GetComponent<Collider>().enabled = false;
			this.gameObject.transform.position = Vector3.MoveTowards( this.gameObject.transform.position, gManager.afterTeleport, Time.deltaTime * teleportSpeed );
			distance = Vector3.Distance( this.gameObject.transform.position, gManager.afterTeleport );
			if( distance == 0 )
			{
				gManager.teleMove = false;
				GetComponent<Collider>().enabled = true;

				Instantiate( teleportParticle, new Vector3( this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z ), Quaternion.identity * q );
			}
			Debug.Log( gManager.teleMove );
		}
	}
	
	public void GetTeleballPosition( float x, float y, float z, GameObject otherObject )
	{
		teleBallX = x;
		teleBallY = y;
		teleBallZ = z;

		nowPosition = this.gameObject.transform.position;
		
		teleportFlag = true;
		SetTeleportPlayer( teleBallX, teleBallY, teleBallZ, otherObject );
		Debug.Log( "true" );
	}

	void SetTeleportPlayer( float X, float Y, float Z, GameObject otherObject  )
	{
		float difX = 0;
		float difY = 0;
		float difZ = 0;
		if( otherObject.transform.eulerAngles.x == 90 )
		{
			difZ = -4.0f;
		}
		else if( otherObject.transform.eulerAngles.x == 270 )
		{
			difZ = 10.0f;
		}
		else if( otherObject.transform.eulerAngles.z == 90 )
		{
			difX = -2.0f;
		}
		else if( otherObject.transform.eulerAngles.z == 270 )
		{
			difX = 2.0f;
		}

		if( otherObject.transform.eulerAngles.x == 180 || otherObject.transform.eulerAngles.z == 180 )
		{
			difY = -2.17f;
		}
		else if( otherObject.transform.eulerAngles.x == 0 || otherObject.transform.eulerAngles.z == 0 )
		{
			difY = 2.17f;
		}

		playerPosition = this.gameObject.transform.position;
		playerPosition.x = X + difX;
		playerPosition.y = Y + difY;
		playerPosition.z = Z + difZ;
		this.gameObject.transform.position = playerPosition;
	}

	public void DisplayCollisionObject( GameObject otherObject )
	{
		Debug.Log( otherObject.transform.eulerAngles );
	}

	void FlyPlayer()
	{

		//playerRb.velocity = new Vector3( 20, 0, 0 );

	}

	void FreezeCancel()
	{
		playerRb.constraints = RigidbodyConstraints.None;
		playerRb.constraints = RigidbodyConstraints.FreezeRotation;
	}

	void FreezeApply()
	{
		playerRb.constraints = RigidbodyConstraints.FreezePositionX;
		playerRb.constraints = RigidbodyConstraints.FreezePositionZ;
	}

}
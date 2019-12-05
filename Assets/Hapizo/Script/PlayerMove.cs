using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
	
	public float speed = 15f;

	public Vector3 playerPosition;

	private float teleBallX = 0;
	private float teleBallY = 0;
	private float teleBallZ = 0;
	private bool teleportFlag = false;

	void Update() {
		//var velox = speed * Input.GetAxisRaw( "Horizontal" );
		//GetComponent<Rigidbody>().velocity = new Vector3( velox, 0f, 0f );
		if( teleportFlag == true )
		{
			//SetTeleportPlayer();
			teleportFlag = false;
		}
	}

	public void GetTeleballPosition( float x, float y, float z, GameObject otherObject )
	{
		teleBallX = x;
		teleBallY = y;
		teleBallZ = z;
		teleportFlag = true;
		SetTeleportPlayer( teleBallX, teleBallY, teleBallZ, otherObject );
	}

	void SetTeleportPlayer( float X, float Y, float Z, GameObject otherObject  )
	{
		float difX = 0;
		float difY = 0;
		float difZ = 0;
		if( otherObject.transform.eulerAngles.x == 90 )
		{
			difZ = -2.0f;
		}
		else if( otherObject.transform.eulerAngles.x == 270 )
		{
			difZ = 2.0f;
		}
		else if( otherObject.transform.eulerAngles.z == 90 )
		{
			difX = -2.0f;
		}
		else if( otherObject.transform.eulerAngles.z == 270 )
		{
			difX = 2.0f;
		}

		difY = 2.17f;

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

}

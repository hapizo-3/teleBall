using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportPlayer : MonoBehaviour {

	public Vector3 playerPosition;
	public GameObject teleport;

	private float teleBallX = 0;
	private float teleBallY = 0;
	private float teleBallZ = 0;

	// Use this for initialization
	void Start () {
		teleport = GameObject.FindGameObjectWithTag( "teleBall" );
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GetTeleballPosition( float x, float y, float z )
	{
		teleBallX = x;
		teleBallY = y;
		teleBallZ = z;
		SetTeleportPlayer();
	}

	void SetTeleportPlayer()
	{
		playerPosition = this.gameObject.transform.position;
		playerPosition.x = teleBallX;
		playerPosition.y = teleBallY;
		playerPosition.z = teleBallZ;

		teleBallX = 0;
		teleBallY = 0;
		teleBallZ = 0;
	}
}

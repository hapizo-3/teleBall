using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class look : MonoBehaviour {

	public Transform verRot;
	public Transform horRot;
	public float sensitivity = 0.1f;
	public GameObject GManagerObject;
	GameManager gManager;

	// Use this for initialization
	void Start()
	{
		verRot = transform.parent;
		horRot = GetComponent<Transform>();
		GManagerObject = GameObject.FindGameObjectWithTag( "GameManager" );
	}

	// Update is called once per frame
	void Update()
	{
		gManager = GManagerObject.GetComponent<GameManager>();

		if( gManager.wasLocked == true )
		{
			float X_Rotation = Input.GetAxis( "Mouse X" ) * sensitivity;
			float Y_Rotation = Input.GetAxis( "Mouse Y" ) * sensitivity;
			verRot.transform.Rotate( 0, -X_Rotation, 0 );
			horRot.transform.Rotate( Y_Rotation, 0, 0 );
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class look : MonoBehaviour {

	public Transform verRot;
	public Transform horRot;
	public float sensitivity = 0.1f;
	public GameObject GManagerObject;
	GameManager gManager;
	GlitchFx glitch;
	Vector3 roteuler;
	public float horPlusRot;
	public Vector3 Camerafoward;

	int teleportTime = 0;
	float glitchSize = 0.3f;

	// Use this for initialization
	void Start()
	{
		verRot = transform.parent;
		horRot = GetComponent<Transform>();
		GManagerObject = GameObject.FindGameObjectWithTag( "GameManager" );
		glitch = this.transform.GetComponent<GlitchFx>();
	}

	// Update is called once per frame
	void Update()
	{
		gManager = GManagerObject.GetComponent<GameManager>();
		Camerafoward = this.gameObject.transform.position + this.gameObject.transform.forward;
		//glitch.intensity += 0.001f;

		if( gManager.wasLocked == true )
		{
			if( Input.GetMouseButtonDown( 0 ) )
			{
				//Debug.Log( this.gameObject.transform.position + ", " + this.gameObject.transform.forward );
			}
			float X_Rotation = Input.GetAxis( "Mouse X" ) * sensitivity;
			float Y_Rotation = -( Input.GetAxis( "Mouse Y" ) * sensitivity );

			verRot.transform.Rotate( 0, X_Rotation, 0 );

			horPlusRot = horRot.transform.eulerAngles.x + Y_Rotation;
			if( horRot.transform.eulerAngles.x <= 95.0f && horPlusRot > 85.0f )
			{
				horPlusRot = 85.0f - horPlusRot;
				horRot.transform.Rotate( horPlusRot, 0, 0 );
			} else if( horRot.transform.eulerAngles.x >= 260 && horPlusRot < 275.0f )
			{
				horPlusRot = 275.0f - horPlusRot;
				horRot.transform.Rotate( horPlusRot, 0, 0 );
			}
			horRot.transform.Rotate( Y_Rotation, 0, 0 );
		}

		if( gManager.teleMove == true )
		{
			if( teleportTime == 0 )
			{
				glitch.intensity = glitchSize;
			}
			teleportTime++;
			glitch.intensity -= 0.004f;
		}
		else if( gManager.teleMove == false )
		{
			glitch.intensity = 0;
			teleportTime = 0;
			glitchSize = 0.2f;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject teleBall;
	public GameObject teleBallPrefab;

	GameObject getCamera;
	look cameraPos;
	Vector3 cameraPosF;

	public bool wasLocked = false;

	// Use this for initialization
	void Start () {
		//teleBallPrefab = ( GameObject )Prefab.Load( "teleBall" );
		getCamera = GameObject.FindGameObjectWithTag( "MainCamera" );

	}

	void MouseLock()
	{
		wasLocked = true;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.Locked;
	}

	void MouseLockCancel()
	{
		wasLocked = false;
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.None;
	}
	
	// Update is called once per frame
	void Update () {

		if( wasLocked == true && ( Input.GetMouseButtonDown( 0 ) || Input.GetKeyDown( KeyCode.A ) || Input.GetKeyDown( KeyCode.S ) || Input.GetKeyDown( KeyCode.D ) ) )
		{
			cameraPos = getCamera.GetComponent<look>();
			cameraPosF = cameraPos.Camerafoward;

			Vector3 tmp = GameObject.FindGameObjectWithTag( "Player" ).transform.position;
			Instantiate( teleBall, new Vector3( cameraPosF.x, cameraPosF.y, cameraPosF.z ), Quaternion.identity );
			//Debug.Log( "Instantiate : " + Time.frameCount );
		}

		if( wasLocked == false && Input.GetMouseButtonDown( 0 ) )
		{
			MouseLock();
		}

		if( wasLocked == true && Input.GetKeyDown( KeyCode.Escape ) )
		{
			MouseLockCancel();
		}
	}
}

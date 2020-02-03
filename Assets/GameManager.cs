using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject teleBall;
	public GameObject teleBallPrefab;

    GameObject getCamera;
	look cameraPos;
	GlitchFx glitch;
	Vector3 cameraPosF;

	public Vector3 beforeTelport;
	public Vector3 afterTeleport;

	public bool teleMove = false;
	float speed = 1f;

	public bool wasLocked = false;
	public bool gameGoal = false;
	public float time = 0;

    // Use this for initialization
    void Start () {
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
			Debug.Log( tmp );
			beforeTelport = tmp;
			Instantiate( teleBall, new Vector3( cameraPosF.x, cameraPosF.y, cameraPosF.z ), Quaternion.identity );
		}

		if( wasLocked == false && Input.GetMouseButtonDown( 0 ) )
		{
			MouseLock();
		}

		if( wasLocked == true && Input.GetKeyDown( KeyCode.Escape ) )
		{
			MouseLockCancel();
		}

		if( gameGoal == true )
		{
			time += Time.deltaTime;
			if( time >= 1.0f )
			{
				glitch = getCamera.GetComponent<GlitchFx>();
				glitch.intensity += 0.001f;
			}
		}
	} 
}

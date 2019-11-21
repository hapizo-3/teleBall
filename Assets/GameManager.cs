using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject teleBall;
	public bool wasLocked = false;

	// Use this for initialization
	//void Start () {

	//}

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

		if( wasLocked == true && Input.GetMouseButtonDown( 0 ) )
		{
			Vector3 tmp = GameObject.FindGameObjectWithTag( "Player" ).transform.position;
			Instantiate( teleBall, new Vector3( tmp.x, tmp.y, tmp.z ), Quaternion.identity );
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

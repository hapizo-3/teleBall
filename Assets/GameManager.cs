using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject teleBall;

	// Use this for initialization
	//void Start () {
		
	//}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetMouseButtonDown( 0 ) )
		{
			Vector3 tmp = GameObject.FindGameObjectWithTag( "Player" ).transform.position;
			Instantiate( teleBall, new Vector3( tmp.x, tmp.y, tmp.z ), Quaternion.identity );
		}
	}
}

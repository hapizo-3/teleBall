using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class overlapBoxEx : MonoBehaviour {

	// Update is called once per frame
	//void Update () {
		
	//}

	private void OnCollisionEnter( Collision other )
	{
		Collider[] collisions = Physics.OverlapBox( this.gameObject.transform.position, this.gameObject.transform.localScale/* * 2.0f*/ );
		Debug.Log( collisions[ 0 ].name );
		Debug.Log( collisions[ 1 ].name );
		Debug.Log( collisions[ 2 ].name );
		Debug.Log( collisions[ 3 ].name );
		Debug.Log( collisions[ 4 ].name );
		Debug.Log( collisions[ 5 ].name );
		Debug.Log( collisions[ 6 ].name );
	}
}

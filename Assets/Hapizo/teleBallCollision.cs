using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleBallCollision : MonoBehaviour {

	public GameObject teleportParticle;

	

	void OnCollisionEnter( Collision other )
	{
		float x = this.gameObject.transform.position.x;
		float y = this.gameObject.transform.position.y;
		float z = this.gameObject.transform.position.z;
		Quaternion q = Quaternion.Euler( -90f, 0f, 0f );
		if( other.gameObject.tag == "Ground" )
		{

			Instantiate( teleportParticle, new Vector3( x, y, z ), Quaternion.identity * q );
			Destroy( this.gameObject );
		}
	}
}

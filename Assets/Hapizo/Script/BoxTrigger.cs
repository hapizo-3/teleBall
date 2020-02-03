using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTrigger : MonoBehaviour {

	Vector3 overlapSize = new Vector3( 0, 0, 0 );

	// Use this for initialization
	void Start () {
		fixObjectPosition();
	}
	
	// Update is called once per frame
	void Update () {
		Collider[] collisions = Physics.OverlapBox( transform.position, GetComponent<BoxCollider>().size / 2.0f, transform.rotation );
		//Debug.Log( collisions.Length );
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.DrawWireCube( transform.position, GetComponent<BoxCollider>().size );
	}

	private void OnTriggerEnter( Collider other )
	{
		//fixObjectPosition();
	}

	void fixObjectPosition()
	{
		Vector3 thisScale = GetComponent<Transform>().localScale;
		float thisComp = GetComponent<Transform>().position.y + thisScale.y;
		Debug.Log( thisComp );
	}
}

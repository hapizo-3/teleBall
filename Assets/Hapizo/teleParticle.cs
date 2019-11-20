using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleParticle : MonoBehaviour {

	private int occureTime = 0;
	
	// Update is called once per frame
	void Update () {
		occureTime++;
		if( occureTime >= 180 )
		{
			Destroy( this.gameObject );
		}
	}
}

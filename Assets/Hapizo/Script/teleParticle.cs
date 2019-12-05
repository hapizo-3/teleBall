using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleParticle : MonoBehaviour {

	private int occureCount = 0;
	public int occureTime = 0;
	
	// Update is called once per frame
	void Update () {
		occureCount++;
		if( occureCount >= occureTime )
		{
			Destroy( this.gameObject );
		}
	}
}

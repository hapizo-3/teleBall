using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class overlapBoxEx : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		Debug.Log( GetComponent<Transform>().position );
	}
}

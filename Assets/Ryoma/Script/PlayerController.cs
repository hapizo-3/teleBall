using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤーを動かすテストスクリプトです。

public class PlayerController : MonoBehaviour {

    public float speed = 2.0f;
    private Rigidbody rB;

	// Use this for initialization
	void Start () {
        rB = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        rB.AddForce(x * speed, 0, z * speed, ForceMode.Impulse);
	}
}

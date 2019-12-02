using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour {

    Animator animator;

    // Use this for initialization
    void Start () {
        animator = this.gameObject.GetComponent<Animator>();
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            this.animator.SetTrigger("ThrowTrigger");
        }
	}
}

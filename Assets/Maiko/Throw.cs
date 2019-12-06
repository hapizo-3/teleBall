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
        }else if (Input.GetKeyDown(KeyCode.S))
        {
            this.animator.SetTrigger("ThrowBTrigger");
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            this.animator.SetTrigger("ThrowLTrigger");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            this.animator.SetTrigger("ThrowRTrigger");
        }

    }
}

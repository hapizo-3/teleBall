using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

    //ステージを移動させるフラグ
    int Fag = 0;
    
    [SerializeField] float initAnglesY = 0f;
    


	// Use this for initialization
	void Start () {
        gameObject.transform.eulerAngles += new Vector3(0f, initAnglesY, 0f);
    }
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.eulerAngles += new Vector3(0f, 0.5f, 0f);
        if (this.gameObject.transform.eulerAngles.y >= 350.0f ){
            Debug.Log(this.gameObject.transform.eulerAngles.y);
            this.gameObject.transform.eulerAngles = new Vector3(0f, initAnglesY, 0f);

        }
	}
}

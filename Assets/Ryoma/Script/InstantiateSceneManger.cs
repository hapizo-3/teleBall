using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//のひな作
//シーン移行するために必要です。

public class InstantiateSceneManger : MonoBehaviour {

    [SerializeField] GameObject sceneManager;
    //[SerializeField] GameObject Camera;

    // Use this for initialization
    void Start() {
        Instantiate(sceneManager);
        //Instantiate(Camera);
        Destroy(this.gameObject);
    }
}

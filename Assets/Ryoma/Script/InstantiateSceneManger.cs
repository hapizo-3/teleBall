using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateSceneManger : MonoBehaviour {

    [SerializeField] GameObject sceneManager;

    // Use this for initialization
    void Start() {
        Instantiate(sceneManager);
        Destroy(this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//移動するブロックにplayerを親子付けするスクリプトです。

public class RideOnOff : MonoBehaviour {

    void OnTriggerEnter(Collider other) {
        GameObject emptyObject = new GameObject();
        emptyObject.transform.parent = this.transform;
        other.transform.parent = this.transform;
        emptyObject.name = "empty";
        Debug.Log("乗った");
    }

    private void OnTriggerExit(Collider other) {
        other.transform.parent = null;
        GameObject emptyObject = GameObject.Find("empty");
        Destroy(emptyObject);
    }
}

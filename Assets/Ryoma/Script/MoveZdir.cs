using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveZdir : MonoBehaviour {
    public float length = 4.0f;     //移動する振幅
    public float speed = 2.0f;      //移動するスピード　大きくすると早くなる
    private Vector3 startPos;       //ゲーム開始時のポジションを入れる変数    

    void Start() {
        startPos = this.transform.position;     //ゲーム開始時の位置
    }

    void FixedUpdate() {
        transform.position =
            new Vector3(startPos.x, startPos.y, (Mathf.Sin((Time.time) * speed) * length + startPos.z));
        //Mathf.Sin()でフレーム毎の角度変化による値を出します。それにふり幅を掛けた値をstartPosのx座標に足します
        //↓原文
        //transform.position =
        //    new Vector3((Mathf.Sin((Time.time) * speed) * length + startPos.x), startPos.y, startPos.z);
    }
}

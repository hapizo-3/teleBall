using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Wall : MonoBehaviour {

    public GameObject Button;
    public GameObject Button2;
    private float x = 0;

    // Use this for initialization
    void Start () {
        // transformを取得
        Transform myTransform = this.transform.GetChild(0);
        

        //配置された場所のｙ座標を取得する
        x = myTransform.position.x;
    }
	
	// Update is called once per frame
	void Update () {

        
        // transformを取得
        Transform myTransform = this.transform.GetChild(0);
        Transform myTransformC = this.transform.GetChild(1);

        //ボタン二つのうち一つがtrueなら開く
        if ((Button.transform.GetChild(0).GetComponent<Button>().flg == true || Button2.transform.GetChild(0).GetComponent<Button>().flg == true) && x-4.5f <= myTransform.position.x)
        {
            myTransform.Translate(-0.15f, 0f, 0f, Space.World);
            myTransformC.Translate(0.15f, 0f, 0f, Space.World);
        }

        //ボタン二つともfalseなら閉まる
        else if (x >= myTransform.position.x && (Button.transform.GetChild(0).GetComponent<Button>().flg == false && Button2.transform.GetChild(0).GetComponent<Button>().flg == false))
        {
            myTransform.Translate(0.15f, 0f, 0f, Space.World);
            myTransformC.Translate(-0.15f, 0f, 0f, Space.World);


        }

    }
}

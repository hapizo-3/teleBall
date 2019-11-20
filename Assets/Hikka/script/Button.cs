using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    private float y = 0;
    public bool flg = false;


    void Start()
    {
        // transformを取得
        Transform myTransform = this.transform;
        //配置された場所のｙ座標を取得する
        y = myTransform.position.y;

    }

    // Update is called once per frame
    void Update () {

        // transformを取得
        Transform myTransform = this.transform;

        if (y >= myTransform.position.y)
        {

            myTransform.Translate(0f, 0.01f, 0f);

            if (y <= myTransform.position.y)
            {
                flg = false;
            }
        }
    }

    void OnTriggerStay(Collider player)
    {

        Transform myTransform = this.transform;


        

        if (player.gameObject.tag == "Player" && y-0.2f <= myTransform.position.y)
        {

            flg = true;
            myTransform.Translate(0f, -0.03f, 0f);

        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    public AudioClip sound1;
    public GameObject MenuPanel;

    private bool MenuActiveFlg;
    private Vector2 PScale = new Vector2(0, 0);

    AudioSource audioSource;

    // Use this for initialization
    void Start() {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
        MenuPanel.GetComponent<RectTransform>();
        MenuPanel.SetActive(false);
        MenuActiveFlg = false;
        PScale = Vector2.zero;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) == true)  //ESCを押した時
        {
            //音(sound1)を鳴らす
            audioSource.PlayOneShot(sound1);

            if (MenuActiveFlg == true)              //メニュー表示中なら
            {
                if (PScale.x >= 0.7f || PScale.y >= 0.7f)//最大になったら
                    MenuActiveFlg = false;          //小さくできるようになる
            }
            else              //メニュー非表示中なら
            {
                if (PScale.x <= 0 || PScale.y <= 0) {
                    MenuPanel.SetActive(true);      //メニューを表示
                    MenuActiveFlg = true;          //フラグ管理
                }
            }
        }

        if (MenuActiveFlg == true) {
            ScaleUp();
        }
        if (MenuActiveFlg == false) {
            ScaleDown();
        } 
    }


    public void ScaleUp() {
        if (PScale.x <= 0.7f || PScale.y <= 0.7f) {
            PScale.x += 0.05f;
            PScale.y += 0.05f;
            MenuPanel.transform.localScale = PScale;
        }
    }
    public void ScaleDown() {

        if (PScale.x >= 0.0f || PScale.y >= 0.0f) {
            PScale.x -= 0.05f;
            PScale.y -= 0.05f;
            if (PScale.x <= 0 || PScale.y <= 0)       //サイズが０以下になったら
            {
                MenuPanel.SetActive(false);     //メニューけす
            }
            MenuPanel.transform.localScale = PScale;
        }
    }
}

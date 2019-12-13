using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //パネルのイメージを操作するのに必要

//フェードイン・フェードアウトの処理です。

public class FadeController : MonoBehaviour {

    float fadeSpeed = 0.02f;        //透明度が変わるスピードを管理
    float red, green, blue, alfa;   //パネルの色、不透明度を管理

    public bool isFadeOut = false;  //フェードアウト処理の開始、完了を管理するフラグ
    public bool isFadeIn = false;   //フェードイン処理の開始、完了を管理するフラグ

    public bool isFadeOutEnd = false;
    

    Image fadeImage;                //透明度を変更するパネルのイメージ

	// Use this for initialization
	void Start () {
        fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;
    }

    // Update is called once per frame
    void Update () {
        if (isFadeIn) {
            StartFadeIn();
        }

        if (isFadeOut) {
            StartFadeOut();
        }
	}

    void StartFadeIn() {
        alfa -= fadeSpeed;              //b)不透明度を徐々に下げる
        SetAlpha();                     //c)変更した透明度をパネルに反映する
        if (alfa <= 0) {                //d)完全に透明になったら処理を抜ける
            isFadeIn = false;           //a)パネルの表示をオフにする
            fadeImage.enabled = false;
        }
    }

    public void StartFadeOut() {
        fadeImage.enabled = true;       //a)パネルの表示をオンにする
        alfa += fadeSpeed;              //b)不透明度を徐々に上げる
        SetAlpha();                     //c)変更した透明度をパネルに反映する
        if (alfa >= 1) {                //d)完全に不透明になったら処理を抜ける
            isFadeOut = false;
            isFadeOutEnd = true;
        }
    }

    void SetAlpha() {
        fadeImage.color = new Color(red, green, blue, alfa);
    }
}

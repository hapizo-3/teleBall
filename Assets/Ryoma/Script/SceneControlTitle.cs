using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//タイトル画面から、メニュー画面にジャンプするスクリプトです。
public class SceneControlTitle : MonoBehaviour {

    public GameObject panel;
    private FadeController fadeController;

    private void Start() {
        panel = GameObject.Find("Panel");
        fadeController = panel.GetComponent<FadeController>();
    }

    private void Update() {
        if (fadeController.isFadeOutEnd) {
            SceneManager.LoadScene("Menu");
        }
    }

    // OnRetry関数が実行されたら、sceneを読み込む
    public void OnStart() {
        //　Startボタンが入力されたら、sceneを読み込む
        fadeController.isFadeOut = true;
    }

    // OnSetting関数が実行されたら、sceneを読み込む
    public void OnSeting (){
        // 　Setingボタンが入力されたら、sceneを読み込む
        SceneManager.LoadScene("Seting");
    }

    // OnSetting関数が実行されたら、sceneを読み込む
    public void OnEnd() {
        // 　Endボタンが入力されたら、sceneを読み込む
        SceneManager.LoadScene("End");
    }
}

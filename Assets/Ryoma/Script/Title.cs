using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//タイトル画面から、メニュー画面にジャンプするスクリプトです。
public class Title : MonoBehaviour {

    public GameObject panel;
    private FadeController fadeController;
    private SceneController scenecontroller;

    private void Start() {
        panel = GameObject.Find("Panel");
        fadeController = GameObject.Find("Panel").GetComponent<FadeController>();
        scenecontroller = GameObject.Find("SceneController"). GetComponent<SceneController>();
    }

    private void Update() {
        //if (fadeController.isFadeOutEnd) {
        //    SceneManager.LoadScene("Menu");
        //}
    }

    // OnRetry関数が実行されたら、sceneを読み込む
    public void OnStart() {
        //はやと作スクリプト
        Debug.Log("stage01_blend");
        //SceneManager.LoadScene("stage01");
        scenecontroller.NextStage();
    }

    // OnSetting関数が実行されたら、sceneを読み込む
    public void OnSeting (){
        // 　Setingボタンが入力されたら、sceneを読み込む
        //SceneManager.LoadScene("Seting");
    }

    // OnSetting関数が実行されたら、sceneを読み込む
    public void OnEnd() {
        // 　Endボタンが入力されたら、sceneを読み込む
        //SceneManager.LoadScene("End");
    }
}

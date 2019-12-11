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
    Image fadeImage;                //透明度を変更するパネルのイメージ

    private void Start() {
        //fadeImage = GetComponent<Image>();
        fadeController = GameObject.Find("Panel").GetComponent<FadeController>();
        //scenecontroller = GameObject.Find("SceneController"). GetComponent<SceneController>();
    }

    private void Update() {
        if (fadeController.isFadeOutEnd) {          //フェードアウトが完了しているかどうか
            scenecontroller = GameObject.Find("SceneController(Clone)").GetComponent<SceneController>();
            scenecontroller.NextStage();            //次のステージを読みます。
            Debug.Log("来たよ！");
            fadeController.isFadeOutEnd = false;    //二度読み防止
        }
    }

    // OnRetry関数が実行されたら、sceneを読み込む
    public void OnStart() {
        Debug.Log("Start");
        //fadeController = GameObject.Find( "Panel" ).GetComponent<FadeController>();
        fadeController.isFadeOut = true;
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

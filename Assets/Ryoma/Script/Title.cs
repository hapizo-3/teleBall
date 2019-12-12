using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

//タイトル画面から、メニュー画面にジャンプするスクリプトです。
public class Title : MonoBehaviour {

    public GameObject panel;
    private FadeController fadeController;
    private SceneController scenecontroller;
    Image fadeImage;                //透明度を変更するパネルのイメージ

    private void Start() {
        //fadeImage = GetComponent<Image>();
        //scenecontroller = GameObject.Find("SceneController"). GetComponent<SceneController>();
        //fadeController = GameObject.Find("Panel(clone)").GetComponent<FadeController>();
        //シーンを切り替えてもこのゲームオブジェクトを削除しないようにする
    }

    private void Update() {
        fadeController = GameObject.Find("Panel").GetComponent<FadeController>();
        if (fadeController.isFadeOutEnd) {          //フェードアウトが完了しているかどうか
            scenecontroller = GameObject.Find("SceneController(Clone)").GetComponent<SceneController>();
            scenecontroller.NextStage();            //次のステージを読みます。
            fadeController.isFadeIn = true;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour {

    [System.NonSerialized]
    public int currentStageNum = 0; //現在のステージ番号（0始まり）

    [SerializeField]
    string[] stageName; //ステージ名

    private FadeController fadeController;

    //float red, green, blue, alfa;           //fadeControllerから取得する色

    //最初の処理
    void Start() {
        //    red = fadeController.red;
        //    green = fadeController.green;
        //    blue = fadeController.blue;
        //    alfa = fadeController.alfa;
        //シーンを切り替えてもこのゲームオブジェクトを削除しないようにする
        DontDestroyOnLoad(gameObject);
    }

    //毎フレームの処理
    void Update() {
        //デバッグ用
        //if (Input.GetKeyDown(KeyCode.Space)) {
        //    if (fadeController.isFadeOutEnd) {          //フェードアウトが完了しているかどうか
        //        NextStage();                            //次のステージを読みます。
        //        fadeController.isFadeIn = true;
        //        Debug.Log("来たよ！");
        //        fadeController.isFadeOutEnd = false;    //二度読み防止
        //    }
        //}
        fadeController = GameObject.Find("Panel").GetComponent<FadeController>();
        //デバッグ用
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (fadeController.isFadeOutEnd && fadeController.alfa != 1) {
                Debug.Log("alfaStart");
                fadeController.isFadeOut = true;
            }
        }
        if (fadeController.isFadeOutEnd && fadeController.alfa >= 1) {
            Debug.Log("NextStage");
            NextStage();
            fadeController.isFadeOutEnd = false;    //二度読み防止
        }
    }

    //次のステージに進む処理
    public void NextStage() {
        currentStageNum += 1;
        // if(fadeController.isFadeIn)
        Debug.Log("NextStage");
        //コルーチンを実行
        StartCoroutine(WaitForLoadScene());


        //デバッグ用
        if (currentStageNum > 4) {
            currentStageNum = 0;
            //コルーチンを実行
            //StartCoroutine(WaitForLoadScene());
        }
    }

    //シーンの読み込みと待機を行うコルーチン
    IEnumerator WaitForLoadScene() {
        //シーンを非同期で読込し、読み込まれるまで待機する
        yield return SceneManager.LoadSceneAsync(stageName[currentStageNum]);
    }
}
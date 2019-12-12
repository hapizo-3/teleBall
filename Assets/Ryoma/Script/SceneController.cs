using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    [System.NonSerialized]
    public int currentStageNum = 0; //現在のステージ番号（0始まり）

    [SerializeField]
    string[] stageName; //ステージ名

    private FadeController fadeController;


    //最初の処理
    void Start() {
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
        if (Input.GetKeyDown(KeyCode.Space)) {
            fadeController = GameObject.Find("Panel").GetComponent<FadeController>();
            NextStage();
            fadeController.isFadeOut = true;
        }
    }

    //次のステージに進む処理
    public void NextStage() {
        currentStageNum += 1;
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
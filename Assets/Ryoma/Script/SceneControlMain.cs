﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//メニューシーンからタイトルに戻るスクリプトです。

public class SceneControlMain : MonoBehaviour {

    // 3.OnRetry関数が実行されたら、sceneを読み込む
    public void OnRetry() {
        // 「ButtonScene」を自分の読み込みたいscene名に変える
        SceneManager.LoadScene("TitleTest");
    }
}

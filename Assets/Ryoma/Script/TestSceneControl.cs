using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TestSceneControl : MonoBehaviour {

    private new AudioSource audio;
    void Start() {
        audio = GetComponent<AudioSource>();
        audio.Play();

        StartCoroutine(Checking(() => {
            Debug.Log("END");
        }));
    }

    public delegate void functionType();
    public IEnumerator Checking(functionType callback) {
        while (true) {
            yield return new WaitForFixedUpdate();
            if (!audio.isPlaying) {
                callback();
                OnRetry();
                break;
            }
        }
    }


    // 3.OnRetry関数が実行されたら、sceneを読み込む
    public void OnRetry() {
        // 「ButtonScene」を自分の読み込みたいscene名に変える
        SceneManager.LoadScene("Menu");
    }
}

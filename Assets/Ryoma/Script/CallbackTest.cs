using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CallbackTest : MonoBehaviour {

    //private new AudioSource audio;

    AudioSource audioSource;
	void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();

 //       StartCoroutine(Checking(() => {
 //           Debug.Log("END");
 //       }));
    }

    void Update() {
        if ( !audioSource.isPlaying ) {
            
            SceneManager.LoadScene("Title");
            //OnRetry();
        }
    }

    //   public delegate void functionType();
    //   public IEnumerator Checking(functionType callback) {
    //       while (true) {
    //           yield return new WaitForFixedUpdate();
    //           if (!audio.isPlaying) {
    //               callback();
    //               OnRetry();
    //               break;
    //           }
    //       }
    //   }
    //public void OnRetry() {
    //    SceneManager.LoadScene("Title");
    //}
}

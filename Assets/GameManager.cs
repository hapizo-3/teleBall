using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public GameObject teleBall;
	public GameObject teleBallPrefab;
    [System.NonSerialized]
    public int currentStageNum = 0;        //現在のステージ番号（０始まり）

    [SerializeField]
    string[] stageName;     //ステージ名

    GameObject getCamera;
	look cameraPos;
	Vector3 cameraPosF;

	public bool wasLocked = false;

	// 最初の処理
	void Start () {
		//teleBallPrefab = ( GameObject )Prefab.Load( "teleBall" );
		getCamera = GameObject.FindGameObjectWithTag( "MainCamera" );
        //シーンを切り替えてもこのゲームオブジェクトを消去しないようにする
        DontDestroyOnLoad(gameObject);
	}

	void MouseLock()
	{
		wasLocked = true;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.Locked;
	}

	void MouseLockCancel()
	{
		wasLocked = false;
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.None;
	}

    //毎フレームの処理
    void Update () {

		if( wasLocked == true && ( Input.GetMouseButtonDown( 0 ) || Input.GetKeyDown( KeyCode.A ) || Input.GetKeyDown( KeyCode.S ) || Input.GetKeyDown( KeyCode.D ) ) )
		{
			cameraPos = getCamera.GetComponent<look>();
			cameraPosF = cameraPos.Camerafoward;

			Vector3 tmp = GameObject.FindGameObjectWithTag( "Player" ).transform.position;
			Instantiate( teleBall, new Vector3( cameraPosF.x, cameraPosF.y, cameraPosF.z ), Quaternion.identity );
			//Debug.Log( "Instantiate : " + Time.frameCount );
		}

		if( wasLocked == false && Input.GetMouseButtonDown( 0 ) )
		{
			MouseLock();
		}

		if( wasLocked == true && Input.GetKeyDown( KeyCode.Escape ) )
		{
			MouseLockCancel();
		}
	}

    //次のステージに進む処理
    public void NextStage() {
        currentStageNum += 1;

        //コルーチンを実行
        StartCoroutine(WaitForLoadScene());
    }

    //シーンの読み込みと待機を行うコルーチン
    IEnumerator WaitForLoadScene() {
        //シーンを非同期で読込し、読み込まれるまで待機する
        yield return
            SceneManager.LoadSceneAsync(stageName[currentStageNum]);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_Gate : MonoBehaviour {

    public float mx;
    public float mz;
    public bool goalflg;
    private float x1;
    private float z1;

    // Use this for initialization
    void Start () {
        // transformを取得
        Transform myTransform0 = this.transform.GetChild(0);
        

        x1 = myTransform0.position.x - mx;
        z1 = myTransform0.position.z + mz;

        goalflg = false;
        
    }
	
	// Update is called once per frame
	void Update () {
        // transformを取得
        Transform myTransform0 = this.transform.GetChild(0);
        Transform myTransform1 = this.transform.GetChild(1);

        if (mz >= 0)
        {

            if (goalflg == true && x1 < myTransform0.position.x)
            {
                myTransform0.Translate(-0.15f, 0f, 0f, Space.World);
                myTransform1.Translate(0.15f, 0f, 0f, Space.World);
            }

            if (goalflg == true && x1 >= myTransform0.position.x && z1 > myTransform0.position.z)
            {
                myTransform0.Translate(0f, 0f, 0.15f, Space.World);
                myTransform1.Translate(0f, 0f, 0.15f, Space.World);
            }
        }
        else if(mz < 0)
        {
            if (goalflg == true && x1 < myTransform0.position.x)
            {
                myTransform0.Translate(-0.15f, 0f, 0f, Space.World);
                myTransform1.Translate(0.15f, 0f, 0f, Space.World);
            }

            if (goalflg == true && x1 >= myTransform0.position.x && z1 < myTransform0.position.z)
            {
                myTransform0.Translate(0f, 0f, -0.15f, Space.World);
                myTransform1.Translate(0f, 0f, -0.15f, Space.World);
            }
        }
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {

            goalflg = true;
      

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_script : MonoBehaviour
{
    private GameObject ballPos;
    private Transform ballTrans;
    private Vector3 pos;
    public int axisX, axisY, axisZ;
    // Start is called before the first frame update
    void Start()
    {
       // ballTrans = ballPos GetComponent<Transform>();
        ballPos = GameObject.Find("Bolinha");
        

    }

    // Update is called once per frame
    void Update()
    {
        ballTrans = ballPos.transform;
        transform.position = new Vector3(ballTrans.position.x + axisX, ballTrans.position.y + axisY , ballTrans.position.z + axisZ);
    }

}

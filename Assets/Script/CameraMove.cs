using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Transform playerTransform;
    Vector3 offSet;

    // Start is called before the first frame update
    void Awake()
    {
        this.playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        offSet = transform.position - this.playerTransform.position;
    }

    //UI나 카메라 업데이트
    void LateUpdate()
    {
        transform.position = this.playerTransform.position + offSet;
    }
}

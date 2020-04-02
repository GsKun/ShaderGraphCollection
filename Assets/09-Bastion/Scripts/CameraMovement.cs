using UnityEngine;
using System.Collections;
using System;

public class CameraMovement : MonoBehaviour
{
    //摄像机跟踪速度
    public float smooth = 1.5f;

    private Transform player;
    private Vector3 relCameraPos;
    private float relCameraPosMag;
    private Vector3 newPos;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        relCameraPos = transform.position - player.position;
        relCameraPosMag = relCameraPos.magnitude - 0.5f;
    }

    void FixedUpdate()
    {
        //初始位置
        Vector3 standardPos = player.position + relCameraPos;
        //俯视位置
        Vector3 abovePos = player.position + Vector3.up * relCameraPosMag;
  
        transform.position = Vector3.Lerp(transform.position, standardPos, smooth * Time.deltaTime);
        //   SmoothLookAt();
    }

    void SmoothLookAt()
    {
        Vector3 relPlayerPosition = player.position - transform.position;

        Quaternion lookAtRotation = Quaternion.LookRotation(relPlayerPosition, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookAtRotation, smooth * Time.deltaTime);
    }
}

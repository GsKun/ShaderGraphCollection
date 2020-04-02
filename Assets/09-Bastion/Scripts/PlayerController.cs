using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //移动速度
    public float speed = 5;
    //转向速度
    public float rotationSpeed = 0.3f;

    private Rigidbody rb = null;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Movement(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    //移动
    private void Movement(float horizontal, float vertical)
    {
        if (horizontal != 0 || vertical != 0)
        {
            Rotating(horizontal, vertical);
            var direct = new Vector3(transform.forward.x, 0, transform.forward.z);
            rb.MovePosition(transform.position + direct * Time.deltaTime * speed);
        }
    }

    //旋转
    private void Rotating(float horizontal, float vertical)
    {
        var targetDirection = new Vector3(horizontal, 0, vertical);
        TransformHelper.LookAtTarget(targetDirection, transform, rotationSpeed);
    }
}

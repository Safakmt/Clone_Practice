using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followSpeed = 2;
    private bool isMoving = false;
    void Update()
    {
        if (isMoving)
            transform.Translate(Vector3.forward * Time.deltaTime * followSpeed, Space.World);
    }

   
    public void StartMove(bool state)
    {
        isMoving = state;
    }
}

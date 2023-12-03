using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAround : MonoBehaviour
{
    float mouseX;
    float mouseY;
    float yRotation = 0;
    float xRotation = 90;
    public float intensivity = 100;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * intensivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * intensivity * Time.deltaTime;
        xRotation += mouseX;
        yRotation -= mouseY;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);
        transform.rotation = Quaternion.Euler(yRotation, xRotation, 0);
    }

    // поворот камеры в направлении камеры в момент перехода в портал (вообще, если переписать полностью это вот всё дело, будет лучше)
    public void RotateCameraOnPortal(Quaternion newRotation)
    {
        if(newRotation.eulerAngles.x > 180)
        {
            yRotation = newRotation.eulerAngles.x - 360;
        }
        else
        {
            yRotation = newRotation.eulerAngles.x;
        }
        xRotation = newRotation.eulerAngles.y;
    }
}

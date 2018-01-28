using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class PlayerController : MonoBehaviour
{

    public float xNeg=-45,xPoz=45;
    public float yNeg=-45, yPoz=45;
    Transform ThisTransform;
    public float speed = 10;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }
    void update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
       // transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0f,0f);
    }
    float angleX = 0;
    float angleY = 0;
    private void FixedUpdate()
    {
        angleX += Input.GetAxis("Mouse X");
        angleX = Mathf.Clamp(angleX, xNeg, xPoz);

        angleY += Input.GetAxis("Mouse Y");
        angleY = Mathf.Clamp(angleY, yNeg, yPoz);
        
        transform.rotation = Quaternion.Euler(-angleY, angleX, 0.0f);
    }

}


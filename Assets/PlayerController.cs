using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class PlayerController : MonoBehaviour
{

    public float xNeg = -45, xPoz = 45;
    public float yNeg = -45, yPoz = 45;
 
   

    void Start()
    {


    }
    void update()
    {
        
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


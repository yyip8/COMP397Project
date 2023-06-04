using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;
    public Camera camera3;

    // Start is called before the first frame update
    void Start()
    {
        camera1.enabled = false;
        camera2.enabled = false;
        camera3.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Switch to camera 1 when button 1 is pressed
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            camera1.enabled = true;
            camera2.enabled = false;
            camera3.enabled = false;
        }

        // Switch to camera 2 when button 2 is pressed
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            camera1.enabled = false;
            camera2.enabled = true;
            camera3.enabled = false;
        }

        // Switch to camera 3 when button 3 is pressed
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            camera1.enabled = false;
            camera2.enabled = false;
            camera3.enabled = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class copy3 : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float movementSpeed = 10f;

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
        // Rotate object to the right when right arrow is pressed
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }

        // Rotate object to the left when left arrow is pressed
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }

        // Move object forward when up arrow is pressed
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        }

        // Move object backward when down arrow is pressed
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * movementSpeed * Time.deltaTime);
        }

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

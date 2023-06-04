using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float turnSpeed = 100.0f;
    public float jumpForce = 100.0f;
    private Rigidbody rb;

    public Camera camera1;
    public Camera camera2;
    public Camera camera3;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        camera1.enabled = false;
        camera2.enabled = false;
        camera3.enabled = true;
    }

    void Update()
    {
        // Turn right
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            float turn = turnSpeed * Time.deltaTime;
            Quaternion turnRotation = Quaternion.Euler(0.0f, turn, 0.0f);
            rb.MoveRotation(rb.rotation * turnRotation);
        }

        // Turn left
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            float turn = -turnSpeed * Time.deltaTime;
            Quaternion turnRotation = Quaternion.Euler(0.0f, turn, 0.0f);
            rb.MoveRotation(rb.rotation * turnRotation);
        }

        // Jump
        // if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.001f)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, 1, 0) * jumpForce, ForceMode.Impulse);
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

    private void FixedUpdate()
    {
        // Move forward
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            Vector3 movement = transform.forward * moveSpeed;
            Vector3 newPosition = rb.position + movement * Time.fixedDeltaTime;
            rb.MovePosition(newPosition);
        }

        // Move backward
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            Vector3 movement = -transform.forward * moveSpeed;
            Vector3 newPosition = rb.position + movement * Time.fixedDeltaTime;
            rb.MovePosition(newPosition);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] float thrustForce = 2000f;
    [SerializeField] float rotationSpeed = 250f;

    Vector2 moveInput;
    bool thrusting;

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        Rotate();
        Thrust();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnThrust(InputValue value)
    {
        if (value.isPressed)
        {
            thrusting = true;
        }
        else
        {
            thrusting = false;
        }
    }

    void Rotate()
    {
        if (moveInput.x > 0)
        {
            rb.freezeRotation = true;  // freeze rotation so we can manually rotate
            transform.Rotate(Vector3.forward * -rotationSpeed * Time.deltaTime, Space.Self);
            rb.freezeRotation = false;  // unfreeze rotation so the physics system can take over
        }
        else if (moveInput.x < 0)
        {
            rb.freezeRotation = true;  // freeze rotation so we can manually rotate
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime, Space.Self);
            rb.freezeRotation = false;  // unfreeze rotation so the physics system can take over
        }
    }

    void Thrust()
    {
        if (thrusting)
        {
            // ForceMode.Force applies force over time
            rb.AddRelativeForce(Vector3.up * thrustForce * Time.deltaTime, ForceMode.Force);
        }
    }
}

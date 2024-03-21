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

    RocketAudio rocketAudio;
    Thrusters thrusters;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rocketAudio = gameObject.GetComponent<RocketAudio>();
        thrusters = gameObject.GetComponent<Thrusters>();
    }


    void Update()
    {
        
        Thrust();
    }

    void FixedUpdate()
    {
        Rotate();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        if (moveInput.x > 0)
        {
            thrusters.PlayLeftThrust();
            thrusters.StopRightThrust();
        }
        else if (moveInput.x < 0)
        {
            thrusters.PlayRightThrust();
            thrusters.StopLeftThrust();
        }
        else
        {
            thrusters.StopRightThrust();
            thrusters.StopLeftThrust();
        }

    }

    void OnThrust(InputValue value)
    {
        if (value.isPressed)
        {
            thrusting = true;
            rocketAudio.PlayThrusAudio();
            thrusters.PlayMainThrust();
            Debug.Log("Thrusting");
        }
        else
        {
            thrusting = false;
            rocketAudio.StopThrustAudio();
            thrusters.StopMainThrust();
            Debug.Log("Not thrusting");
        }
    }

    void Rotate()
    {
        if (moveInput.x > 0)
        {
            // rb.AddRelativeTorque(Vector3.forward * -rotationSpeed * Time.deltaTime, ForceMode.Force);  //Hard to control
            
            rb.angularVelocity = Vector3.zero;  // remove rotation due to inertia first
            rb.MoveRotation(Quaternion.Euler(0, 0, rb.rotation.eulerAngles.z - rotationSpeed * Time.deltaTime));

            /*** Not smooth
            rb.freezeRotation = true;  // freeze rotation so we can manually rotate
            transform.Rotate(Vector3.forward * -rotationSpeed * Time.deltaTime, Space.Self);
            rb.freezeRotation = false;  // unfreeze rotation so the physics system can take over
            ***/
        }
        else if (moveInput.x < 0)
        {
            // rb.AddRelativeTorque(Vector3.forward * rotationSpeed * Time.deltaTime, ForceMode.Force);  //Hard to control

            rb.angularVelocity = Vector3.zero;  // remove rotation due to inertia first
            rb.MoveRotation(Quaternion.Euler(0, 0, rb.rotation.eulerAngles.z + rotationSpeed * Time.deltaTime));
            
            /*** Not smooth
            rb.freezeRotation = true;  // freeze rotation so we can manually rotate
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime, Space.Self);
            rb.freezeRotation = false;  // unfreeze rotation so the physics system can take over
            ***/
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

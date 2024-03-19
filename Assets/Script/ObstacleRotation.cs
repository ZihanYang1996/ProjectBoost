using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTest : MonoBehaviour
{
    Rigidbody rb;
    Vector3 EulerAngleVelocity;

    [SerializeField] float rotationSpeed = 5f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        EulerAngleVelocity = new Vector3(0, 0, rotationSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
        // rb.AddRelativeTorque(Vector3.forward * rotationSpeed);


    }

    void FixedUpdate()
    {
        // Only works well in FixedUpdate
        // Quaternion deltaRotation = Quaternion.Euler(EulerAngleVelocity);
        // rb.MoveRotation(rb.rotation * deltaRotation);
        rb.angularVelocity = transform.forward * rotationSpeed;
    }
}

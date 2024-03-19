using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRotation : MonoBehaviour
{
    Rigidbody rb;
    Vector3 EulerAngleVelocity;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // EulerAngleVelocity = new Vector3(0, 0, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
        rb.AddRelativeTorque(Vector3.forward * 10);

        // Below is not working well, even though it works
        // Quaternion deltaRotation = Quaternion.Euler(EulerAngleVelocity);
        // rb.MoveRotation(rb.rotation * deltaRotation);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillation : MonoBehaviour
{
    Vector3 initialPosition;
    [SerializeField] Vector3 endPosition;  // For MoveTowards
    [SerializeField] float oscillationSpeed = 10f;
    bool isMovingForward = true;  // For MoveTowards
    float startTime;
    [SerializeField] float oscillationTime = 2f;
    [SerializeField] Vector3 movementVector = new Vector3(10, 0, 0);  // For Sin wave

    void Start()
    {
        initialPosition = transform.position;
        startTime = Time.time;  // For lerp
    }

    // Update is called once per frame
    void Update()
    {
        // For MoveTowards
        // if(isMovingForward)
        // {
        //     Move(transform.position, endPosition);
        //     if ((transform.position - endPosition).sqrMagnitude < Mathf.Epsilon)
        //     {
        //         isMovingForward = false;
        //     }
        // }
        // else
        // {
        //     Move(transform.position, initialPosition);
        //     if ((transform.position - initialPosition).sqrMagnitude < Mathf.Epsilon)
        //     {
        //         isMovingForward = true;
        //     }
        // }

        // For lerp and SmoothStep
        // if(isMovingForward)
        // {
        //     Move(transform.position, endPosition);
        //     if ((transform.position - endPosition).sqrMagnitude < Mathf.Epsilon)
        //     {
        //         Debug.Log("End reached");
        //         isMovingForward = false;
        //         startTime = Time.time;
        //     }
        // }
        // else
        // {
        //     Move(transform.position, initialPosition);
        //     if ((transform.position - initialPosition).sqrMagnitude < Mathf.Epsilon)
        //     {
        //         Debug.Log("Start reached");
        //         isMovingForward = true;
        //         startTime = Time.time;
        //     }
        // }

        // Using Sin wave and Sin wave with Lerp
        Move();
    }

    // MoveTowards, feels unnatural
    // void Move(Vector3 start, Vector3 end)
    // {
    //     transform.position = Vector3.MoveTowards(start, end, oscillationSpeed * Time.deltaTime);
    // }

    // Lerp, not good (there's pause at the end of each oscillation)
    // since fractionOfTime be comes 0 at the beginning, which causes an extra frame of no movement
    // void Move(Vector3 start, Vector3 end)
    // {
    //     float timeElapsed = Time.time - startTime;
    //     float fractionOfTime = timeElapsed / oscillationTime;
    //     transform.position = Vector3.Lerp(start, end, fractionOfTime);
    // }

    // Use Sin wave to move, feels more natural
    // void Move()
    // {
    //     float timeElapsed = Time.time - startTime;
    //     float cycle = Mathf.PI * 2f;
    //     float offset = Mathf.Sin(timeElapsed / oscillationTime * cycle - Mathf.PI / 2) / 2f + 0.5f;
    //     Debug.Log(offset);
    //     transform.position = initialPosition + movementVector * offset;     
    // }

    // Sin wave with Lerp
    void Move()
    {
        float timeElapsed = Time.time - startTime;
        float cycle = Mathf.PI * 2f;
        float offset = Mathf.Sin(timeElapsed / oscillationTime * cycle - Mathf.PI / 2) / 2f + 0.5f;
        Debug.Log("Offset: "+ offset);
        Debug.Log("Time: " + (Time.time - startTime));
        transform.position = Vector3.Lerp(initialPosition, endPosition, offset);
    }

    // SmoothStep, more natural than lerp, but still not good (there's pause at the end of each oscillation)
    // void Move(Vector3 start, Vector3 end)
    // {
    //     float timeElapsed = Time.time - startTime;
    //     float fractionOfTime = timeElapsed / oscillationTime;
    //     transform.position = new Vector3(Mathf.SmoothStep(start.x, end.x, fractionOfTime),
    //                                                     Mathf.SmoothStep(start.y, end.y, fractionOfTime), 
    //                                                     Mathf.SmoothStep(start.z, end.z, fractionOfTime));
    // } 

}

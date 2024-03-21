using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrusters : MonoBehaviour
{
    ParticleSystem mainThrust;
    ParticleSystem leftThrust;
    ParticleSystem rightThrust;

    void Awake()
    {
        mainThrust = transform.Find("Rocket Jet Particles").gameObject.GetComponent<ParticleSystem>();
        leftThrust = transform.Find("Side Thruster Particles LeftSide").gameObject.GetComponent<ParticleSystem>();
        rightThrust = transform.Find("Side Thruster Particles RightSide").gameObject.GetComponent<ParticleSystem>();
    } 

    public void PlayMainThrust()
    {
        mainThrust.Play();
    }
    public void StopMainThrust()
    {
        mainThrust.Stop();
    }

    public void PlayLeftThrust()
    {
        leftThrust.Play();
    }
    public void StopLeftThrust()
    {
        leftThrust.Stop();
    }

    public void PlayRightThrust()
    {
        rightThrust.Play();
    }
    public void StopRightThrust()
    {
        rightThrust.Stop();
    }

}

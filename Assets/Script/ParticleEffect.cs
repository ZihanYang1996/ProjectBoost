using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffect : MonoBehaviour
{
    [SerializeField] ParticleSystem explosion;
    [SerializeField] ParticleSystem success;

    public void PlayExplosion(Vector3 position)
    {
        // Debug.Log("Explosion at " + position);
        ParticleSystem explosionInstance = Instantiate(explosion, position, Quaternion.identity);
        explosionInstance.Play();  // Since the prefab is not set to play on awake, we need to call Play() here
    }

    public void PlaySuccess(Vector3 position)
    {
        // Debug.Log("Success at " + position);
        ParticleSystem successInstance = Instantiate(success, position, Quaternion.identity);
        successInstance.Play();  // Since the prefab is not set to play on awake, we need to call Play() here
    }
}

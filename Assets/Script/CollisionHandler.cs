using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    RocketAudio rocketAudio;
    ParticleEffect particleEffect;

    bool isTransitioning = false;

    void Awake()
    {
        rocketAudio = gameObject.GetComponent<RocketAudio>();
        particleEffect = gameObject.GetComponent<ParticleEffect>();
    }

    void Update()
    {
        RespondToDebugKeys();
    }

    void RespondToDebugKeys()
    {
        if (Debug.isDebugBuild)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                Debug.Log("Debug: Loading next level");
                LoadNextScene();
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                isTransitioning = !isTransitioning;
                Debug.Log("Debug: Collision turned on: " + !isTransitioning);
            }
        }
    }
    
    void OnCollisionEnter(Collision other)
    {
        if (isTransitioning) return;  // ignore collisions when dead or finished

        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This thing is friendly");
                break;
            case "Finish":
                rocketAudio.PlayFinishAudio();
                gameObject.GetComponent<PlayerInput>().enabled = false;
                particleEffect.PlaySuccess(other.contacts[0].point);
                Invoke("LoadNextScene", 2f);
                isTransitioning = true;
                break;
            default:
                rocketAudio.PlayCrashAudio();
                gameObject.GetComponent<PlayerInput>().enabled = false;
                particleEffect.PlayExplosion(other.contacts[0].point);
                Invoke("ReloadScene", 2f);
                isTransitioning = true;
                break;
        }
    }

    void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        // Just for fun, using the ternary operator
        // nextSceneIndex = nextSceneIndex == SceneManager.sceneCountInBuildSettings ? 0 : nextSceneIndex;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}

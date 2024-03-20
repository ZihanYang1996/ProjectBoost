using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    RocketAudio rocketAudio;

    bool isTransitioning = false;

    void Awake()
    {
        rocketAudio = gameObject.GetComponent<RocketAudio>();
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
                Invoke("LoadNextScene", 2f);
                isTransitioning = true;
                break;
            default:
                rocketAudio.PlayCrashAudio();
                gameObject.GetComponent<PlayerInput>().enabled = false;
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

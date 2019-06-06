using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void SwitchScene()
    {
        int scenes = SceneManager.sceneCountInBuildSettings;
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int sceneToBeLoaded = (currentScene + 1) % scenes;
        Debug.Log("Switch Scene");
        SceneManager.LoadScene(sceneToBeLoaded);
    }
}

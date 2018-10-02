using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour {

    Scene currentScene;
    SceneManager sceneManager;
    string levelToLoad;


    // Use this for initialization
    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene();

        if(currentScene.buildIndex > 0)
        {  
            SaveCurrentLevel();
        }
        else
        {
            return; 
        }
    }

    //private void Start()
    //{
    //    if (SceneManager.GetActiveScene().buildIndex == 1)
    //    {
    //        Debug.Log(SceneManager.GetActiveScene().buildIndex);

    //    }

    //}

    public void SaveCurrentLevel()
    {
        PlayerPrefs.SetString("LevelToLoad", currentScene.name);
        print("Saving Scene" + PlayerPrefs.GetString("LevelToLoad)"));
    }

    public void LoadLevel()
    {
        levelToLoad = PlayerPrefs.GetString("LevelToLoad");
        print(levelToLoad);
        SceneManager.LoadScene(levelToLoad);
    }
}

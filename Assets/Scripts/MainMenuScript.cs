using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MainMenuScript : MonoBehaviour {

    public SceneSwitch sceneSwitch;


	// Use this for initialization
	void Start () {
        if (sceneSwitch == null)
        {
            sceneSwitch = gameObject.GetComponent<SceneSwitch>();
        }
        FindObjectOfType<SoundManager>().PlaySound("SpaceLoop");
    }


    public void StartNewGame()
    {

        Debug.Log("Clicked");
        sceneSwitch.FadeToNextLevel();
    }


    public void QuitGame()
    {
        Application.Quit();
    }




}

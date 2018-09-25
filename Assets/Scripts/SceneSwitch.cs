using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitch : MonoBehaviour {

    public Animator animator;

    private int levelToLoad;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.H))
        {
            FadeToNextLevel();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            ResetLevel();
        }
    }
    
    public void FadeToNextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 >= SceneManager.sceneCountInBuildSettings)
        {
            LoadMainMenu();
        }
        else
        {
            LevelFader(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void LoadMainMenu()
    {
        LevelFader(0);
    }

    public void ResetLevel()
    {
        LevelFader(SceneManager.GetActiveScene().buildIndex);
    }

    public void LevelFader(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        if(StatementsManager.Instance != null && StatementsManager.Instance.gameObject != null)
        {
            Destroy(StatementsManager.Instance.gameObject);
        }
        SceneManager.LoadScene(levelToLoad);
    }

}

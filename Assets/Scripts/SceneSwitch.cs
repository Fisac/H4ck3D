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
	}
    
    public void FadeToNextLevel()
    {
        LevelFader(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LevelFader(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        if(StatementsManager.Instance.gameObject != null)
        {
            Destroy(StatementsManager.Instance.gameObject);
        }
        SceneManager.LoadScene(levelToLoad);
    }

}

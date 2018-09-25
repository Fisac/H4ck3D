using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TestSound : MonoBehaviour {

    public Button play;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        play.onClick.AddListener(PlaySound);
	}

    void PlaySound()
    {
        Debug.Log("clicked!");
        FindObjectOfType<SoundManager>().PlaySound("Drop");
    }
    
}

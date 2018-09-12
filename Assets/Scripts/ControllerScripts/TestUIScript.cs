using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUIScript : MonoBehaviour {

    private float ControllerRotation;
    public GameObject Controller;


	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        ControllerRotation = Controller.transform.rotation.z;

        if (ControllerRotation >= 100)
        {
            
        }
    }
}

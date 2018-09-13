using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour {

    public Camera vrCamera;

    GameObject canvasHolder;
    float canvasHolderScale;
    float firstHypotenuse;
    float secondHypotenuse;
    float sizeOfCanvasHolder;

	// Use this for initialization
	void Start () {
        if (FindObjectOfType<Camera>().tag=="MainCamera")
        {
            vrCamera = GetComponent<Camera>();	
        }
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(vrCamera.transform.position);
    }

}

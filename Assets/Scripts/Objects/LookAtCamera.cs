using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookAtCamera : MonoBehaviour {

    public Camera vrCamera;

    GameObject canvasHolder;
    public Text popupName;
    public Text popupMatter;

    string nameOfParent;
    

	// Use this for initialization
	void Start () {

        nameOfParent = GetComponentInParent<GameObject>().name;
        popupName = GetComponentInChildren<Text>();

        popupMatter.text = GetComponentInParent<InteractableObject>().matter.name;
        popupName.text = nameOfParent;

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

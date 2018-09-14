using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookAtCamera : MonoBehaviour {

    public Camera vrCamera;
    public InteractableObject interactableObject;

    Transform myTransform;
    public Transform boxTransform;

    GameObject canvasHolder;
    public Text popupName;
    public Text popupMatter;

    // Use this for initialization
    void Start () {
        myTransform = GetComponent<Transform>();

        myTransform.localScale = new Vector3(myTransform.localScale.x, myTransform.localScale.y, boxTransform.localScale.z * 2.25f);
        myTransform.position = new Vector3(boxTransform.position.x, boxTransform.position.y, boxTransform.position.z);

        if (FindObjectOfType<Camera>().tag == "MainCamera")
        {
            vrCamera = GetComponent<Camera>();
        }
    }
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(vrCamera.transform.position);

        UpdateText();
    }

    void UpdateText()
    {
        popupMatter.text = interactableObject.matter.name;
        popupName.text = interactableObject.thisGameObject.name;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCanvasLookAt : MonoBehaviour {

    public Camera vrCamera;

	void Start () {

        if(vrCamera == null)
        {
            if (FindObjectOfType<Camera>().tag == "MainCamera")
            {
                vrCamera = GetComponent<Camera>();
            }
        }
    }

    void Update()
    {
        transform.LookAt(vrCamera.transform.position);
    }
}

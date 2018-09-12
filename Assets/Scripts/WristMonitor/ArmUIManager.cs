using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmUIManager : MonoBehaviour {

    public Canvas armUICanvas;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag=="MainCamera")
        {
            armUICanvas.gameObject.SetActive(true);
            Debug.Log("MainCamera in trigger.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "MainCamera")
        {
            armUICanvas.gameObject.SetActive(false);
            Debug.Log("MainCamera not in trigger.");
        }
    }
}

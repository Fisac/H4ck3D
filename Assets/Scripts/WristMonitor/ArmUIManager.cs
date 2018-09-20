using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmUIManager : MonoBehaviour {

    public Canvas armUICanvas;
    public CapsuleCollider smallCollider, bigCollider;
    public bool canDisable;

    private void Awake()
    {
        if (smallCollider == null || bigCollider == null)
            Debug.LogError("CHECK SMALL AND BIG COLLIDER ON ARMUIMANAGER!");
    }

    private void ActivateMonitor()
    {
        armUICanvas.gameObject.SetActive(true);
        smallCollider.enabled = false;
        bigCollider.enabled = true;
    }

    public void DisableMonitor()
    {
        if (!canDisable)
            return;

        armUICanvas.gameObject.SetActive(false);
        smallCollider.enabled = true;
        bigCollider.enabled = false;
    }

    public void SetCanDisable(bool value)
    {
        canDisable = value;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag=="MainCamera")
        {
            ActivateMonitor();
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.tag == "MainCamera")
        {
            DisableMonitor();
        }
    }
}

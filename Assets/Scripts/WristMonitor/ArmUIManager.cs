using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmUIManager : MonoBehaviour {

    public Canvas armUICanvas;
    public ArmUIInteraction armUIInteraction;
    public CapsuleCollider smallCollider, bigCollider;

    private void Awake()
    {
        if (armUIInteraction == null)
            armUIInteraction = FindObjectOfType<ArmUIInteraction>();

        if (smallCollider == null || bigCollider == null)
            Debug.LogError("CHECK SMALL AND BIG COLLIDER ON ARMUIMANAGER!");
    }

    private void Start()
    {
        DisableMonitor();
    }

    private void ActivateMonitor()
    {
        armUICanvas.gameObject.SetActive(true);
        smallCollider.enabled = false;
        bigCollider.enabled = true;
    }

    public void DisableMonitor()
    {
        if (armUIInteraction.state == InteractionStates.Dragging)
            return;

        armUICanvas.gameObject.SetActive(false);
        smallCollider.enabled = true;
        bigCollider.enabled = false;
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
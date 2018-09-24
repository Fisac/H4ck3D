using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ArmUIInteraction : MonoBehaviour {

    public VRTK.VRTK_UIPointer uiPointer;
    public GameObject materialCube;
    public Canvas selectCanvas;
    public ArmUIManager armUIManager;
    public Transform raycastOrigin;
    [HideInInspector]
    public GameObject currentUIElement, selectedWorldObject;

    public InteractionStates state;

    private void Awake()
    {
        GetMissingVariables();
        currentUIElement = null;
        state = InteractionStates.Neutral;
    }

    private void GetMissingVariables()
    {
        if (uiPointer == null)
        {
            uiPointer = GetComponent<VRTK.VRTK_UIPointer>();
        }
    }

    public void SetCurrentUIElement(GameObject uiElement)
    {
        currentUIElement = uiElement;
        StartDraggingUI();
    }

    public void StartDraggingUI()
    {
        state = InteractionStates.Dragging;

        EnableVisualEffects();
    }

    private void EnableVisualEffects()
    {
        if (currentUIElement.GetComponent<MonitorObject>() != null)
        {
            selectCanvas.gameObject.SetActive(true);
        }
        else if(currentUIElement.GetComponent<MonitorMatter>() != null)
        {
            materialCube.SetActive(true);
        }
    }

    private void DisableVisualEffects()
    {
        materialCube.SetActive(false);
        selectCanvas.gameObject.SetActive(false);
    }

    public void StopDraggingUI()
    {
        DisableVisualEffects();

        if (state == InteractionStates.Neutral)
            return;

        DetectObjectRaycast();

        state = InteractionStates.Neutral;
    }

    public void DetectObjectRaycast()
    {
        RaycastHit hit;
        Ray ray = new Ray(raycastOrigin.position, raycastOrigin.forward);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            GameObject hitObject = hit.collider.gameObject;
            Manipulatable objectManipulatable = hitObject.GetComponent<Manipulatable>();
            InteractableObject interactableObject = hitObject.GetComponent<InteractableObject>();
            MonitorMatter monitorMatter = currentUIElement.GetComponent<MonitorMatter>();
            MonitorObject monitorObject = currentUIElement.GetComponent<MonitorObject>();

            if (objectManipulatable != null && monitorObject != null)
            {
                selectedWorldObject = hit.collider.gameObject;

                monitorObject.currentManipulatable = objectManipulatable;
                monitorObject.UpdateStatement();

                SetUIObjectName(selectedWorldObject.name);
            }
            else if (interactableObject != null && monitorMatter != null)
            {
                interactableObject.UpdateMatter(monitorMatter.matter);
                
            }
        }
    }

    public void SetUIObjectName(string name)
    {
        Text uiText = currentUIElement.GetComponentInChildren<Text>();

        uiText.text = name;
    }
}

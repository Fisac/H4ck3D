using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ArmUIInteraction : MonoBehaviour {

    public VRTK.VRTK_UIPointer uiPointer;
    public ArmUIManager armUIManager;
    public Transform raycastOrigin;
    public GameObject currentUIElement, selectedUIElement, selectedWorldObject;
    public bool isDraggingUI;

    private void Awake()
    {
        GetMissingVariables();
        currentUIElement = null;
    }

    private void GetMissingVariables()
    {
        if (uiPointer == null)
        {
            uiPointer = GetComponent<VRTK.VRTK_UIPointer>();
        }
    }

    //THIS CAN BE OPTIMIZED CAN REMOVE UPDATE SOMEHOW!
    void Update () {
        if (uiPointer.pointerEventData == null)
            return;

        if(uiPointer.pointerEventData.pointerDrag != null)
        {
            currentUIElement = uiPointer.pointerEventData.pointerDrag;
            armUIManager.canDisable = false;
        }
        else
        {
            armUIManager.canDisable = true;
        }
	}
    //TODO Make it so currentObject can be assigned from world objects.

    public void StartDraggingUI()
    {
        isDraggingUI = true;
    }

    public void StopDraggingUI()
    {
        if (isDraggingUI == false)
            return;

        Debug.Log("Step 1");
        DetectObjectRaycast();

        isDraggingUI = false;
    }

    public void DetectObjectRaycast()
    {
        Debug.Log("Step 2");
        RaycastHit hit;
        Ray ray = new Ray(raycastOrigin.position, raycastOrigin.forward);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Debug.Log("Step 3");
            GameObject hitObject = hit.collider.gameObject;
            Manipulatable objectManipulatable = hitObject.GetComponent<Manipulatable>();
            InteractableObject interactableObject = hitObject.GetComponent<InteractableObject>();
            MonitorMatter monitorMatter = currentUIElement.GetComponent<MonitorMatter>();
            MonitorObject monitorObject = currentUIElement.GetComponent<MonitorObject>();

            if (objectManipulatable != null && monitorObject != null)
            {
                Debug.Log("Step 4a");
                selectedWorldObject = hit.collider.gameObject;

                monitorObject.currentManipulatable = objectManipulatable;
                monitorObject.UpdateStatement();

                SetUIObjectName(selectedWorldObject.name);
            }
            else if (interactableObject != null && monitorMatter != null)
            {
                Debug.Log("Step 4b");
                Debug.Log(monitorMatter.matter);
                //interactableObject.matter.matterMaterial = monitorMatter.matter.matterMaterial;
                interactableObject.UpdateMatter(monitorMatter.matter);
                
            }
        }
    }

    public void SetUIObjectName(string name)
    {
        Text uiText = currentUIElement.GetComponent<Text>();

        uiText.text = name;
    }
}

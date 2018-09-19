using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ArmUIInteraction : MonoBehaviour {

    public VRTK.VRTK_UIPointer uiPointer;
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

        DetectObjectRaycast();

        isDraggingUI = false;
    }

    public void DetectObjectRaycast()
    {
        RaycastHit hit;
        Ray ray = new Ray(raycastOrigin.position, raycastOrigin.forward);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            GameObject hitObject = hit.collider.gameObject;
            Manipulatable objectManipulatable = hitObject.GetComponent<Manipulatable>();
            MonitorObject monitorObject = currentUIElement.GetComponent<MonitorObject>();

            if (objectManipulatable != null && monitorObject != null)
            {
                selectedWorldObject = hit.collider.gameObject;

                monitorObject.currentManipulatable = objectManipulatable;
                monitorObject.UpdateStatement();

                SetUIObjectName(selectedWorldObject.name);
                //Apply currentUIElement.matter.material to hitObject.InteractableObject.matter

                //hitObject.GetComponent<InteractableObject>().matter.matterMaterial = currentUIElement.matter.matterMaterial;
            }
        }
    }

    public void SetUIObjectName(string name)
    {
        Text uiText = currentUIElement.GetComponent<Text>();

        uiText.text = name;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ArmUIInteraction : MonoBehaviour {

    public VRTK.VRTK_UIPointer uiPointer;
    public GameObject currentUIElement, currentWorldObject;
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
        if(uiPointer.pointerEventData != null)
            currentUIElement = uiPointer.pointerEventData.pointerDrag;
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
        Debug.Log("FIRE!!!");

        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.yellow, 1000);
            Debug.Log("Did Hit");
            Debug.Log(hit.collider.gameObject.name);
            currentWorldObject = hit.collider.gameObject;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * 1000, Color.white, 1000);
            Debug.Log("Did not Hit");
        }
    }
}

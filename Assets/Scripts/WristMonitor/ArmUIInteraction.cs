using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ArmUIInteraction : MonoBehaviour {

    public VRTK.VRTK_UIPointer uiPointer;
    public GameObject currentObject;

    private void Awake()
    {
        GetMissingVariables();
    }

    private void GetMissingVariables()
    {
        if (uiPointer == null)
        {
            uiPointer = GetComponent<VRTK.VRTK_UIPointer>();
        }
    }

    void Update () {
        //currentObject = uiPointer.pointerEventData.pointerDrag;
        Debug.Log(currentObject);
	}

    public void AddCurrentObject()
    {
        Debug.Log("ADDED: " + uiPointer.pointerEventData.pointerDrag);
        currentObject = uiPointer.pointerEventData.pointerDrag;
    }

    public void RemoveCurrentObject()
    {
        //Debug.Log("REMOVED: " + gameObject);
        //currentObject = null;
    }

}

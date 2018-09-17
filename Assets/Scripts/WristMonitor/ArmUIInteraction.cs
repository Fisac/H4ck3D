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

    //THIS CAN BE OPTIMIZED CAN REMOVE UPDATE SOMEHOW!
    void Update () {
        currentObject = uiPointer.pointerEventData.pointerDrag;
        //Debug.Log(currentObject);
	}
    //TODO Make it so currentObject can be assigned from world objects.

}

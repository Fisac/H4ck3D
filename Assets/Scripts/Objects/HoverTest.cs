using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverTest : MonoBehaviour {

    public VRTK.VRTK_InteractableObject vrtkInteractable;

    public Canvas testUIElement;

    Rigidbody myRigidbody;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (vrtkInteractable.isActiveAndEnabled && !myRigidbody.isKinematic)
        {
            testUIElement.gameObject.SetActive(true);
        }
        else
        {
            testUIElement.gameObject.SetActive(false);
        }
    }
}

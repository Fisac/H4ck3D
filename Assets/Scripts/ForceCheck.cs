using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceCheck : MonoBehaviour {

    InteractableObject interactableObject;

    private void Awake()
    {
        interactableObject = GetComponent<InteractableObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<InteractableObject>().force > interactableObject.matter.breakingPoint)
        {
            //I am destroyed
        }
    }
}

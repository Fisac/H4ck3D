using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceCheck : MonoBehaviour
{
    InteractableObject interactableObject;
    DestroyGlass destroyGlass;

    private void Awake()
    {
        interactableObject = GetComponent<InteractableObject>();
        destroyGlass = GetComponent<DestroyGlass>();
    }

    private void OnCollisionEnter(Collision other)
    {
        //if (!other.transform.GetComponentInChildren<InteractableObject>())
        //{
        //    return;
        //}

        if (!other.transform.GetComponentInChildren<InteractableObject>() && interactableObject.force > interactableObject.matter.breakingPoint && interactableObject.matter.isDestructable)
        {
            destroyGlass.DestroyTheGlass();
        }
        else if (other.transform.GetComponentInChildren<InteractableObject>().force > interactableObject.matter.breakingPoint && interactableObject.matter.isDestructable)
        {
            destroyGlass.DestroyTheGlass();
        }
        else if (other.transform.GetComponentInChildren<InteractableObject>() && interactableObject.force > interactableObject.matter.breakingPoint && interactableObject.matter.isDestructable)
        {
             destroyGlass.DestroyTheGlass();
        }
        else
        {
            return;
        }
    }
}

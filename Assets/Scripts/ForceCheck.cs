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
        InteractableObject otherInteractableObject = other.transform.GetComponentInChildren<InteractableObject>();

        if (!otherInteractableObject && interactableObject.force > interactableObject.matter.breakingPoint && interactableObject.matter.isDestructable)
        {
            destroyGlass.DestroyTheGlass();
        }
        else if (otherInteractableObject && otherInteractableObject.force > interactableObject.matter.breakingPoint && interactableObject.matter.isDestructable)
        {
            destroyGlass.DestroyTheGlass();
        }
        else if (otherInteractableObject && interactableObject.force > interactableObject.matter.breakingPoint && interactableObject.matter.isDestructable)
        {
            destroyGlass.DestroyTheGlass();
        }
        else
        {
            return;
        }
    }
}

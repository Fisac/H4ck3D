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
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("highestVelocity:" + other.transform.GetComponentInChildren<InteractableObject>().highestVelocity);
        Debug.Log("Force of "+ other.transform.name + " is " + other.transform.GetComponentInChildren<InteractableObject>().force);

        if (!other.transform.GetComponentInChildren<InteractableObject>())
        {
            return;
        }
        else if (other.transform.GetComponentInChildren<InteractableObject>().force > interactableObject.matter.breakingPoint)
        {
            Debug.Log("You dead");    
            //destroyGlass.DestroyTheGlass();
        }  
    }
}

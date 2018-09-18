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

    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("Collision!");
    //    if (other.GetComponent<InteractableObject>().force > interactableObject.matter.breakingPoint/* && interactableObject.matter.isDestructable*/)
    //    {
    //        //I am destroyed
    //        //destroyGlass.DestroyTheGlass();
    //        Debug.Log("Collision between " + other.name + "and " + this.name + " with a force of " + other.GetComponent<InteractableObject>().force);
    //    }
        
    //}
    //private void OnCollisionEnter(Collision other)
    //{
    //    Debug.Log("Collision!");
    //    if (other.relativeVelocity.magnitude > interactableObject.matter.breakingPoint/* && interactableObject.matter.isDestructable*/)
    //    {
    //        //I am destroyed
    //        //destroyGlass.DestroyTheGlass();
    //        Debug.Log("Collision between " + other.gameObject.name + "and " + this.name + " with a force of " + other.relativeVelocity.magnitude);
    //    }
    //}
}

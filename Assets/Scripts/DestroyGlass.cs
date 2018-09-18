using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGlass : MonoBehaviour {

    private int objectNumber = 1;
    public GameObject glassShards;
    InteractableObject interactableObject;
    public MeshRenderer mesh;

    private void Start()
    {
        interactableObject = GetComponent<InteractableObject>();
    }

    public void DestroyTheGlass()
    {
        Debug.Log("DestroyTheGlass");
        //if (Mathf.RoundToInt(interactableObject.boxVolume) < 2)
        //{
        //    objectNumber = 1;
        //}
        //else
        //{
        //    objectNumber = 2;
        //}
        //Debug.Log("objectNumber: " + objectNumber);

        Debug.Break();
        for (int i = 0; i <= objectNumber; i++)
        { 
            Instantiate(glassShards, transform.position, transform.rotation);
        }
        mesh.enabled = false;
    }
}

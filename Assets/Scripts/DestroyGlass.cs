using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyGlass : MonoBehaviour {

    private int objectNumber = 1;
    public GameObject glassShards;
    InteractableObject interactableObject;
    public MeshRenderer mesh;
    public SoundManager soundManager;
    public Manipulatable manipulatable;

    private void Start()
    {
        interactableObject = GetComponent<InteractableObject>();
        manipulatable = GetComponent<Manipulatable>();
    }

    public void DestroyTheGlass()
    {
        if (manipulatable == null)
            manipulatable = GetComponent<Manipulatable>();

        if (manipulatable != null)
        {
            manipulatable.destroyed = true;
            manipulatable.UpdateValues();
        }

        mesh.enabled = false;
        if(interactableObject == null)
            interactableObject = GetComponent<InteractableObject>();

        interactableObject.GetComponent<Collider>().enabled = false;
        for (int i = 0; i <= objectNumber; i++)
        { 
            Instantiate(glassShards, transform.position, transform.rotation);
        }



        mesh.enabled = false;
        FindObjectOfType<SoundManager>().PlaySound("Glass");

    }
}

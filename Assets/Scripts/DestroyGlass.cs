using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyGlass : MonoBehaviour {

    private int objectNumber = 1;
    public GameObject glassShards;
    InteractableObject interactableObject;
    public MeshRenderer mesh;
    public SoundManager soundManager;

    private void Start()
    {
        interactableObject = GetComponent<InteractableObject>();
    }

    public void DestroyTheGlass()
    {
        mesh.enabled = false;
        interactableObject.GetComponent<Collider>().enabled = false;
        for (int i = 0; i <= objectNumber; i++)
        { 
            Instantiate(glassShards, transform.position, transform.rotation);
        }
<<<<<<< HEAD
        mesh.enabled = false;
        soundManager.PlaySound("Element 1");
=======
>>>>>>> 2fa96868d5c0b71f924aea369d7e3f8e6f9576c5
    }
}

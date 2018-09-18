using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGlass : MonoBehaviour {

    private float objectnumber;
    public GameObject glassShards;
    public InteractableObject interactableObject;
    public MeshRenderer mesh;

    public void DestroyTheGlass()
    {
        float boxVolume = interactableObject.boxVolume;

        if (boxVolume < 2)
        {
            objectnumber = boxVolume;
        }
        else
        {
            objectnumber = 2;
        }

        print(objectnumber);
        for (int i = 0; i <= objectnumber; i++)
        { 
            Instantiate(glassShards, transform.position, transform.rotation);
        }
        mesh.enabled = false;
    }
}

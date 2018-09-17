using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGlass : MonoBehaviour {

    private float objectnumber;
    public GameObject destroyed;
    public InteractableObject interactableObject;
    public MeshRenderer mesh;

	// Use this for initialization
	void OnMouseDown()
    {
        float boxVolume = interactableObject.boxVolume;
        objectnumber = boxVolume;

        print(objectnumber);
        for (int i = 0; i <= objectnumber; i++)
        { 
            Instantiate(destroyed, transform.position, transform.rotation);
        }
        mesh.enabled = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}

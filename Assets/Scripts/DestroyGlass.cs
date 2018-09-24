﻿using System.Collections;
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
        for (int i = 0; i <= objectNumber; i++)
        { 
            Instantiate(glassShards, transform.position, transform.rotation);
        }
        mesh.enabled = false;
        soundManager.PlaySound("Element 1");
    }
}

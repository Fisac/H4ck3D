using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialTest : MonoBehaviour {

    public GameObject interactable;
    private InteractableObject interactor;
    public Matter matter;
    private MaterialManager matManager;

    private void Awake()
    {
        interactor = interactable.GetComponent<InteractableObject>();
        matManager = interactable.GetComponent<MaterialManager>();
    }

    public void ChangeMatter()
    {
        if(interactor.matter != matter)
        {
            interactor.matter = matter;
            matManager.ApplyNewMaterial();
        }
    }
}

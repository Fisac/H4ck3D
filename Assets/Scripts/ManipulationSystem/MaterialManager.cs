using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoBehaviour {

    private InteractableObject interactable;
    private Matter currentMatter;

    private Renderer rend; 

    private void Awake()
    {
        interactable = gameObject.GetComponent<InteractableObject>();
        rend = gameObject.GetComponent<Renderer>();
        currentMatter = interactable.matter;
        rend.material = currentMatter.matterMaterial; 
       
    }

    public void ApplyNewMaterial()
    {
        currentMatter = interactable.matter; 
        print("Change Material to: "+ currentMatter.matterMaterial);
        rend.material = currentMatter.matterMaterial; 
    }
}

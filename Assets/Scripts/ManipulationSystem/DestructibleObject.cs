using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObject : MonoBehaviour {

    [SerializeField]
    private float transitionDuration = 0.0f; 
    private InteractableObject interactable; 
    private MeshRenderer mesh;
    private BoxCollider collider;
    const string destroyObject = "DestroyObject";

    private void Awake()
    {
        interactable = gameObject.GetComponent<InteractableObject>();
        mesh = gameObject.GetComponent<MeshRenderer>();
        collider = gameObject.GetComponent<BoxCollider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
       if(interactable.matter.isDestructable)
        {
            StartCoroutine(destroyObject);
        }
       else
        {
            return; 
        }
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(transitionDuration);
        mesh.enabled = false;
        collider.enabled = false; 
    }
}

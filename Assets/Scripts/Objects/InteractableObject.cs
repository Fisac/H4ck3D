using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {

    VRTK.VRTK_InteractableObject vrtkInteractable;

    public Matter matter;

    public List<Matter> matters;

    Collider objectCollider;
    Rigidbody objectRigidbody;

    public float mass;
    public float maximumLiftWeight = 4;

    bool newMatter;

    void Start()
    {
        UpdateProperties();
    }

    void Update()
    {
        if (newMatter)
        {
            UpdateProperties();
        }
    }

    void UpdateMatter(Matter matter)
    {
        matter = this.matter;
        newMatter = true;
    }

    void UpdateProperties()
    {
        objectCollider = GetComponent<BoxCollider>();
        objectRigidbody = GetComponent<Rigidbody>();

        mass = matter.mass;
        objectRigidbody.mass = mass;

        Debug.Log("Name: " + matter.name);
        Debug.Log("Mass: " + matter.mass);
        Debug.Log("Friction multiplier: " + matter.frictionMultiplier);
        Debug.Log("Is physical: " + matter.isPhysical);
        Debug.Log("Is destructable: " + matter.isDestructable);
        Debug.Log("Is physical: " + matter.isPhysical);

        if (matter.mass > maximumLiftWeight)
        {
            vrtkInteractable.isGrabbable = false;
            objectRigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        }
        if (!matter.isPhysical)
        {
            vrtkInteractable.isGrabbable = false;
            objectCollider.enabled = !objectCollider.enabled;
            objectRigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        }

        newMatter = false;
        Debug.Log("newMatter: " + newMatter);
    }
}

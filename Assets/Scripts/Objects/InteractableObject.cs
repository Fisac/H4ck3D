using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {

    VRTK.VRTK_InteractableObject vrtkInteractable;

    public Matter matter;

    public List<Matter> matters;

    Collider objectCollider;
    Rigidbody objectRigidbody;
    Transform objectTransform;
    public GameObject thisGameObject;

    public float mass;
    public float maximumLiftWeight = 4;
    float boxVolume;

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
        objectTransform = GetComponent<Transform>();
        objectCollider = GetComponent<BoxCollider>();
        objectRigidbody = GetComponent<Rigidbody>();

        MassCalculation();

        Debug.Log("Object name: " + thisGameObject.name);
        Debug.Log("Matter: " + matter.name);
        Debug.Log("Mass: " + mass);
        Debug.Log("Friction multiplier: " + matter.frictionMultiplier);
        Debug.Log("Is physical: " + matter.isPhysical);
        Debug.Log("Is destructable: " + matter.isDestructable);
        Debug.Log("Is physical: " + matter.isPhysical);

        if (mass > maximumLiftWeight)
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

    void MassCalculation()
    {
        boxVolume = objectTransform.localScale.x * objectTransform.localScale.y * objectTransform.localScale.z;
        mass = matter.density * boxVolume;

        objectRigidbody.mass = mass;
    }
}

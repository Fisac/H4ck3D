using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {

    VRTK.VRTK_InteractableObject vrtkInteractable;

    public Matter matter;

    DestroyGlass destroyGlass;
    Manipulatable manipulatable;

    public List<Matter> matters;

    Collider objectCollider;
    Rigidbody objectRigidbody;
    Transform objectTransform;
    private Renderer myRenderer;
    public GameObject thisGameObject;

    public float mass;
    public float maximumLiftWeight = 4;
    public float boxVolume;

    public float force;
    float newForce;
    public float highestVelocity;
    float acceleration;

    bool newMatter;

    private void Awake()
    {
        objectTransform = GetComponent<Transform>();
        objectCollider = GetComponent<BoxCollider>();
        objectRigidbody = GetComponent<Rigidbody>();
        myRenderer = GetComponent<Renderer>();

        myRenderer.material = matter.matterMaterial;
    }

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

    void FixedUpdate()
    {
        //if (manipulatable.moving)
        //{
        //    highestVelocity = Mathf.Max(objectRigidbody.velocity.x, objectRigidbody.velocity.y, objectRigidbody.velocity.z);
        //    acceleration = highestVelocity / Time.fixedDeltaTime;
        //    force = mass * acceleration;
        //}
        if (manipulatable.moving)
        {
            highestVelocity = Mathf.Max(Mathf.Abs(objectRigidbody.velocity.x), Mathf.Abs(objectRigidbody.velocity.y), Mathf.Abs(objectRigidbody.velocity.z));
            force = mass * highestVelocity;

            if (force > 0.1f)
            {
                Debug.Log("Force: " + force);
            }

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

        objectCollider.material = matter.physicMaterial;
        myRenderer.material = matter.matterMaterial;

        MassCalculation();

        Debug.Log("Object name: " + thisGameObject.name);
        Debug.Log("Matter: " + matter.name);
        Debug.Log("Mass: " + mass);
        Debug.Log("Friction multiplier: " + matter.frictionMultiplier);
        Debug.Log("Is physical: " + matter.isPhysical);
        Debug.Log("Is destructable: " + matter.isDestructable);
        Debug.Log("Is physical: " + matter.isPhysical);

        if (matter.name=="Glass")
        {
            destroyGlass.enabled = true;
        }
        else
        {
            destroyGlass.enabled = false;
        }
        //MaximumLiftWeight check
        if (mass > maximumLiftWeight)
        {
            vrtkInteractable.isGrabbable = false;
            objectRigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        }
        else
        {
            vrtkInteractable.isGrabbable = true;
            objectRigidbody.useGravity = true;
        }

        //Is it physical?
        if (!matter.isPhysical)
        {
            vrtkInteractable.isGrabbable = false;
            objectRigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;

            if (matter.name=="Hologram")
            {
                objectCollider.isTrigger = true;
            }
            else
            {
                objectCollider.enabled = !objectCollider.enabled;
                objectCollider.isTrigger = false;
            }
        }
        newMatter = false;
        Debug.Log("newMatter: " + newMatter);
    }
    //Volume and mass calculation
    void MassCalculation()
    {
        boxVolume = objectTransform.localScale.x * objectTransform.localScale.y * objectTransform.localScale.z;
        mass = matter.density * boxVolume;

        objectRigidbody.mass = mass;
    }
}

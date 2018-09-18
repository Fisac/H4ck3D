using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHandler : MonoBehaviour {

    public float initVelocity;
    public float finalVelocity; 
    public float grabDistance;
    public float dropForce; 
    public float throwForce;
    public Transform heldPosition;
    public ForceMode throwForceMode;
    public LayerMask layerMask = -1; 
    private Transform destination;

    private GameObject heldObject;
    public bool pickedUp; 
	void Start () {

        heldObject = null;
        pickedUp = false; 
	}
	
	// Update is called once per frame
	void Update () {
       
        if(heldObject != null)
        {
           if(heldObject.transform.position != heldPosition.transform.position)
            {
                pickedUp = true; 
                heldObject.transform.position = Vector3.Lerp(heldObject.transform.position, heldPosition.transform.position, Mathf.Lerp(initVelocity, finalVelocity, Time.deltaTime)); 
            }

           else
            {

                heldObject.transform.position = heldPosition.position;
                 heldObject.transform.rotation = heldPosition.rotation;
            }
        }

        if(Input.GetMouseButtonDown(0) && pickedUp == false)
        {
            PickUpObject(); 
        }
        if(Input.GetMouseButtonDown(1) && (pickedUp))//heldObject.transform.position == heldPosition.transform.position))
        {
                RepelObject();
        }

        else if(Input.GetMouseButtonDown(0) && pickedUp)
        {
            DropObject();
        }
	}

    public void PickUpObject()
    {
        if(heldObject == null)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, grabDistance, layerMask) &&
                hit.transform.gameObject.GetComponent<InteractableObject>().liftable)
            {
                Debug.DrawRay(transform.position, transform.forward * 1000, Color.yellow, 1000);
                heldObject = hit.collider.gameObject;
                heldObject.GetComponent<Rigidbody>().isKinematic = true;

            }
            else
            {
                Debug.DrawRay(transform.position, transform.forward * 1000, Color.red, 1000);
            }

        }
    }

    public void RepelObject()
    {
        Rigidbody body = heldObject.GetComponent<Rigidbody>();
        body.isKinematic = false;
        body.AddForce(throwForce * transform.forward, throwForceMode);
        heldObject = null;
        pickedUp = false; 
    }

    public void DropObject()
    {
        Rigidbody body = heldObject.GetComponent<Rigidbody>();
        body.isKinematic = false;
        body.AddForce(dropForce * transform.forward, throwForceMode);
        heldObject = null;
        pickedUp = false;
    }


}

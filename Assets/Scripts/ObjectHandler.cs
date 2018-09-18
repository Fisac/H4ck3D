using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHandler : MonoBehaviour {

    public float grabDistance;
    public float throwForce;
    public Transform heldPosition;
    public ForceMode throwForceMode;
    public LayerMask layerMask = -1; 
    private Transform destination;

    private GameObject heldObject; 
	// Use this for initialization
	void Start () {

        heldObject = null; 
		
	}
	
	// Update is called once per frame
	void Update () {
       
        if(heldObject != null)
        {
            heldObject.transform.position = heldPosition.position;
            heldObject.transform.rotation = heldPosition.rotation;
        }

        if(Input.GetMouseButtonDown(0))
        {
            PickUpObject(); 
        }
        else if(Input.GetMouseButtonUp(0))
        {
            RepelObject();
        }
	}

    public void PickUpObject()
    {
        Debug.Log("1");
        if(heldObject == null)
        {
            RaycastHit hit;
            Debug.Log("2");

            if (Physics.Raycast(transform.position, transform.forward, out hit, grabDistance, layerMask) &&
                hit.transform.gameObject.GetComponent<InteractableObject>().liftable)
            {
                Debug.DrawRay(transform.position, transform.forward * 1000, Color.yellow, 1000);
                heldObject = hit.collider.gameObject;
                heldObject.GetComponent<Rigidbody>().isKinematic = true;
                heldObject.GetComponent<Collider>().enabled = false;
                Debug.Log("3");

            }
            else
            {
                Debug.DrawRay(transform.position, transform.forward * 1000, Color.red, 1000);
                Debug.Log("4");
            }

        }
    }

    public void RepelObject()
    {
        Rigidbody body = heldObject.GetComponent<Rigidbody>();
        body.isKinematic = false;
        heldObject.GetComponent<Collider>().enabled = true;
        body.AddForce(throwForce * transform.forward, throwForceMode);
        heldObject = null; 
    }


}

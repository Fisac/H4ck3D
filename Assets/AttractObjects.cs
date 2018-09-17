using UnityEngine;
using VRTK;
using System.Collections;

public class AttractObjects : MonoBehaviour
{

    public GameObject hand;
    private Rigidbody rigidbody;
    private Vector3 destination;
    private bool grabbed; 
    // Use this for initialization

    void Start()

    {
        rigidbody = GetComponent<Rigidbody>();
        destination = new Vector3();


        //make sure the object has the VRTK script attached... 

        if (GetComponent<VRTK_InteractableObject>() == null)

        {

            Debug.LogError("Team3_Interactable_Object_Extension is required to be attached to an Object that has the VRTK_InteractableObject script attached to it");

            return;

        }



        //subscribe to the event.  NOTE: the "ObectGrabbed"  this is the procedure to invoke if this objectis grabbed.. 

        GetComponent<VRTK_InteractableObject>().InteractableObjectGrabbed += new InteractableObjectEventHandler(ObjectGrabbed);
    }



    //this object has been grabbed.. so do what ever is in the code.. 

    private void ObjectGrabbed(object sender, InteractableObjectEventArgs e)

    {
        /*destination = hand.transform.position;
        grabbed = true; */

        print("I am Grabbed");
    }

    private void Update()
    {
        //MoveToTarget(); 
    }

    private void MoveToTarget()
    {
        /*if(grabbed && transform.position != hand.transform.position)
        {
            transform.position = Vector3.Lerp(transform.position, hand.transform.position, Time.deltaTime *  )
        }*/
    }

}

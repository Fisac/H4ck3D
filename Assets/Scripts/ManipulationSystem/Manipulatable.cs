using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manipulatable : MonoBehaviour {

    [HideInInspector]
    public Statement statement;
    private Rigidbody rigidBody;
    public List<GameObject> colliders = new List<GameObject>();

    public bool destroyed, moving, airborne;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (rigidBody == null)
        {
            SetKinematicValues();
            return;
        }
        if (rigidBody.isKinematic)
        {
            SetKinematicValues();
            return;
        }
        CheckMovement();
        CheckAirborne();
        UpdateValues();
    }

    private void SetKinematicValues()
    {
        moving = false;
        airborne = false;
    }

    private void CheckMovement()
    {
        if (rigidBody == null)
            return;

        if (rigidBody.velocity.magnitude > 0)
            moving = true;
        else
            moving = false;

    }

    private void CheckAirborne()
    {
        if (colliders.Count == 0)
            airborne = true;
        else
            airborne = false;
    }

    public void UpdateValues()
    {
        if(statement != null)
            StatementsManager.Instance.CheckStatement(statement);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("COLLIDER IS: " + collision.gameObject);
        if(!colliders.Contains(collision.gameObject))
            colliders.Add(collision.gameObject);
    }

    private void OnCollisionExit(Collision collision)
    {
        if(colliders.Contains(collision.gameObject))
            colliders.Remove(collision.gameObject);
    }
}
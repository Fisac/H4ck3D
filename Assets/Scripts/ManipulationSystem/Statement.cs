using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statement : MonoBehaviour {

    public Manipulatable manipulatable;

    public Conditions destroyCondition, movingCondition, airborneCondition;
    public Matter matter;

    private void Awake()
    {
        if(matter == null)
        {
            matter = new Matter();
        }
    }

    private void Start()
    {
        if(manipulatable != null)
            ApplySelfToManipulatable();
    }

    private void Update()
    {
        if (manipulatable != null && manipulatable.statement != this)
            ApplySelfToManipulatable();
    }

    public void ApplySelfToManipulatable()
    {
        manipulatable.statement = this;
    }

    public bool TryStatement()
    {
        if (CheckingForMaterial())
        {
            return CheckMaterial();
        }
        else
        {
            return CheckConditions();
        }
    }

    private bool CheckingForMaterial()
    {
        if (destroyCondition == Conditions.Ignore &&
            movingCondition == Conditions.Ignore &&
            airborneCondition == Conditions.Ignore)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    private bool CheckMaterial()
    {
        InteractableObject interactableObject = manipulatable.GetComponent<InteractableObject>();

        if (interactableObject == null || matter == null)
            return false;

        if (interactableObject.matter.name == matter.name)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool CheckConditions()
    {
        if (!TryCondition(destroyCondition, manipulatable.destroyed))
            return false;

        if (!TryCondition(movingCondition, manipulatable.moving))
            return false;

        if (!TryCondition(airborneCondition, manipulatable.airborne))
            return false;

        return true;
    }

    private bool TryCondition(Conditions condition, bool conditionValue)
    {
        bool testPassed = true;

        switch (condition)
        {
            case Conditions.Ignore:
                break;
            case Conditions.True:
                testPassed = TryStatement(conditionValue, true);
                break;
            case Conditions.False:
                testPassed = TryStatement(conditionValue, false);
                break;
            default:
                break;
        }
        return testPassed;
    }

    private bool TryStatement(bool statement, bool value)
    {
        if (statement == value)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
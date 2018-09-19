using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statement : MonoBehaviour {

    public Manipulatable manipulatable;

    public Conditions destroyCondition, movingCondition, airborneCondition;

    private void Start()
    {
        if(manipulatable != null)
            ApplySelfToManipulatable();
    }

    private void ApplySelfToManipulatable()
    {
        manipulatable.statement = this;
    }

    public bool TryStatement()
    {
        return CheckConditions();
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
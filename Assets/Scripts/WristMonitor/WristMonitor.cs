using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WristMonitor : MonoBehaviour {

    public Statement[] statements;
    public MonitorStatement[] ifStatements;

    private void Start()
    {
        DrawStatements();
    }

    private void DrawStatements()
    {
        for (int i = 0; i < statements.Length; i++)
        {
            if (statements[i].manipulatable != null)
            {
                ifStatements[i].textA.text = statements[i].manipulatable.gameObject.name;
            }
        }
    }

    private string ConstructConditionString(int i)
    {
        String conditionsString = "";
        String tempString;

        tempString = "";
        tempString += CheckCondition(statements[i].airborneCondition, "airborne");
        conditionsString += tempString;

        tempString = "";
        tempString += CheckCondition(statements[i].movingCondition, "moving");
        if(conditionsString != "")
            tempString = AddAnd(tempString);
        conditionsString += tempString;

        tempString = "";
        tempString += CheckCondition(statements[i].destroyCondition, "destroyed");
        if (conditionsString != "")
            tempString = AddAnd(tempString);
        conditionsString += tempString;

        return conditionsString;
    }

    private string CheckCondition(Conditions condition, string conditionName)
    {
        switch (condition)
        {
            case Conditions.Ignore:
                return "";
            case Conditions.True:
                return conditionName + " ";
            case Conditions.False:
                return "!" + conditionName + " ";
            default:
                return "";
        }
    }

    private string AddAnd(string conditionsString)
    {
        if (conditionsString != "")
        {
            conditionsString = "&& " + conditionsString;
        }
        return conditionsString;
    }
}

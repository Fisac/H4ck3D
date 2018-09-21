using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonitorStatement : MonoBehaviour {

    const string airborne = "Airborne";
    const string moving = "Moving";
    const string destroyed = "Destroyed";

    const string notAirborne = "!Airborne";
    const string notMoving = "!Moving";
    const string notDestroyed = "!Destroyed";

    const string materialDefault = "Default";
    const string materialGlass = "Glass";
    const string materialHologram = "Hologram";
    const string materialMetal = "Metal";

    public Statement statement;
    public MonitorObject monitorObject;
    public Text textA;
    public Dropdown dropdown;

    private void Awake()
    {
        monitorObject.statement = statement;
    }

    public void UpdateConditions()
    {
        CheckCurrentCondition();
    }

    private void CheckCurrentCondition()
    {
        ResetConditionValues();

        switch (dropdown.captionText.text)
        {
            case airborne:
                statement.airborneCondition = Conditions.True;
                break;
            case moving:
                statement.movingCondition = Conditions.True;
                break;
            case destroyed:
                statement.destroyCondition = Conditions.True;
                break;

            case notAirborne:
                statement.airborneCondition = Conditions.False;
                break;
            case notMoving:
                statement.movingCondition = Conditions.False;
                break;
            case notDestroyed:
                statement.destroyCondition = Conditions.False;
                break;

            case materialDefault:
                statement.matter.name = materialDefault;
                break;
            case materialGlass:
                statement.matter.name = materialGlass;
                break;
            case materialHologram:
                statement.matter.name = materialHologram;
                break;
            case materialMetal:
                statement.matter.name = materialMetal;
                break;
            default:
                break;
        }
    }

    private void ResetConditionValues()
    {
        statement.airborneCondition = Conditions.Ignore;
        statement.movingCondition = Conditions.Ignore;
        statement.destroyCondition = Conditions.Ignore;
        statement.matter.name = "";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorObject : MonoBehaviour {

    public Statement statement;
    public Manipulatable currentManipulatable;

	public void UpdateStatement()
    {
        statement.manipulatable = currentManipulatable;
    }
}

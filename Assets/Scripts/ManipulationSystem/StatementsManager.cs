using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatementsManager : Singleton<StatementsManager> {

    public Statement[] statements;

    public void CheckStatement()
    {
        bool levelCompleted = true;

        foreach (var statement in statements)
        {
            if (!statement.TryStatement())
                levelCompleted = false;
        }

        if (levelCompleted)
            Debug.Log("I COMPLETED THE LEVEL");
    }

    public void UpdateStatement(Statement statement)
    {

    }
}
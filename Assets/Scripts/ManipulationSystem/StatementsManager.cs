using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatementsManager : Singleton<StatementsManager> {

    public Statement[] statements;
    public Door door;

    public void CheckStatement()
    {
        bool levelCompleted = true;

        foreach (var statement in statements)
        {
            if (!statement.TryStatement())
                levelCompleted = false;
        }

        if (levelCompleted)
            door.OpenDoor();

    }

    public void UpdateStatement(Statement statement)
    {

    }
}
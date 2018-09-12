using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatementsManager : Singleton<StatementsManager> {

    public void CheckStatement(Statement statement)
    {
        if(statement.TryStatement())
            Debug.Log("YEE");
    }
}
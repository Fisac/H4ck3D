using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonitorStatement : MonoBehaviour {

    public Statement statement;
    public MonitorObject monitorObject;
    public Text textA, textB;

    private void Awake()
    {
        monitorObject.statement = statement;
    }

    void Start () {
		
	}
	
}

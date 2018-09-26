using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameStateManager))]
public class GameStateManagerEditor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GameStateManager gsManager = (GameStateManager)target;

        GUILayout.Box("Load"); 

        if(GUILayout.Button("LoadScene"))
        {
            gsManager.LoadLevel(); 
        }
    }
}

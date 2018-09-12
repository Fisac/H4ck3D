using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MaterialTest))]
public class MaterialTestEditor : Editor {
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        MaterialTest mat = (MaterialTest)target;

        GUILayout.Box("Test"); 

        if(GUILayout.Button("TestMaterial"))
        {
            mat.ChangeMatter();
        }
    }
}

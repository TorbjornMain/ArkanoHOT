using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelData))]
public class LevelDataEditor : Editor {
    public override void OnInspectorGUI()
    {
        if(GUILayout.Button("Open Level Editor"))
        {
            LevelDataEditorProps.levelToEdit = (LevelData)target;
            LevelDataEditorWindow.Init();
        }
    }
}

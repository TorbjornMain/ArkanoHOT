using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable()]
public class LevelDataEditorProps
{
    [Range(1, int.MaxValue)]
    [SerializeField()]
    public static int numBlocksWide = 9;
    [Range(1, int.MaxValue)]
    [SerializeField()]
    public static int numBlocksHigh = 10;
    [SerializeField()]
    public static Vector3 centre = new Vector3(0, 0, -2);
    [SerializeField()]
    public static Vector3 blockScale = new Vector3(1, 1, 0.5f);
    [SerializeField()]
    public static LevelData levelToEdit;
}

public class LevelDataEditor : EditorWindow {


    [MenuItem("Window/Level Editor")]
    static void Init()
    {
        LevelDataEditor lde = (LevelDataEditor)GetWindow(typeof(LevelDataEditor));
        lde.Show();
    }

    private void OnGUI()
    {
        loadPrefs();
        if (LevelDataEditorProps.levelToEdit != null)
        {
            LevelDataEditorProps.levelToEdit.spawnPoints.Clear();
            if(LevelDataEditorProps.levelToEdit.spawnGrid == null)
            {
                LevelDataEditorProps.levelToEdit.spawnGrid = new bool[LevelDataEditorProps.numBlocksWide * LevelDataEditorProps.numBlocksHigh];
            }
            if(LevelDataEditorProps.levelToEdit.spawnGrid.Length != LevelDataEditorProps.numBlocksWide * LevelDataEditorProps.numBlocksHigh)
            {
                LevelDataEditorProps.levelToEdit.spawnGrid = new bool[LevelDataEditorProps.numBlocksWide * LevelDataEditorProps.numBlocksHigh];
            }

            if (GUILayout.Button("Clear"))
            {
                for (int i = 0; i < LevelDataEditorProps.levelToEdit.spawnGrid.Length; i++)
                {
                    LevelDataEditorProps.levelToEdit.spawnGrid[i] = false;
                }
            }
            if (GUILayout.Button("Fill"))
            {
                for (int i = 0; i < LevelDataEditorProps.levelToEdit.spawnGrid.Length; i++)
                {
                    LevelDataEditorProps.levelToEdit.spawnGrid[i] = true;
                }
            }

            EditorGUILayout.BeginVertical();
            for (int y = 0; y < LevelDataEditorProps.numBlocksHigh; y++)
            {
                EditorGUILayout.BeginHorizontal();
                for(int x = 0; x < LevelDataEditorProps.numBlocksWide; x++)
                {
                    LevelDataEditorProps.levelToEdit.spawnGrid[x + LevelDataEditorProps.numBlocksWide * y] = EditorGUILayout.Toggle(LevelDataEditorProps.levelToEdit.spawnGrid[x + LevelDataEditorProps.numBlocksWide * y]);
                    if (LevelDataEditorProps.levelToEdit.spawnGrid[x + LevelDataEditorProps.numBlocksWide * y])
                    {
                        float xp = (LevelDataEditorProps.centre.x - ((LevelDataEditorProps.numBlocksWide / 2.0f) * LevelDataEditorProps.blockScale.x)) + (x * LevelDataEditorProps.blockScale.x) + LevelDataEditorProps.blockScale.x/2;
                        float zp = -((LevelDataEditorProps.centre.z - ((LevelDataEditorProps.numBlocksHigh / 2.0f) * LevelDataEditorProps.blockScale.z)) + (y * LevelDataEditorProps.blockScale.z) + LevelDataEditorProps.blockScale.z/2);
                        LevelDataEditorProps.levelToEdit.spawnPoints.Add(new Vector3(xp, LevelDataEditorProps.centre.y, zp));
                    }
                }
                EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndVertical();
            EditorUtility.SetDirty(LevelDataEditorProps.levelToEdit);
        }

        EditorGUILayout.BeginHorizontal();
        LevelDataEditorProps.numBlocksWide = EditorGUILayout.IntField("Num. Blocks Wide", LevelDataEditorProps.numBlocksWide);
        LevelDataEditorProps.numBlocksHigh = EditorGUILayout.IntField("Num. Blocks High", LevelDataEditorProps.numBlocksHigh);
        EditorGUILayout.EndHorizontal();
        LevelDataEditorProps.centre = EditorGUILayout.Vector3Field("Centre Pos", LevelDataEditorProps.centre);
        LevelDataEditorProps.blockScale = EditorGUILayout.Vector3Field("Block Scale", LevelDataEditorProps.blockScale);
        LevelDataEditorProps.levelToEdit = (LevelData)EditorGUILayout.ObjectField("Level To Edit", LevelDataEditorProps.levelToEdit, typeof(LevelData), false);
        savePrefs();
    }

    private void savePrefs()
    {
        EditorPrefs.SetInt("NumBlocksWide", LevelDataEditorProps.numBlocksWide);
        EditorPrefs.SetInt("NumBlocksHigh", LevelDataEditorProps.numBlocksHigh);
        EditorPrefs.SetFloat("centreX", LevelDataEditorProps.centre.x);
        EditorPrefs.SetFloat("centreY", LevelDataEditorProps.centre.y);
        EditorPrefs.SetFloat("centreZ", LevelDataEditorProps.centre.z);
        EditorPrefs.SetFloat("blockScaleX", LevelDataEditorProps.blockScale.x);
        EditorPrefs.SetFloat("blockScaleY", LevelDataEditorProps.blockScale.y);
        EditorPrefs.SetFloat("blockScaleZ", LevelDataEditorProps.blockScale.z);
    }

    private void loadPrefs()
    {
        LevelDataEditorProps.numBlocksWide = EditorPrefs.GetInt("NumBlocksWide", LevelDataEditorProps.numBlocksWide);
        LevelDataEditorProps.numBlocksHigh = EditorPrefs.GetInt("NumBlocksHigh", LevelDataEditorProps.numBlocksHigh);
        LevelDataEditorProps.centre.x = EditorPrefs.GetFloat("centreX", LevelDataEditorProps.centre.x);
        LevelDataEditorProps.centre.y = EditorPrefs.GetFloat("centreY", LevelDataEditorProps.centre.y);
        LevelDataEditorProps.centre.z = EditorPrefs.GetFloat("centreZ", LevelDataEditorProps.centre.z);
        LevelDataEditorProps.blockScale.x = EditorPrefs.GetFloat("blockScaleX", LevelDataEditorProps.blockScale.x);
        LevelDataEditorProps.blockScale.y = EditorPrefs.GetFloat("blockScaleY", LevelDataEditorProps.blockScale.y);
        LevelDataEditorProps.blockScale.z = EditorPrefs.GetFloat("blockScaleZ", LevelDataEditorProps.blockScale.z);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Level", menuName ="Level")]
public class LevelData : ScriptableObject {
    public List<Vector3> spawnPoints;
    public bool[] spawnGrid;
}

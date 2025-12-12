using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ObstacleInfo
{
    public int id;
    public Vector3 position;
    public Vector3 size;
    public float speed;
    public float time;
}

[CreateAssetMenu(fileName = "PaternScriptObject", menuName = "Scriptable Objects/PaternScriptObject")]
public class PaternScriptObject : ScriptableObject
{
    public List<ObstacleInfo> obstacleList;
}

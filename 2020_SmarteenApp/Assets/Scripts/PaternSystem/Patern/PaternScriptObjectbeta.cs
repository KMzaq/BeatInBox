using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class ObstacleBeta
{
   public List<ObstacleInfo> obstacles;
}
[CreateAssetMenu(fileName = "PaternScriptObject", menuName = "Scriptable Objects/PaternScriptObjectbeta")]
public class PaternScriptObjectbeta : ScriptableObject
{
    public List<ObstacleBeta> obstacleList;
}

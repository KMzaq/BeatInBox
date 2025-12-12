using System;
using UnityEngine;


public interface IObstacle
{
    public void Initialize(Vector3 direction, float speed, Action endFunc);
    public void Play();

    public void End();
}

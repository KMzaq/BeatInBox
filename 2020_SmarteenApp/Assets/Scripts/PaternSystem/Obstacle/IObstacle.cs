using System;
using UnityEngine;


public interface IObstacle
{
    public void Initialize(float speed, Action endFunc);
    public void Play();

    public void End();
}

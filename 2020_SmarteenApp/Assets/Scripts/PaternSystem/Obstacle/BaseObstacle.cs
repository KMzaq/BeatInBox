using System;
using UnityEngine;

public class BaseObstacle : MonoBehaviour, IObstacle
{
    protected float _speed;
    protected Action _endFuck;


    public virtual void Initialize(float speed, Action endFunc)
    {
        _speed = speed;
    }

    public virtual void Play()
    {
        Debug.Log("장애물실행");
    }

    public virtual void End()
    {
        _endFuck.Invoke();
    }
}

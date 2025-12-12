using System;
using UnityEngine;

public class BaseObstacle : MonoBehaviour, IObstacle
{
    protected Vector3 _direction;
    protected float _speed;
    protected Action _endFunc;

    private bool _endOnce;
    public virtual void Initialize(Vector3 direction, float speed, Action endFunc)
    {
        _direction = direction.normalized;
        _speed = speed;
        _endFunc = endFunc;
        _endOnce = false;
    }

    public virtual void Play()
    {
        Debug.Log("장애물실행");
    }

    public virtual void End()
    {
        if (_endOnce) return;
        _endOnce = true;
        _endFunc.Invoke();
    }
}

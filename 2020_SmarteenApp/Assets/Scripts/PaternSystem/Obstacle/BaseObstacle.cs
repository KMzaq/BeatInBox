using System;
using UnityEngine;

public class BaseObstacle : MonoBehaviour, IObstacle
{
    protected Vector3 _vectorData;
    protected float _floatData;
    protected Action _endFunc;

    private bool _endOnce;
    public virtual void Initialize(Vector3 vectorData, float floatData, Action endFunc)
    {
        _vectorData = vectorData;
        _floatData = floatData;
        _endFunc = endFunc;
        _endOnce = false;
    }

    public virtual void Play()
    {
        
    }

    public virtual void End()
    {
        if (_endOnce) return;
        _endOnce = true;

        _endFunc?.Invoke();
        Destroy(this.gameObject);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "wall")
        {
            End();
        }
    }
}

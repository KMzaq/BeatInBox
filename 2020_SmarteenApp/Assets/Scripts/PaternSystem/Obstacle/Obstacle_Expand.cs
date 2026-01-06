using System.Collections;
using UnityEngine;

public class Obstacle_Expand : BaseObstacle
{
    

    private Vector3 _direction
    {
        get
        {
            return _vectorData.normalized;
        }
        set
        {
            _vectorData = value;
        }
    }

    private float _speed
    {
        get
        {
            return _floatData;
        }
        set
        {
            _floatData = value;
        }
    }

    public override void Play()
    {
        base.Play();
        StartCoroutine(PlayCoroutine());
        
    }

    IEnumerator PlayCoroutine()
    {
        //


        while (true)
        {
            var value = _direction * _speed * Time.deltaTime;

            Vector3 absValue = new Vector3(Mathf.Abs(value.x),
                                           Mathf.Abs(value.y), 
                                           0
            );

            this.transform.localScale += absValue;
            this.transform.position += value * 0.5f;

            yield return null;
        }
    }
}

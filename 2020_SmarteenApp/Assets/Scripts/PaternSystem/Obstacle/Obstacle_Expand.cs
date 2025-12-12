using System.Collections;
using UnityEngine;

public class Obstacle_Expand : BaseObstacle
{
    private bool _isPlaying;


    public override void Play()
    {
        base.Play();
        StartCoroutine(PlayCoroutine());
    }

    IEnumerator PlayCoroutine()
    {
        _isPlaying = true;
        while (_isPlaying)
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

        yield break;
    }

    public override void End()
    {
        _isPlaying = false;
        base.End();
    }
}

using System;
using System.Collections;
using UnityEngine;

public class Obstacle_Straight : BaseObstacle
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
            this.transform.position += _direction * _speed * Time.deltaTime;

            //È¥µ·ÆÄ±«¸Á°¢Á¶°Ç

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

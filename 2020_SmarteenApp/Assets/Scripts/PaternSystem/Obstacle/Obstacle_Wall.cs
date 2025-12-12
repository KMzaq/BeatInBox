using System.Collections;
using UnityEngine;

public class Obstacle_Wall : BaseObstacle
{
    public override void Play()
    {
        base.Play();
        StartCoroutine(PlayCoroutine());
    }

    IEnumerator PlayCoroutine()
    {
        yield return new WaitForSeconds(_speed);
        End();
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "obj")
        {
            if (GameManager.Char_dead == false)
                pointsystem.Point += 1;

            if (collision.TryGetComponent<IObstacle>(out var comp))
            {
                comp.End();
            }

            //점수추가
            Destroy(collision.gameObject);

        }
    }
}

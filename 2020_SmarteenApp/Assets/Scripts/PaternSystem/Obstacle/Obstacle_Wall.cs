using System.Collections;
using UnityEngine;

public class Obstacle_Wall : BaseObstacle
{
    [SerializeField] private SpriteRenderer miniSpriteRenderer;
    private SpriteRenderer m_spriteRenderer;
    private Collider2D m_collider;

    private void Awake()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_collider = GetComponent<Collider2D>();
        m_collider.enabled = false;
    }

    public override void Play()
    {
        base.Play();
        StartCoroutine(PlayCoroutine());
    }

    IEnumerator PlayCoroutine()
    {
        miniSpriteRenderer.transform.localScale = Vector3.zero;
        //채우기
        while (miniSpriteRenderer.transform.localScale.x < 1)
        {
            miniSpriteRenderer.transform.localScale += Vector3.one * Time.deltaTime;
            yield return null;
        }

        //피격판정 0.9
        //줄이기
        m_spriteRenderer.color = new Color(m_spriteRenderer.color.r, m_spriteRenderer.color.g, m_spriteRenderer.color.b, 1);

        var hit = Physics2D.OverlapBox(this.transform.position, this.transform.localScale * 0.9f, 0, 1 << LayerMask.NameToLayer("Player"));
        if (hit)
        {
            hit.GetComponent<PlayerMove>().Die();
            Destroy(this);
            yield break;
        }

        m_collider.enabled = true;

        yield return new WaitForSeconds(_floatData - 1);

        miniSpriteRenderer.transform.localScale = Vector3.zero;
        miniSpriteRenderer.enabled = false;
        //채우기
        while (miniSpriteRenderer.transform.localScale.x < 1)
        {
            miniSpriteRenderer.transform.localScale += Vector3.one * Time.deltaTime;
            yield return null;
        }

        End();
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

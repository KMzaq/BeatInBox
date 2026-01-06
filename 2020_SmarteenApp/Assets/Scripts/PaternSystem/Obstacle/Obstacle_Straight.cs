using System.Collections;
using UnityEngine;

public class Obstacle_Straight : BaseObstacle
{
    [SerializeField] private Collider2D m_collider;
    [SerializeField] private SpriteRenderer m_spriteRenderer;
    [SerializeField] private SpriteRenderer miniSpriteRenderer;

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
        m_collider.enabled = false;
        StartCoroutine(PlayCoroutine());
    }


    IEnumerator PlayCoroutine()
    {

        float angle = Mathf.Atan2(-_direction.x, _direction.y) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(0, 0, angle);

        miniSpriteRenderer.transform.localScale = Vector3.zero;
        //Ã¤¿ì±â
        while (miniSpriteRenderer.transform.localScale.x < 1)
        {
            miniSpriteRenderer.transform.localScale += Vector3.one * Time.deltaTime;
            yield return null;
        }

        m_spriteRenderer.color = new Color(m_spriteRenderer.color.r, m_spriteRenderer.color.g, m_spriteRenderer.color.b, 1);
        m_collider.enabled = true;
        while (true)
        {
            this.transform.position += _direction * _speed * Time.deltaTime;
            yield return null;
        }
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerMove>().Die();
            Destroy(this);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Expand : BaseObstacle
{
    [SerializeField] private List<GameObject> arrowSpriteList; //»óÇÏÁÂ¿ì
    [SerializeField] private Transform miniSprite;

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
        if (_direction.x > 0)
        {
            arrowSpriteList[3].SetActive(true);
        }
        else if (_direction.x < 0)
        {
            arrowSpriteList[2].SetActive(true);
        }
        if (_direction.y > 0)
        {
            arrowSpriteList[0].SetActive(true);
        }
        else if (_direction.y < 0)
        {
            arrowSpriteList[1].SetActive(true);
        }

        Vector3 miniPos = new Vector3(-_direction.x / Mathf.Abs(_direction.x) * 0.5f, -_direction.y / Mathf.Abs(_direction.y) * 0.5f, 0);
        miniSprite.localPosition = miniPos;
        miniSprite.localScale = Vector3.zero;
        
        while (miniSprite.localScale.x < 1)
        {
            miniSprite.localScale += Vector3.one * Time.deltaTime;
            miniSprite.localPosition += _direction * 0.75f * Time.deltaTime;

            yield return null;
        }

        miniSprite.gameObject.SetActive(false);
        arrowSpriteList[0].SetActive(false);
        arrowSpriteList[1].SetActive(false);
        arrowSpriteList[2].SetActive(false);
        arrowSpriteList[3].SetActive(false);

        var spComp = this.GetComponent<SpriteRenderer>();
        Color color = spComp.color;
        color.a = 1;
        spComp.color = color;


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

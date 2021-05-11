using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ob_ef : MonoBehaviour
{
    Vector3 originPos;
    float _amount = 10;
    float ctime;
    Color color;

    void Start()
    {
        originPos = transform.localPosition;
        
    }

    void Update()
    {
        ctime += Time.deltaTime;
        if(ctime >= 0.7f && ctime < 2)
        {
            transform.localPosition = (Vector3)Random.insideUnitCircle * _amount + originPos;
        }
        else if (ctime >= 2 && ctime < 3)
        {

        }
        else if(ctime >= 3 && ctime < 3.5f)
        {

            this.gameObject.GetComponent<ParticleSystem>().Play();
            color.a = 0;
            this.gameObject.GetComponent<SpriteRenderer>().color = color;
        }
        else if(ctime >= 3.5f)
        {
            Timesysyem.Char_dead2 = true;
        }

    }
}

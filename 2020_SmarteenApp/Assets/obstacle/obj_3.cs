using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obj_3 : MonoBehaviour
{
    public GameObject obj;

    public SpriteRenderer spriteRenderer;


    Vector3 size, pos;


    public Vector2 infor;
    //infor.x = dir_1;  //1일경우 x축이동 2일경우 y축이동
    
    //infor.y = speed;
    //위치에 -한걸로 결정 = dir_2; //+-로 위아래 or 왼쪽 오른쪽 결정
    void Start()
    {

        spriteRenderer = obj.GetComponent<SpriteRenderer>();
        spriteRenderer.color = new UnityEngine.Color(1, 0, 0, 0.5f);  
        

        size = transform.localScale;
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //한쪽방향으로 점점 커짐 biggertime 동안
        if (infor.x == 1)
        {
            pos.x += infor.y * 0.45f * (transform.position.x / Mathf.Abs(transform.position.x) * -1);
            size.x += infor.y * GameManager.Skill_speed;
        }
        if (infor.x == 2)
        {
            pos.y += infor.y * 0.45f * (transform.position.y / Mathf.Abs(transform.position.y) * -1);
            size.y += infor.y * GameManager.Skill_speed;
        }
        

        
        //스케일 값 늘림
        transform.localScale = new Vector3(size.x,size.y,1);
        transform.position = new Vector3(pos.x, pos.y, 0);
        
        if (size.x >= 485 || size.y >= 485)
        {
            spriteRenderer.color = new UnityEngine.Color(1, 0, 0, 1f);

        }
    }
}

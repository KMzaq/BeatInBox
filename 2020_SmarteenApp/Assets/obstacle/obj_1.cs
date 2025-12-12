using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class obj_1 : MonoBehaviour
{

    public GameObject player;
    Vector2 objxy, playerxy;
    public GameObject obj;
    new Rigidbody2D rigidbody;
    public Vector3 movexy;
    public SpriteRenderer spriteRenderer ;
    float time,spontime;
    bool spown;

    public GameObject obj_trace;
    void Start()
    {
        spown = true; // 스폰두 유저의 위치를 받아와야 제대로 따라가기에 만들었다
        spontime = Time.time;
         player = GameObject.Find("player");
        rigidbody = obj.GetComponent<Rigidbody2D>();
        spriteRenderer = obj.GetComponent<SpriteRenderer>();

        spriteRenderer.color = new UnityEngine.Color(1,0,0,0.5f); //붉은색 나중에 0,0,0
      

    }
    
    void Update()
    {

        try
        {
            playerxy = player.transform.position;
        }
        catch (NullReferenceException)
        {
            Destroy(obj);
        }
        catch (MissingReferenceException)
        {
            Destroy(obj);
            Destroy(Ttrace);
        }


        if (spown == true)
        {
            spown = false;
            objxy = gameObject.transform.position;
            movexy = (objxy - playerxy);
            if (movexy.x < 0)
                movexy.x = movexy.x * -1;
            if (movexy.y < 0)
                movexy.y = movexy.y * -1;
            if (movexy.y - movexy.x > 0)
            {
                movexy.y = objxy.y - playerxy.y;
                movexy.x = 0;

            }
            else
            {
                movexy.x = objxy.x - playerxy.x;
                movexy.y = 0;

            }
            movexy = movexy.normalized;
            trace();
        }
        time +=  Time.time;
        // 색 진해짐 + 몇초뒤 실행시켜야함 if()
        if (spontime+1f <Time.time) 
        {   
           // time = 0;
             spriteRenderer.color = new UnityEngine.Color(1, 0, 0, 1f);
                rigidbody.linearVelocity = -movexy * 1000 * GameManager.Skill_speed;

            gameObject.GetComponentInChildren<obstacle_trail>().Traill();

        }
    }

    public GameObject Ttrace;
    private void trace()
    {
        Vector3 Creationpos = Vector3.zero;
        Vector3 Creationsize = Vector3.zero;

        if (movexy.x < 0)
        {
            //오른쪽
            Creationpos.x = 232;//오른쪽 벽 x값
            Creationpos.y = transform.position.y;

            Creationsize.x = 20;//오른쪽 벽 두께
            Creationsize.y = transform.localScale.y;
        }
        if(movexy.x > 0)
        {
            //왼쪽
            Creationpos.x = -232;//왼쪽 벽 x값
            Creationpos.y = transform.position.y;

            Creationsize.x = 20;//왼쪽 벽 두께
            Creationsize.y = transform.localScale.y;
        }
        if(movexy.y < 0)
        {
            //위
            Creationpos.x = transform.position.x;
            Creationpos.y = 232;//위쪽벽y

            Creationsize.x = transform.localScale.x;
            Creationsize.y = 20;//위쪽 벽 두께
        }
        if(movexy.y > 0)
        {
            //아래
            Creationpos.x = transform.position.x;
            Creationpos.y = -232;//아래쪽벽y

            Creationsize.x = transform.localScale.x;
            Creationsize.y = 20;//아래쪽 벽 두께
        }
        //그 오브젝트 소환
        Ttrace = Instantiate(obj_trace, new Vector3(Creationpos.x, Creationpos.y), Quaternion.identity);
        Ttrace.transform.localScale = new Vector3(Creationsize.x, Creationsize.y);  //사이즈
        
    }
}



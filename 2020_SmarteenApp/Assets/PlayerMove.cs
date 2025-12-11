using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class PlayerMove : MonoBehaviour
{
    const float speed = 2500;
    private SpriteRenderer spriteRenderer;

    public new Rigidbody2D rigidbody2D;
    Vector2 player_rot = Vector2.zero;
    Vector2 player_rot1 = Vector2.zero;
    public drag drag;
    public bool move = true;
    int movecount = 1;

    public AudioSource playerkong;
    public AudioSource playerdie;
    private bool moving_sound = true;
    

    private Vector3 pos1;

    public GameObject dead_ef;


    //움직일때 공중에서 한번 뒤로 움직일수있게해줌    


    //벽과 붙이치고 힘의 속도가 900이 아닐때일때 플레이어의 위치가 바뀌지않으면 move=false;
    //그리고 900이면 조작만 못하게 한다 반대로 돌아가는거면 한번 허락해준다
    void FixedUpdate()
    {
        // player_rot1 = player_rot;
        //Debug.Log(movecount);

        if ((move == false && drag.Pmove == true) && movecount > 0)
        {
            
            if (drag.EventDrag == drag.Drag.y && rigidbody2D.linearVelocity.x == 0)
            {

                player_rot.y = drag.player_p;
                player_rot.x = 0;

            }
            if (drag.EventDrag == drag.Drag.x && rigidbody2D.linearVelocity.y == 0)
            {

                player_rot.x = drag.player_p;
                player_rot.y = 0;

            }
            if (player_rot.x != 0 || player_rot.y != 0)
            {

                move = true;
                //Debug.Log(move);
                if(Timesysyem.GameStart == 0)
                    Timesysyem.GameStart = 1;
                //if (pos1 != transform.position)
                    moving_sound = true;
                pos1 = transform.position;

            }

            player_rot.Normalize();

            if (movecount == 2)
            {

                player_rot1 = player_rot;
                movecount--;

            }

        }




        //Debug.Log(player_rot);
        //Debug.Log(player_rot1);
        if (player_rot1 != player_rot)
        {

            movecount--;

        }


        rigidbody2D.linearVelocity = new Vector2(player_rot.x * speed , player_rot.y * speed);

        if (rigidbody2D.linearVelocity.x == 0 || rigidbody2D.linearVelocity.y == 0)
        {
            stop();
        }
        //그리고 +-만 바뀌면 그대로 실행한다

        //x축으로 움직이고 돌아갈때 그리고 버그가 일어나면
        //x축으로 가다 붙이친 오브젝트와 x축인것을 저장하고 
        //y축으로 움직일땐 잠시 오브젝트 멈추는것을 못하게한다
        //그리고 한번 드레그후 그전 움직임과 다른방향으로 움직이게 되면
        //데이터를 다시저장한다

    }
   



    private void OnCollisionStay2D(Collision2D collision)
    {


        if (rigidbody2D.linearVelocity == new Vector2(0, 0))
        {

            player_rot1 = new Vector2(0, 0);
            movecount = 2;

            
                if (moving_sound == true && pos1 != transform.position)
                {

                    playerkong.Play();
                    Vibration.Vibrate((long)(5 * Timesysyem.vibe));
                    
                    moving_sound = false;

                }
            


            stop();
        }
        

    }
    private void OnTriggerStay2D(Collider2D other)
    {
        spriteRenderer = other.gameObject.GetComponent<SpriteRenderer>();
        if (other.tag == "obj" || other.tag == "obj_intrail")
        {
            if (spriteRenderer.color.a > 0.5f)
            {
                /////////////////////////////////////////////////////////
                playerdie.Play();
                Vibration.Vibrate((long)(100 * Timesysyem.vibe));
                Timesysyem.Char_dead = true;


                //캐릭터 이미지 정보 받아서 부들거리다 터지는거 소환
                GameObject caef = Instantiate(dead_ef, this.gameObject.transform.position, Quaternion.identity);
                caef.GetComponent<SpriteRenderer>().sprite = this.gameObject.GetComponent<SpriteRenderer>().sprite;
                Color color = this.gameObject.GetComponentInChildren<TrailRenderer>().startColor;
                color.a = 1;
                caef.GetComponent<ParticleSystem>().startColor = color;

                Destroy(gameObject);
                //장애물 정보 받아서 obj면 정보에 따라 소환, 트레일 있으면 트레일이랑 날아가는거 정지
                if(other.tag == "obj")
                {
                    if (other.transform.localScale.z == 1)
                        other.GetComponent<obj_2>().enabled = false;
                    else
                        other.GetComponent<obj_3>().enabled = false;
                }
                if(other.tag == "obj_intrail")
                {
                    other.GetComponent<obj_1>().enabled = false;
                    other.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, 0);
                    other.transform.GetChild(0).GetComponent<TrailRenderer>().time = 30f;
                } //뭐지 막상 이럴거면 태그 분류 왜한거지

                //Timesysyem.Char_dead2 = true; //연출 후에 실행
                
                ///////////////////////////////////////////////////////////////
            }
        }
    }
    void stop()
    {
            

        move = false;
        drag.Pmove = false;
        //player_rot = new Vector2(0, 0);
        drag.player_p = 0;

        
        
    }

}
//블럭이 떨어지는 판정칸을만들어서 블럭이 떨어지지않고
//새로운 벽과 만나서 멈추게됬을때 
//그전에있던 방향도 저장해서 그방향도 못가게 해야함
























/*
   public new Rigidbody2D rigidbody2D;
    public drag drag;
    Vector2 player_rot = Vector2.zero;
    public enum Player_Move { stop, move }
    public Player_Move playermove = Player_Move.stop;
    int count_ = 0;
    public Vector3 stopos;

    void Update()
    {


        if (playermove == Player_Move.stop) //멈춰있을때 시작함
        {


        }
        else if (playermove == Player_Move.move)//움직일때
        {
            if (count_ == 0)
            {
                stopos = transform.position;
            }
            if (count_==0)
                stopos = transform.position;
            count_++;
            //transform.Translate(player_rot*0.15f, 0);
            rigidbody2D.velocity = new Vector2(player_rot.x * 9f, player_rot.y * 9f);
            if (count_ >= 2&&stopos==gameObject.transform.position)
            {
                Debug.Log("움직인닷");
                stop_();
            }

        }
            if (count_ == 0)
            {
                stopos = transform.position;

            }

                count_++;
            if (count_ >= 4 && stopos == gameObject.transform.position)
            {
                stop_();
            }
        if (drag.Pmove&& playermove != Player_Move.move)
        {



            Debug.Log(stopos);
            Debug.Log(gameObject.transform.position);
            //카운트를 해서 1카운트와 3카운트를  비교했을때 큐브 위치가 같으면 stop으로 변경해준다 일단 이것으로 플레이어의 버그를 잡아준다
            //이버그는 붙어있을때 같은방향으로 움직였을때 벽과 붙어있기때문에 벽과 붙었다는 판정이 나지않아서 계속 움직이고 있다고 뜨는버그이다
            //이버그 때문에 벽에 두번 드레그를하면 못움직이는 버그가있었다
            //같은 방향 드레그는 간단하게 씹어주어야한다
            //여기서 한번움직이면  못움직이게 정하고 
            //if문으로 날라가는 위치를 받고서 그반대되는 위치만 허락해준다
            //그것도 한번만
            //벽에닿으면 초기화
            //시발 버그땜시 지운거 너무많아서 다시해야한다 시바

            if (drag.EventDrag == drag.Drag.x)     //방향을 정함
            {
                player_rot.x = drag.player_p;
                player_rot.y = 0;
            }
            if (drag.EventDrag == drag.Drag.y)
            {
                player_rot.y = drag.player_p;
                player_rot.x = 0;
            }
            if(player_rot.x !=0 || player_rot.y != 0)
            {
                playermove = Player_Move.move;
            }
            player_rot = player_rot.normalized;
            Debug.Log(player_rot);

        }

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(this.rigidbody2D.velocity.x==0&& this.rigidbody2D.velocity.y == 0)
            stop_();
    }

    void stop_()
    {
        count_ = 0;
        Debug.Log("멈춤");
        drag.Pmove = false;
        player_rot = Vector2.zero;
        drag.player_p = 0;
        playermove = Player_Move.stop; //멈췄다고 넣어줌
        drag.drag_ = true; 
        drag.tuch =  true   ;
    }


}

     
     */

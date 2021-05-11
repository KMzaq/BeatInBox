using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.EventSystems;

public class drag : MonoBehaviour, IDragHandler, IEndDragHandler//, IPointerDownHandler, IPointerUpHandler   //특능발동용
{
    public PlayerMove playerMove;
    public enum Drag { x, y };
    public Drag EventDrag;
    public Vector2 Drag_pos_normal; //드레그 위치
    public Vector2 Drag_pos_start;
    public Vector2 Drag_pos;
    public float player_p;
    public bool tuch, drag_, Pmove;

    //특수능력관련
    //[SerializeField]
    //public bool skill = false;

    //public Vector2 touch_pos_start;
    //public Vector2 touch_pos_end;

    //private float SK_time = 5f;     //능력 지속 시간
    //private float Cool_time = 40f;   //능력 발동 쿨타임

    //private float Ttime;
    ////

    //터치 -드레그 순으로 받아서  -터치(첫위치) + 드레그(조금 이동후 위치) 를 빼준후 몇 이상 차이가 날때 그방향으로 normalized 를 사용한다
    //                                   
    public void OnDrag(PointerEventData eventData)
    {

        if (tuch == false)
        {
            Drag_pos_start = eventData.position;
            drag_ = false;
        }
        if (tuch == true)
        {
            Drag_pos = eventData.position;
            drag_ = true;
        }

        if ((-50 > Drag_pos.x - Drag_pos_start.x || Drag_pos.x - Drag_pos_start.x > 50 ||
            -50 > Drag_pos.y - Drag_pos_start.y || Drag_pos.y - Drag_pos_start.y > 50) && drag_ == true
           )
        {


            Pmove = true;
            //벽이 붙은 위치를 보고 x에 넣을지 y에 넣을지 정할수도있다
            tuch = false;
            Drag_pos_normal = (Drag_pos - Drag_pos_start);
            if (Drag_pos_normal.x < 0)
                Drag_pos_normal.x = Drag_pos_normal.x * -1;
            if (Drag_pos_normal.y < 0)
                Drag_pos_normal.y = Drag_pos_normal.y * -1;
            if (Drag_pos_normal.y - Drag_pos_normal.x > 0)
            {
                EventDrag = Drag.y;
                player_p = (Drag_pos.y - Drag_pos_start.y);


            }
            else
            {
                EventDrag = Drag.x;
                player_p = (Drag_pos.x - Drag_pos_start.x);
            }

            drag_ = false;
            player_p = (float)Math.Truncate(player_p);
        }
        else
        {
            //버그 고침
            tuch = true;

        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        tuch = false;
    }


    //특수능력 발동

    //IEnumerator Timer()
    //{
    //    yield return new WaitForSeconds(1f);

    //    Ttime++;
    //    if (Ttime >= SK_time && Ttime < SK_time + Cool_time)
    //    {
    //        Timesysyem.Skill_speed = 1f;
    //        print("스킬꺼짐");
    //    }
    //    else if (Ttime >= SK_time + Cool_time)
    //    {
    //        print("쿨타임끝남");
    //        skill = false;
    //        Ttime = 0;
    //    }
            
    //    if(skill == true)
    //        StartCoroutine("Timer");
    //}

    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    touch_pos_start = eventData.position;
    //}

    //public void OnPointerUp(PointerEventData eventData)
    //{
    //    touch_pos_end = eventData.position;
    //    if (touch_pos_start == touch_pos_end)
    //    {
    //        if (skill == false)
    //        {
    //            if (pointsystem.Point >= 10)
    //            {
    //                pointsystem.Point -= 10;
    //                print("스킬발동");
    //                skill = true;
    //                Timesysyem.Skill_speed = 0.5f;
    //                StartCoroutine("Timer"); 
    //            }
    //        }
    //    }
    //}
}



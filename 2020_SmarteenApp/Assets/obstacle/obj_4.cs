using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ////////////////일단 포기 할거면 다른것도 다 바꿔야함
/// </summary>
public class obj_4 : MonoBehaviour
{
    public int spawnpoint;
    public int movepoint;

    public GameObject obj;
    new Rigidbody2D rigidbody;
    public SpriteRenderer spriteRenderer;

    float time, spontime;
    public Vector3 movexy;

    public GameObject obj_trace;

    Vector3 waspos;

    bool onetime;
    void Start()
    {
        rigidbody = obj.GetComponent<Rigidbody2D>();
        spontime = Time.time;

        spriteRenderer = obj.GetComponent<SpriteRenderer>();

        spriteRenderer.color = new UnityEngine.Color(1, 0, 0, 0.5f); //붉은색 나중에 0,0,0

        movexy = new Vector2(0, 0);
        waspos = transform.position;
        onetime = true;
    }

    // Update is called once per frame
    void Update()
    {

        //현황 개각선 이동후 위로 직선 이동
        //이거 두번하면 ㄱㅊ을듯
        //정해진 방향으로 이동
        //move값에 값 입력

        //이동이 끝난후 한번 더 이동
        if (transform.position.y <= -176)
        {
            if (onetime == true)
            {
                time = 0;
                waspos = transform.position;
                movexy.y = 0;
                movexy.x = -1;

                onetime = false;
            }
        }
        else
        {
            movexy.y = -1;
        }



        // 색 진해짐 + 몇초뒤 실행시켜야함 if()
        if (spontime + 1f < Time.time)
        {
            time += Time.deltaTime;
            spriteRenderer.color = new UnityEngine.Color(1, 0, 0, 1f);

            transform.position = Vector3.Lerp(waspos, new Vector3(waspos.x * movexy.x, waspos.y * movexy.y, waspos.z), time);

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
        if (movexy.x > 0)
        {
            //왼쪽
            Creationpos.x = -232;//왼쪽 벽 x값
            Creationpos.y = transform.position.y;

            Creationsize.x = 20;//왼쪽 벽 두께
            Creationsize.y = transform.localScale.y;
        }
        if (movexy.y < 0)
        {
            //위
            Creationpos.x = transform.position.x;
            Creationpos.y = 232;//위쪽벽y

            Creationsize.x = transform.localScale.x;
            Creationsize.y = 20;//위쪽 벽 두께
        }
        if (movexy.y > 0)
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

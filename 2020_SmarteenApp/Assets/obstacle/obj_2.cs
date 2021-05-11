using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class obj_2 : MonoBehaviour
{
    public GameObject player;
    Vector2 objxy, playerxy;
    public GameObject obj;
    public Vector3 movexy;
    float time = 0f;
    float F_time = 0.7f; //완전히 커지는데 걸리는 시간
    float Z_time = 0.7f; //생성되고 커지는데 걸리는 시간
    float curtime;

    void Start()
    {
        player = GameObject.Find("player");
        try {  playerxy = player.transform.position;} catch (NullReferenceException) { Destroy(obj); }
       
        objxy = gameObject.transform.position;
        trace();
    }
    //Mathf.Lerp(startsize, maxsize, time)
    // Update is called once per frame
    void Update()
    {
        curtime += Time.deltaTime;
        if (curtime > Z_time)
        {
            time += Time.deltaTime / F_time;
            obj.transform.position = new Vector3( movexy.x * Mathf.Lerp(0, 90, time), movexy.y * Mathf.Lerp(0, 90, time), 0);
            obj.transform.localScale = new Vector3(Mathf.Lerp(100, 300, time), Mathf.Lerp(100, 300, time), 1);
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    private void trace()
    {

        transform.GetChild(0).gameObject.transform.localScale = movexy;

    }
}

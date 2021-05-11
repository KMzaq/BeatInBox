using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

public class PT_system : MonoBehaviour
{

    List<Dictionary<string, object>> data;
    public GameObject yab;
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    private GameObject _obj;
    private int random, pattern_num;
    private float posx, posy, sizex, sizey, ability, spawn_time, time, time1;
    private bool event_ = true;
    public int pettern;
        [SerializeField] const int LevelDelay_time = 1;

        [SerializeField] const int EasyTime = 40;
        [SerializeField] const int NormalTime = 60;
        [SerializeField] const int HardTime = 80;

        [SerializeField] const int EasyPattern = 19;
        [SerializeField] const int NormalPattern = 33;
        [SerializeField] const int HardPattern = 35;
    
    enum leveldifficulty {Easy,normal,Hard};
    leveldifficulty nowlevel;

    int difficultyTime,difficultypattern;
    float timer =0,delaytiem;
    bool delay,SP;

    void Start()
    {
        delay = true;
        nowlevel = leveldifficulty.Easy;
        difficultypattern = EasyPattern;
        difficultyTime = EasyTime;
        data = CSVReader.Read("stack");
    }

    // Update is called once per
    void Update()
    {
       
      //print(timer+" " + difficultyTime);
 
        if (timer > difficultyTime  && SP == false)
        {
               
                delay = true;
                timer = 0;
                
                switch (nowlevel)
                {
                case leveldifficulty.Easy :
                    print("normal");
                    nowlevel = leveldifficulty.normal;
                    difficultypattern = NormalPattern;
                    difficultyTime = NormalTime;

                    Timesysyem.nanido_bgmspeed = 1.2f;

                    break;
                case leveldifficulty.normal:
                    print("hard");
                    nowlevel = leveldifficulty.Hard;
                    difficultypattern = HardPattern;
                    difficultyTime = HardTime;

                    Timesysyem.nanido_bgmspeed = 1.5f;
                    break;
                case leveldifficulty.Hard:
                    print("EZ");
                    nowlevel = leveldifficulty.Easy;
                    difficultypattern = EasyPattern;
                    difficultyTime = EasyTime;

                    Timesysyem.nanido_bgmspeed = 1f;
                    break;
                 }
          
           
        }
        if (delay == true)
        {
           
            //if문으로 패턴 실행중이면 실행시키지않는다
            if (event_ == true)
            {
              
                random = (int)UnityEngine.Random.Range(1, difficultypattern);
                //UnityEngine.Debug.Log(random);
                switch (random)
                { //패턴 추가시 그패턴의 시작지점 

                    case 1:
                        pettern = 0;//시작지점은 무조건0번부터시작한다 
                        break;
                    case 2:
                        pettern = 2;
                        break;
                    case 3:
                        pettern =4;
                        break;
                    case 4:
                        pettern = 6;
                        break;
                    case 5:
                        pettern = 8;
                        break;
                    case 6:
                        pettern = 9;
                        break;
                    case 7:
                        pettern = 10;
                        break;
                    case 8:
                        pettern = 11;
                        break;
                    case 9:
                        pettern = 12;
                        break;
                    case 10:
                        pettern = 15;
                        break;
                    case 11:
                        pettern = 18;
                        break;
                    case 12:
                        pettern = 22;
                        break;
                    case 13:
                        pettern = 26;
                        break;
                    case 14:
                        pettern = 30;
                        break;
                    case 15:
                        pettern = 34;
                        break;
                    case 16:
                        pettern = 36;
                        break;
                    case 17:
                        pettern = 38;
                        break;
                    case 18:
                        pettern = 40;
                        break;
                    case 19:
                        pettern = 42;
                        break;
                    case 20:
                        pettern = 52;
                        break;
                    case 21:
                        pettern = 57;
                        break;
                    case 22:
                        pettern = 60;
                        break;
                    case 23:
                        pettern = 63;
                        break;
                    case 24:
                        pettern = 66;
                        break;
                    case 25:
                        pettern = 69;
                        break;
                    case 26:
                        pettern = 74;
                        break;
                    case 27:
                        pettern = 77;
                        break;
                    case 28:
                        pettern = 80;
                        break;
                    case 29:
                        pettern = 83;
                        break;
                    case 30:
                        pettern = 86;
                        break;
                    case 31:
                        pettern = 91;
                        break;
                    case 32:
                        pettern = 94;
                        break;
                    case 33:
                        pettern = 97;
                        break;
                    case 34:
                        pettern = 100;
                        break;



                }

                //패턴 값을 받아온다
                datalode(pettern);
                pattern_num = random;
                spawn_time = (float)spawn_time * 0.01f;
                //UnityEngine.Debug.Log(spawn_time + "      " + ability + "  " + sizex + "," + sizey + "          " + posx + "," + posy + "   ");
                //UnityEngine.Debug.Log("   스폰타임      능력    사이즈       x y   ");

                event_ = false;

            }

            try
            {

                if (spawn_time <= time1 && event_ == false)
                {
                    time1 += Time.deltaTime;
                    objectspawn(ability, sizex, sizey, posx, posy);
                 
                    time = 0;
                    if (pattern_num == (int)data[pettern + 1]["pt"])
                    {
                        SP = true;
                        pettern++;
                        datalode(pettern);
                        spawn_time = (float)spawn_time * 0.01f;
                    }
                    else
                    {

                        event_ = true;
                        SP = false;
                    }
                }


            }
            catch (ArgumentOutOfRangeException)
            {
                SP = false;
                event_ = true;
            }

            time += Time.deltaTime;
            time1 = time - Time.deltaTime;

           
            timer += Time.deltaTime;
            //랜덤값 
            // 실행 이벤트
            //실행된후 시간 측정
            //맞는 시간이 되었을때 OBJSPAWN 실행
            //실행
        }

    }
    private void objectspawn(float number, float sizex, float sizey, float posx, float posy)
    {

        if (delay == true) {
            GameObject _obj;

            switch (number)
            {
                case 0:
                    break;

                case 1:
                    _obj = Instantiate(object1, new Vector3(posx, posy), Quaternion.identity);
                    _obj.transform.localScale = new Vector3(sizex, sizey);  //사이즈
                    break;
                case 2:
                    _obj = Instantiate(object2);
                    _obj.GetComponent<obj_2>().movexy = new Vector2(sizex, sizey);
                    break;
                case 3:
                    _obj = Instantiate(object3, new Vector3(posx,posy), Quaternion.identity);
                    _obj.GetComponent<obj_3>().infor = new Vector2(sizex, sizey);
                    break;


            }
        }
        //_obj.transform.localPosition = new Vector3(posx, posy); //위치
        // _obj.transform.localScale = new Vector3(sizex, sizey);  //사이즈

    }
    void datalode(int pattern)
    {

        ability = (int)data[pattern]["ability"];
        spawn_time = (int)data[pattern]["spawn_time"];
        posx = (int)data[pattern]["posx"];
        posy = (int)data[pattern]["posy"];
        sizex = (int)data[pattern]["sizex"];
        sizey = (int)data[pattern]["sizey"];
    }
}

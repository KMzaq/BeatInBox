using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static LevelManager;

public class GameManager : MonoBehaviour
{
    public static float Skill_speed;
    public static float nanido_bgmspeed;

    public GameObject ptsys;
    public GameObject bgmm;
    public GameObject GameEnd;
    public GameObject stop_button;
    public static int GameStart; //0 = 시작 안함, 1= 시작,3초세는중, 2= 완전시작, 3= 작동중

    public static bool Char_dead;
    public static bool Char_dead2;

    public PaternManager paternManager;
    public PlayerMove playerMove;
    public LevelManager levelManager;


    public Text startText;
    private float startdelay;


    public static float vibe;
    public Slider backvolume;

    public Text nanidotext;


    private void Start()
    {
        SaveManager.Load();

        Skill_speed = 1f; //장애물 속도와 배경음악 속도
        nanido_bgmspeed = 1f; //난이도별 bgm 속도
        GameStart = 0;
        startdelay = 3f;
        Char_dead = false;
        Char_dead2 = false;


        paternManager.PaternEndEvent += EndPatern;

    }
    public void EndPatern()
    {

        if (levelManager.LevelUpCheck()) //레벨업 준비 확인
        {
            //레벨업 시켜주기
            levelManager.LevelUp();
            switch (levelManager.nowLevel)
            {
                case LevelEnum.Easy:
                    nanidotext.text = "EASY" + "   " + nanido_bgmspeed + "x";
                    nanidotext.color = new Color(1, 1, 1);
                    break;
                case LevelEnum.Nomal:
                    nanidotext.text = "NORMAL" + "   " + nanido_bgmspeed + "x";
                    nanidotext.color = new Color(1, 0.75f, 0.75f);
                    break;
                case LevelEnum.Hard:
                    nanidotext.text = "HARD" + "   " + nanido_bgmspeed + "x";
                    nanidotext.color = new Color(1, 0.5f, 0.5f);
                    break;

            }

            //플레이어 사이즈 변경, 다음 패턴실행
            levelManager.SizeUP(() => { paternManager.PlayPatern((int)levelManager.nowLevel); });
        }
        else
        {
            //다음 패턴 실행
            paternManager.PlayPatern((int)levelManager.nowLevel);
        }
    }

    private void Update()
    {
        vibe = backvolume.value;
        //print(vibe);

        if (GameStart == 1)
        {
            //3초세고 +1
            if (startdelay > 0)
                startdelay -= Time.deltaTime;

            startText.text = Mathf.Ceil(startdelay).ToString();

            if (startdelay < 0)
                GameStart = 2;
        }
        if (GameStart == 2)
        {
            Destroy(startText);
            ptsys.SetActive(true);
            bgmm.SetActive(true);
            GameStart = 3;


            levelManager.GameStart();
            paternManager.PlayPatern((int)levelManager.nowLevel);
        }

        if (Char_dead == true)
        {
            //SaveManager.Save();
            ptsys.GetComponent<pointsystem>().SendMessage("endscore");

            stop_button.SetActive(false);

        }

        if (Char_dead2 == true)
        {
            bgmm.SetActive(false);
            GameEnd.SetActive(true);
        }


    }
}

using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class pointsystem : MonoBehaviour
{
    public static int Point;
    public static int mooney;
    public Text text;

    private int bestscore;

    /// <summary>   프로토타입용 게임오버 화면 점수 표시 텍스트
    public Text tttext;
    public Text mtext;
    private bool onetime;
    /// </summary>

    private void Start()
    {
        onetime = false;
        Point = 0;
    }
    void Update()
    {
        text.text = "Score : " + (Point);


    }

    public void endscore()
    {
        if (onetime == false)
        {
            tttext.text = "SCORE " + (Point);

            highscore();
            getmoney();
            mtext.text = mooney.ToString();
            onetime = true;
        }
    }

    public void getmoney()
    {
        mooney = Mathf.RoundToInt(Point * 0.333f);
        SaveManager.moneysave(mooney);
       
    }
    public void highscore()
    {
        bestscore = SaveManager.scoreload(SaveManager.Load());
        if (Point > bestscore)
        {
            SaveManager.scoresave(Point);
        }
        //Social.ReportScore(SaveManager.Sscore, GPGSIds.leaderboard_beat_in_box, (bool bSuccess) =>
        //{
        //    //if (bSuccess)
        //    //    Debug.Log("랭킹등록성공");
        //    //else
        //    //    Debug.Log("랭킹등록실패");
        //}

    }
}

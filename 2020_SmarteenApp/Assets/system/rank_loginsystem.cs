using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class rank_loginsystem : MonoBehaviour
{

    public static int first = 0;
    
    void Awake()
    {
        //PlayGamesPlatform.InitializeInstance(new PlayGamesClientConfiguration.Builder().Build());
        //PlayGamesPlatform.DebugLogEnabled = true;
        //PlayGamesPlatform.Activate();

        ////print(first);
        //if (first == 0)
        //    OnLogin();
    }
    //void Start()
    //{
    //    print(first);
    //    if(first == 0)
    //        OnLogin();
    //}


    public void OnLogin()
    {
        //first = 1;
        //if (!Social.localUser.authenticated)
        //{
        //    Social.localUser.Authenticate((bool bSuccess) =>
        //    {
        //        if (!bSuccess)
        //        {
        //            first = 2;
        //        }
        //    });
        //}
    }
    public void OnShowLeaderBoard()
    {

        //if (first != 1)
        //    OnLogin();
        //// Sscore을 등록
        //if (first == 1)
        //{
        //    Social.ShowLeaderboardUI();
        //}
    }
}

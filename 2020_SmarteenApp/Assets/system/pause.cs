using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    public GameObject pausepanel;
    public GameObject Pusebutton;
    public GameObject settingpanel;
    public void mainPauseseting() //멈추기
    {

        Time.timeScale = 0;
        pausepanel.SetActive(true);
        Pusebutton.SetActive(false);
    }

    public void Pauseseting() //멈추기
    {
        
        Time.timeScale = 0;
        pausepanel.SetActive(true);
        Pusebutton.SetActive(false);
    }

    public void Restart() //하던게임 계속하기
    {
        Time.timeScale = 1;
        pausepanel.SetActive(false);
        Pusebutton.SetActive(true);
    }
    public void seting()//세팅창
    {
        pausepanel.SetActive(false);
        settingpanel.SetActive(true);
        //배경 사운드 진동 사운드 크기 받아와서 크기 만큼 지정해줘야함
    }
    public void reseting() //세팅창에서 일시정지창으로 넘어가는 함수
    {
        pausepanel.SetActive(true);
        settingpanel.SetActive(false);
        //세팅 저장
    }
    public void gohome() //메인홈으로
    {

        Time.timeScale = 1;
        SceneManager.LoadScene("main");
    }

    public void Regame()//처음부터
    {

        Time.timeScale = 1;
        SceneManager.LoadScene("InGame");
    }
}

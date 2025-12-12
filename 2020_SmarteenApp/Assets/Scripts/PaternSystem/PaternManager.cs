using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaternManager : MonoBehaviour
{
    public event Action PaternEndEvent;

    //public List<PaternScriptObject> paternList;
    public List<PaternScriptObjectbeta> paternListbeta;
    public List<GameObject> obstaclePrefabList;


   // private PaternScriptObject _currentPatern;
    private PaternScriptObjectbeta _currentPaternbeta;


    private int _allObstacleNum;
    private int _endedObstacleCount;

    private bool _isPaternPlaying = false;

    /* 패턴 다음 뽑기 전 대기 걸수 있게
     * 패턴끝남 이벤트
     */

    //private void Start()
    //{
    //    PlayPatern(0);
    //}

    public void PlayPatern(int level)
    {
        if (_isPaternPlaying)
        {
            Debug.LogError("패턴실행명령중복");
            return;
        }
        _isPaternPlaying = true;

        //_currentPatern = GetNewPatern();
        //_allObstacleNum = _currentPatern.obstacleList.Count;
        //_endedObstacleCount = 0;

        _currentPaternbeta = GetNewPaternbeta();
        _allObstacleNum = _currentPaternbeta.obstacleList.Count * 2;
        _endedObstacleCount = 0;

        //2차원 배열로 받음
        //foreach (var obs in _currentPatern.obstacleList)
        //{

        //    StartCoroutine(PlayObstacleCoroutine(obs));
        //}
        foreach (var obs in _currentPaternbeta.obstacleList)
        {

            StartCoroutine(PlayObstacleCoroutine(0,obs, false));
            StartCoroutine(Delay(obs));
        }

    }

    IEnumerator Delay(ObstacleBeta obs)
    {
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(PlayObstacleCoroutine(0, obs,true));
    }

    //private PaternScriptObject GetNewPatern()
    //{
    //    //패턴뽑기 구현
    //    /*
    //     * 1안 난이도별 확률제
    //     * 2안 N빵제
    //     * 3안 패턴별 확률
    //     */
    //    return paternList[0];
    //}
    private PaternScriptObjectbeta GetNewPaternbeta()
    {
        //패턴뽑기 구현
        /*
         * 1안 난이도별 확률제
         * 2안 N빵제
         * 3안 패턴별 확률
         */
        return paternListbeta[0];
    }

    IEnumerator PlayObstacleCoroutine(ObstacleInfo info)
    {
        yield return new WaitForSeconds(info.time);
        var obs = Instantiate(obstaclePrefabList[info.id]);
        obs.transform.position = info.position;
        obs.transform.localScale = info.size;

        var obsComp = obs.GetComponent<IObstacle>();
        obsComp.Initialize(info.direction, info.speed, ObstacleEnd);
        obsComp.Play();
    }
    IEnumerator PlayObstacleCoroutine(int num, ObstacleBeta info, bool isCollision)
    {

        yield return new WaitForSeconds(info.obstacles[num].time);
        var obs = Instantiate(obstaclePrefabList[info.obstacles[num].id]);
        obs.transform.position = info.obstacles[num].position;
        obs.transform.localScale = info.obstacles[num].size;

        var obsComp = obs.GetComponent<IObstacle>();
        obsComp.Initialize(info.obstacles[num].direction, info.obstacles[num].speed, () => { ObstacleEndbeta(num+1,info.obstacles, isCollision); });

        if (!isCollision)
        {
            //연하고 충돌 안하게
            obs.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 0.5f);
            obs.tag = "obj_intrail";
        }

        obsComp.Play();
    }
    void PlayObstacleCoroutines(int num, List<ObstacleInfo> info, bool isCollision)
    {

        var obs = Instantiate(obstaclePrefabList[info[num].id]);
        obs.transform.position = info[num].position;
        obs.transform.localScale = info[num].size;

        var obsComp = obs.GetComponent<IObstacle>();
        obsComp.Initialize(info[num].direction, info[num].speed, () => { ObstacleEndbeta(num + 1, info, isCollision); });

        if (!isCollision)
        {
            //연하고 충돌 안하게
            obs.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 0.5f);
            obs.tag = "obj_intrail";
        }

        obsComp.Play();
    }

    private void ObstacleEnd()
    {
        _endedObstacleCount++;
        if (_endedObstacleCount == _allObstacleNum)
        {
            _isPaternPlaying = false;
            PaternEndEvent?.Invoke();
            Debug.Log("패턴끝");
        }
    }
    private void ObstacleEndbeta(int number, List<ObstacleInfo> info, bool isCollision)
    {
        if (info.Count > number) 
        {
            PlayObstacleCoroutines(number, info, isCollision);
            return;
        }

        _endedObstacleCount++;
        if (_endedObstacleCount == _allObstacleNum)
        {
            _isPaternPlaying = false;
            PaternEndEvent?.Invoke();
            Debug.Log("패턴끝");
        }
    }
}

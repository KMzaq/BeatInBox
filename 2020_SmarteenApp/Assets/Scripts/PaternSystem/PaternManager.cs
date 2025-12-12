using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaternManager : MonoBehaviour
{
    public event Action PaternEndEvent;

    public List<PaternScriptObject> paternList;
    public List<GameObject> obstaclePrefabList;


    private PaternScriptObject _currentPatern;

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

        _currentPatern = GetNewPatern();
        _allObstacleNum = _currentPatern.obstacleList.Count;
        _endedObstacleCount = 0;
        foreach (var obs in _currentPatern.obstacleList)
        {
            StartCoroutine(PlayObstacleCoroutine(obs));
        }
    }

    private PaternScriptObject GetNewPatern()
    {
        //패턴뽑기 구현
        /*
         * 1안 난이도별 확률제
         * 2안 N빵제
         * 3안 패턴별 확률
         */
        return paternList[0];
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


    private void ObstacleEnd()
    {
        _endedObstacleCount++;
        if(_endedObstacleCount == _allObstacleNum)
        {
            _isPaternPlaying = false;
            PaternEndEvent?.Invoke();
            Debug.Log("패턴끝");
        }
    }
}

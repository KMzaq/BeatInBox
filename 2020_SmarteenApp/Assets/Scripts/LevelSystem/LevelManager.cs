using NUnit.Framework.Constraints;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SmallerObject
{
    public Transform transform;
    public Vector3 BaseTransform;
    public float SmallizerSize = 0.75f;

}
public class LevelManager : MonoBehaviour
{
    //private static readonly List<Vector3> LevelSize = new List<Vector3>() { new Vector3(210, 210, 0), new Vector3(157.5f, 157.5f, 0), new Vector3(118.125f, 118.125f, 0) };
    [SerializeField]
    private static float PlayerScaleUpTime = 1f;
    public int MaxLevel = 2;
    public List<SmallerObject> SamllerTransforms = new List<SmallerObject>();
    private List<Vector3> SmallerVectorTemp;


    public LevelEnum nowLevel
    {
        get; private set;
    }



    [SerializeField] private List<float> modeTime;


    private float timer;
    private bool isGamePlaying;

    public enum LevelEnum
    {
        Easy,
        Nomal,
        Hard
    }
    private void Start()
    {
        SmallerVectorTemp = new List<Vector3>(SamllerTransforms.Count);
        for (int i = 0; i < SamllerTransforms.Count; i++)
        {
            SmallerVectorTemp.Add(new Vector3(SamllerTransforms[i].transform.localScale.x, SamllerTransforms[i].transform.localScale.y, 0));
            SamllerTransforms[i].BaseTransform = new Vector3(SamllerTransforms[i].transform.localScale.x, SamllerTransforms[i].transform.localScale.y, 0);
        }

    }
    
    public void GameStart()
    {
        if (isGamePlaying) return;
        timer = 0;
        isGamePlaying = true;
        StartCoroutine(LevelManageCoroutine());
    }

    public void GameEnd()
    {
        isGamePlaying = false;
    }

    IEnumerator LevelManageCoroutine()
    {
        while (isGamePlaying)
        {
            timer += Time.deltaTime;
            yield return null;
        }
    }

    public void LevelUp()
    {
        nowLevel++;
        nowLevel = (LevelEnum)((int)nowLevel % 3);

    }

    public bool LevelUpCheck()
    {
        return timer >= modeTime[(int)nowLevel];
    }



    public void SizeUP( Action callback)
    {
        if (nowLevel == (int)LevelEnum.Easy)
        {
            StartCoroutine(PlaySizeDown(callback));
        }
        else
        {
            StartCoroutine(PlaySizeUp(callback));
        }

    }
    IEnumerator PlaySizeUp(Action callback)
    {
        float elapsedTime = 0;
        Vector3 LerpVector;

        for (int i = 0; i < SamllerTransforms.Count; ++i)
        {
            SmallerVectorTemp[i] = (new Vector3(SamllerTransforms[i].transform.localScale.x * SamllerTransforms[i].SmallizerSize,
                SamllerTransforms[i].transform.localScale.y * SamllerTransforms[i].SmallizerSize, 0));
        }

        while (elapsedTime < PlayerScaleUpTime)
        {
            float t = elapsedTime / PlayerScaleUpTime;
            elapsedTime += Time.deltaTime;

            for (int i = 0; i < SamllerTransforms.Count; ++i)
            {
                LerpVector = Vector3.Lerp(SamllerTransforms[i].transform.localScale, SmallerVectorTemp[i], t);
                SamllerTransforms[i].transform.localScale = LerpVector;
            }
            yield return null;
        }
        callback.Invoke();
    }
    IEnumerator PlaySizeDown(Action callback)
    {
        float elapsedTime = 0;
        Vector3 LerpVector;

        for (int i = 0; i < SamllerTransforms.Count; ++i)
        {
            SmallerVectorTemp[i] = (SamllerTransforms[i].BaseTransform);
        }

        while (elapsedTime < PlayerScaleUpTime)
        {
            float t = elapsedTime / PlayerScaleUpTime;
            elapsedTime += Time.deltaTime;

            for (int i = 0; i < SamllerTransforms.Count; ++i)
            {
                LerpVector = Vector3.Lerp(SamllerTransforms[i].transform.localScale, SmallerVectorTemp[i], t);
                SamllerTransforms[i].transform.localScale = LerpVector;
            }
            Debug.Log(SamllerTransforms[0].transform.localScale);
            yield return null;
        }
        callback.Invoke();
    }


}

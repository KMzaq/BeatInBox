using NUnit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(LineRenderer))]
public class Obstacle_Laser : BaseObstacle
{
    [SerializeField] private LineRenderer miniLineRenderer;
    private Vector3 _endPosition
    {
        get
        {
            return _vectorData;
        }
        set
        {
            _vectorData = value;
        }
    }

    private float _vezier
    {
        get
        {
            return _floatData;
        }
        set
        {
            _floatData = value;
        }
    }



    public override void Play()
    {
        base.Play();
        StartCoroutine(PlayCoroutine());
    }

    IEnumerator PlayCoroutine()
    {
        //선그리기
        var pointList = GetPointList(this.transform.position, _endPosition, _vezier);
        //범위 그리고 안에 찐하게 점점 커지기
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = pointList.Count;
        lineRenderer.SetPositions(pointList.ToArray());

        miniLineRenderer.positionCount = pointList.Count;
        miniLineRenderer.SetPositions(pointList.ToArray());


        while (miniLineRenderer.startWidth < lineRenderer.startWidth)
        {
            miniLineRenderer.startWidth += lineRenderer.startWidth *(Time.deltaTime);
            yield return null;
        }
        //충돌체크
        for(int i = 0; i < lineRenderer.positionCount - 1; i++)
        {
            Vector3 nextPos = lineRenderer.GetPosition(i + 1);


            var hit = Physics2D.CircleCast(lineRenderer.GetPosition(i),
                                 lineRenderer.startWidth,
                                 (nextPos - lineRenderer.GetPosition(i)).normalized,
                                 Vector3.Distance(lineRenderer.GetPosition(i), nextPos),
                                 1 << LayerMask.NameToLayer("Player"));

            if (hit.collider)
            {
                hit.collider.GetComponent<PlayerMove>().Die();
                Destroy(this);
                yield break;
            }
        }

        End();
        //
        //
        yield break;
    }

    private List<Vector3> GetPointList(Vector3 startPos, Vector3 endPos, float vezier)
    {
        List<Vector3> points = new List<Vector3>();


        // egmentCount 자동 계산
        int segmentCount = Mathf.Clamp(
            Mathf.CeilToInt(Mathf.Abs(vezier) * 3f),
            2,     // 최소
            60     // 최대
        );

        // 중간 제어점
        Vector3 midPoint = (startPos + endPos) * 0.5f;
        Vector3 dir = (midPoint - startPos).normalized;
        Vector3 verticalDir = new Vector3(-dir.y, dir.x, dir.z);
        midPoint = midPoint + verticalDir * vezier;
        

        for (int i = 0; i <= segmentCount; i++)
        {
            float t = i / (float)segmentCount;

            Vector3 point =
                Mathf.Pow(1 - t, 2) * startPos +
                2 * (1 - t) * t * midPoint +
                Mathf.Pow(t, 2) * endPos;

            points.Add(point);
        }


        return points;
    }

}

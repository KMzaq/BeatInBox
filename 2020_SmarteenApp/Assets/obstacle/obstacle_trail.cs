using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle_trail : MonoBehaviour
{
    GameObject pp;
    
    public void Traill()
    {
        pp = gameObject.transform.parent.gameObject;
        AnimationCurve curve = new AnimationCurve();

        if (pp.GetComponent<obj_1>().movexy.x != 0)
        {
            curve.AddKey(0f, (float)(pp.transform.localScale.y * 0.88));
           
        }
        if (pp.GetComponent<obj_1>().movexy.y != 0)
        {
            curve.AddKey(0f, (float)(pp.transform.localScale.x * 0.88));
        }
        gameObject.GetComponent<TrailRenderer>().widthCurve = curve; 
    }
}

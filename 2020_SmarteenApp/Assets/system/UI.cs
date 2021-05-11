using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    public CanvasScaler canvasScaler;

    // Start is called before the first frame update
    void Start()
    {
        canvasScaler = this.gameObject.GetComponent<CanvasScaler>();
        float scaleheight = ((float)Screen.width / Screen.height) / ((float)9 / 16);
       //print(canvasScaler.matchWidthOrHeight -scaleheight);
        if(canvasScaler.matchWidthOrHeight - scaleheight >0 )   canvasScaler.matchWidthOrHeight -= scaleheight+0.3F;
     
    }

}

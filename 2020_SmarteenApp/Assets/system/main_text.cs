using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class main_text : MonoBehaviour
{
    public Text moneytext;
    public Text scoretext;

    
    
    void Update()
    {
        moneytext.text = SaveManager.Smoney.ToString();
        scoretext.text = SaveManager.Sscore.ToString();
    }
}

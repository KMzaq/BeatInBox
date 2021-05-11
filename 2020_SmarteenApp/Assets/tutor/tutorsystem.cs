using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorsystem : MonoBehaviour
{
    public GameObject way_pos1;
    public GameObject way_pos2;

    public GameObject tutor_b;

    public GameObject tutor1;
    public GameObject tutor2;
    public GameObject tutor3;
    public GameObject tutor4;
    public GameObject tutor5;
    public GameObject tutor6;
    public GameObject tutor7;

    public GameObject tutor8;

    Vector3 waypos1;
    Vector3 waypos2;

    int tunum = 0;
    bool tuter = false;
    float time = 0;
    private void Start()
    {
        waypos1 = way_pos1.transform.position;
        waypos2 = way_pos2.transform.position;
        
    }

    void Update()
    {
        time += Time.deltaTime;
        if (SaveManager.Sscore == 0 && time >= 0.5f)
        {
            tuter = true;
        }
        if (tuter == true)
            switchupdate();
    }
    void switchupdate()
    {
        switch (tunum)
        {
            case 0:
                tutor1.transform.position = new Vector3(Mathf.Lerp(tutor1.transform.position.x, waypos1.x, 0.1f), waypos1.y, waypos1.z);
                tutor2.transform.position = new Vector3(Mathf.Lerp(tutor2.transform.position.x, waypos1.x, 0.1f), waypos1.y, waypos1.z);
                tutor3.transform.position = new Vector3(Mathf.Lerp(tutor3.transform.position.x, waypos1.x, 0.1f), waypos1.y, waypos1.z);
                tutor4.transform.position = new Vector3(Mathf.Lerp(tutor4.transform.position.x, waypos1.x, 0.1f), waypos1.y, waypos1.z);
                tutor5.transform.position = new Vector3(Mathf.Lerp(tutor5.transform.position.x, waypos1.x, 0.1f), waypos1.y, waypos1.z);
                tutor6.transform.position = new Vector3(Mathf.Lerp(tutor6.transform.position.x, waypos1.x, 0.1f), waypos1.y, waypos1.z);
                tutor7.transform.position = new Vector3(Mathf.Lerp(tutor7.transform.position.x, waypos1.x, 0.1f), waypos1.y, waypos1.z);
                tutor8.transform.position = new Vector3(Mathf.Lerp(tutor8.transform.position.x, waypos1.x, 0.1f), waypos1.y, waypos1.z);
                tutor_b.transform.position = new Vector3(Mathf.Lerp(tutor_b.transform.position.x, waypos1.x, 0.1f), waypos1.y, waypos1.z);

                break;
            case 1:
                tutor1.transform.position = new Vector3(Mathf.Lerp(tutor1.transform.position.x, waypos2.x, 0.1f), waypos1.y, waypos1.z);
                tutor2.transform.position = new Vector3(Mathf.Lerp(tutor2.transform.position.x, waypos1.x, 0.1f), waypos1.y, waypos1.z);
                tutor8.transform.position = new Vector3(Mathf.Lerp(tutor8.transform.position.x, waypos1.x, 0.1f), waypos1.y, waypos1.z);
                tutor3.transform.position = new Vector3(Mathf.Lerp(tutor3.transform.position.x, waypos1.x, 0.1f), waypos1.y, waypos1.z);
                tutor4.transform.position = new Vector3(Mathf.Lerp(tutor4.transform.position.x, waypos1.x, 0.1f), waypos1.y, waypos1.z);
                tutor5.transform.position = new Vector3(Mathf.Lerp(tutor5.transform.position.x, waypos1.x, 0.1f), waypos1.y, waypos1.z);
                tutor6.transform.position = new Vector3(Mathf.Lerp(tutor6.transform.position.x, waypos1.x, 0.1f), waypos1.y, waypos1.z);
                tutor7.transform.position = new Vector3(Mathf.Lerp(tutor7.transform.position.x, waypos1.x, 0.1f), waypos1.y, waypos1.z);
                break;
            case 2:
                tutor2.transform.position = new Vector3(Mathf.Lerp(tutor2.transform.position.x, waypos2.x, 0.1f), waypos1.y, waypos1.z);
                tutor8.transform.position = new Vector3(Mathf.Lerp(tutor8.transform.position.x, waypos1.x, 0.1f), waypos1.y, waypos1.z);
                tutor3.transform.position = new Vector3(Mathf.Lerp(tutor3.transform.position.x, waypos1.x, 0.1f), waypos1.y, waypos1.z);
                tutor4.transform.position = new Vector3(Mathf.Lerp(tutor4.transform.position.x, waypos1.x, 0.1f), waypos1.y, waypos1.z);
                tutor5.transform.position = new Vector3(Mathf.Lerp(tutor5.transform.position.x, waypos1.x, 0.1f), waypos1.y, waypos1.z);
                tutor6.transform.position = new Vector3(Mathf.Lerp(tutor6.transform.position.x, waypos1.x, 0.1f), waypos1.y, waypos1.z);
                tutor7.transform.position = new Vector3(Mathf.Lerp(tutor7.transform.position.x, waypos1.x, 0.1f), waypos1.y, waypos1.z);
                break;
            case 3:
                

tutor8.transform.position = new Vector3(Mathf.Lerp(tutor8.transform.position.x, waypos2.x, 0.1f), waypos1.y, waypos1.z);
                tutor3.transform.position = new Vector3(Mathf.Lerp(tutor3.transform.position.x, waypos1.x, 0.1f), waypos1.y, waypos1.z);
                tutor4.transform.position = new Vector3(Mathf.Lerp(tutor4.transform.position.x, waypos1.x, 0.1f), waypos1.y, waypos1.z);
                tutor5.transform.position = new Vector3(Mathf.Lerp(tutor5.transform.position.x, waypos1.x, 0.1f), waypos1.y, waypos1.z);
                tutor6.transform.position = new Vector3(Mathf.Lerp(tutor6.transform.position.x, waypos1.x, 0.1f), waypos1.y, waypos1.z);
                tutor7.transform.position = new Vector3(Mathf.Lerp(tutor7.transform.position.x, waypos1.x, 0.1f), waypos1.y, waypos1.z);
                break;
            case 4:
                tutor3.transform.position = new Vector3(Mathf.Lerp(tutor3.transform.position.x, waypos2.x, 0.1f), waypos1.y, waypos1.z);
                
                tutor4.transform.position = new Vector3(Mathf.Lerp(tutor4.transform.position.x, waypos1.x, 0.1f), waypos1.y, waypos1.z);
                tutor5.transform.position = new Vector3(Mathf.Lerp(tutor5.transform.position.x, waypos1.x, 0.1f), waypos1.y, waypos1.z);
                tutor6.transform.position = new Vector3(Mathf.Lerp(tutor6.transform.position.x, waypos1.x, 0.1f), waypos1.y, waypos1.z);
                tutor7.transform.position = new Vector3(Mathf.Lerp(tutor7.transform.position.x, waypos1.x, 0.1f), waypos1.y, waypos1.z);
                break;
            case 5:
                tutor4.transform.position = new Vector3(Mathf.Lerp(tutor4.transform.position.x, waypos2.x, 0.1f), waypos1.y, waypos1.z);
                tutor5.transform.position = new Vector3(Mathf.Lerp(tutor5.transform.position.x, waypos1.x, 0.1f), waypos1.y, waypos1.z);
                tutor6.transform.position = new Vector3(Mathf.Lerp(tutor6.transform.position.x, waypos1.x, 0.1f), waypos1.y, waypos1.z);
                tutor7.transform.position = new Vector3(Mathf.Lerp(tutor7.transform.position.x, waypos1.x, 0.1f), waypos1.y, waypos1.z);
                break;
            case 6:
               tutor5.transform.position = new Vector3(Mathf.Lerp(tutor5.transform.position.x, waypos2.x, 0.1f), waypos1.y, waypos1.z);
                tutor6.transform.position = new Vector3(Mathf.Lerp(tutor6.transform.position.x, waypos1.x, 0.1f), waypos1.y, waypos1.z);
                tutor7.transform.position = new Vector3(Mathf.Lerp(tutor7.transform.position.x, waypos1.x, 0.1f), waypos1.y, waypos1.z);

                break;
            case 7:
                 tutor6.transform.position = new Vector3(Mathf.Lerp(tutor6.transform.position.x, waypos2.x, 0.1f), waypos1.y, waypos1.z);
                tutor7.transform.position = new Vector3(Mathf.Lerp(tutor7.transform.position.x, waypos1.x, 0.1f), waypos1.y, waypos1.z);
                break;
            case 8:
tutor7.transform.position = new Vector3(Mathf.Lerp(tutor7.transform.position.x, waypos2.x, 0.1f), waypos1.y, waypos1.z);
                tutor_b.transform.position = new Vector3(Mathf.Lerp(tutor_b.transform.position.x, waypos2.x, 0.1f), waypos1.y, waypos1.z);
                break;
        }
    }

    public void retutor()
    {
        tunum = 0;
        tuter = true;
    }
    public void uptutor()
    {
        if(tunum < 8)
        tunum++;
    }
    public void downtutor()
    {
        if(tunum > 0)
        tunum--;
    }

    public void chit()
    {
        SaveManager.moneysave(9999);
    }
}

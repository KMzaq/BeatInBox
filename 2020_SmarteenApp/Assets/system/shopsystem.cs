using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopsystem : MonoBehaviour
{
    public GameObject mainpanle;
    public GameObject shop;

    public GameObject SH_ca;
    public GameObject SH_te;

    public Button gocama;
    public Button gotema;

    bool goshop;
    bool outshop;
    bool go_te;

    Vector3 waspos;
    Vector3 waspos2;
    Vector3 waspos3;


    private void Start()
    {
        waspos = mainpanle.transform.position;
        waspos2 = SH_ca.transform.position;
        waspos3 = SH_te.transform.position;


    }
    public void goingshop()
    {
        outshop = false;
        go_te = false;
        goshop = true;

        gocama.image.color = new Color(0.6f, 0.6f, 0.6f);
        gotema.image.color = new Color(1, 1, 1);
    }
    public void outingshop()
    {
        
        goshop = false;
        go_te = false;
        outshop = true;

    }

    public void gote()
    {

        //이동 버튼
     
        goshop = false;
        outshop = false;
        go_te = true;

        gocama.image.color = new Color(1, 1, 1);
        gotema.image.color = new Color(0.6f, 0.6f, 0.6f);
    }



    private void Update()
    {
        
        if(goshop == true)
        {
            mainpanle.transform.position = new Vector3(Mathf.Lerp(mainpanle.transform.position.x, waspos3.x, 0.1f), mainpanle.transform.position.y, mainpanle.transform.position.z);
            shop.transform.position = new Vector3(Mathf.Lerp(shop.transform.position.x, waspos.x, 0.1f), shop.transform.position.y, shop.transform.position.z);
            SH_ca.transform.position = new Vector3(Mathf.Lerp(SH_ca.transform.position.x, waspos.x, 0.1f), SH_ca.transform.position.y, SH_ca.transform.position.z);
            SH_te.transform.position = new Vector3(Mathf.Lerp(SH_te.transform.position.x, waspos3.x, 0.1f), SH_te.transform.position.y, SH_te.transform.position.z);


        }
        if (outshop == true)
        {
            mainpanle.transform.position = new Vector3(Mathf.Lerp(mainpanle.transform.position.x, waspos.x, 0.1f), mainpanle.transform.position.y, mainpanle.transform.position.z);
            shop.transform.position = new Vector3(Mathf.Lerp(shop.transform.position.x, waspos2.x, 0.1f), shop.transform.position.y, shop.transform.position.z);
            SH_ca.transform.position = new Vector3(Mathf.Lerp(SH_ca.transform.position.x, waspos2.x, 0.1f), SH_ca.transform.position.y, SH_ca.transform.position.z);
            SH_te.transform.position = new Vector3(Mathf.Lerp(SH_te.transform.position.x, waspos2.x, 0.1f), SH_te.transform.position.y, SH_te.transform.position.z);
        }
        if(go_te == true)
        {
            mainpanle.transform.position = new Vector3(Mathf.Lerp(mainpanle.transform.position.x, waspos3.x, 0.1f), mainpanle.transform.position.y, mainpanle.transform.position.z);
            shop.transform.position = new Vector3(Mathf.Lerp(shop.transform.position.x, waspos.x, 0.1f), shop.transform.position.y, shop.transform.position.z);
            SH_ca.transform.position = new Vector3(Mathf.Lerp(SH_ca.transform.position.x, waspos2.x, 0.1f), SH_ca.transform.position.y, SH_ca.transform.position.z);
            SH_te.transform.position = new Vector3(Mathf.Lerp(SH_te.transform.position.x, waspos.x, 0.1f), SH_te.transform.position.y, SH_te.transform.position.z);

        }

        if (SH_te.transform.position.x < waspos2.x + 1)
        {
            SH_te.transform.position = waspos3;
            outshop = false;
        }

    }
}

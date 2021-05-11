using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class store : MonoBehaviour
{
    //scv 파일 받아서 몇개인지 보고 바 길이 정하고
    //바는 버튼 누르면 그 숫자 받아서 맵 스킨도 그위치로 이동시키고
    //그에 맞는 위치 받아서 바꿔줘야함 버튼눌러도 바뀜
    // 그리고  선택 버튼 누르면 skin의 1번위치 =플레이어 2번위치는 배경
    //그 뒤로는 산것들임 백그라운드는 저장할때 10앞에 붙일것
    // if문 쓸때 10을 붙여서 검사하고 저장할때도 10붙여서 저장할것 
    // 구매할때는 sd에 있는지 확인하고 있으면 안사져야함
    // 돈도 확인해봐야함

    //드레그핸들 - 드래그 딱딱 멈추는걸로 한뒤 누르면 안보이게하고
    //   새로 x만움직이는걸로 움직이다 놓으면 사라지는걸 만들면
    //    자연스럽지않을까

    // 아니면 소숫점도 되게 해서 놓았을때 소숫점있으면 반내림 해서 이동하기

    // scv 최대숫자를 const로 선언해둘까? 그러자

    private  int MaxSkinNum = 5;  //맥시멈 스킨수 슬라이더바의 길이를 조정한다
    public Scrollbar shopslider;
    public Image skin;
    public SpriteRenderer backgrund;
    public SpriteRenderer Bbackgrund;
    public int skinnum;
    public Sprite[] playersprite;
    public Sprite[] mapsprite;
    bool shopss; //상점이 뭔상태인지 (맵,스킨
    List<int> soundlist = new List<int> { 1, 1, 1, 1, 1, 1};

    public GameObject nom;
    public Text CA_skin_text_name;
    public Text CA_skin_text_price;
    public Text BG_skin_text_name;
    public Text BG_skin_text_price;

    float movevar = 0.315f;
    public GameObject buy1;
    public GameObject buy2;

    public GameObject leftbut;
    public GameObject rightbut;
    public GameObject Bleftbut;
    public GameObject Brightbut;

    private void Start()
    {
     
        leftbut.SetActive(false);
        Bleftbut.SetActive(false);
        //print(SaveManager.moneyload(SaveManager.Load())+"내가 가진돈임");
        shopss = true;
        SaveManager.mapskinload(SaveManager.Load());
        for (int idx = 0; idx < SaveManager.smapskin.Count; idx++)
        {
            if (SaveManager.smapskin[idx] == 2)
            {
                Bbackgrund.sprite = mapsprite[idx];
                break;
            }
        }
        List<int> kskinlist = SaveManager.skinload(SaveManager.Load());
        for (int idx = 0; idx < kskinlist.Count; idx++)
        {
            if (kskinlist[idx] == 2)
            {
                buy1.SetActive(false);
                buy2.SetActive(false);
            }
            if (kskinlist[idx] == 1)
            {
                //버튼  ->장착
                buy1.SetActive(false);
                buy2.SetActive(true);
            }
            if (kskinlist[idx] == 1)
            {
                //버튼 -> 구매
                buy1.SetActive(true);
                buy2.SetActive(false);
            }
        }
        buybut();
        skinnum = 0;
        shopslider.value = 0.025f;
        skin.sprite = playersprite[skinnum];

        List<Dictionary<string, object>> data = CSVReader.Read("store");
        shopslider.size = (float)((1.0f / MaxSkinNum) - 0.05f); //나중에 더 적확한 수치 만드기

    }
    public void tournshop()
    {
        shopslider.value = 0.025f;
        skinnum = 0;
        skin.sprite = playersprite[skinnum];


        CA_skin_text_name.text = "Normal";
        CA_skin_text_price.text = "FREE";
        BG_skin_text_name.text = "Space";
        BG_skin_text_price.text = "FREE";
    }
    public void goplayerskinshop()
    {
        skinnum = 0;
        buybut();
        for (int idx = 0; idx < SaveManager.smapskin.Count; idx++)
        {
            if (SaveManager.smapskin[idx] == 2)
            {
                Bbackgrund.sprite = mapsprite[idx];
                break;
            }
        }
        shopss = true;
        leftbut.SetActive(false);
        Bleftbut.SetActive(false);
        rightbut.SetActive(true);
        Brightbut.SetActive(true);


    }
    public void gobackgreundskinshop()
    {
        
        
        shopss = false;
        nom.SetActive(false);
        leftbut.SetActive(false);
        Bleftbut.SetActive(false);
        rightbut.SetActive(true);
        Brightbut.SetActive(true);buybut();


    }

    public void upbutton()
    { 
        
        leftbut.SetActive(true);
        Bleftbut.SetActive(true);
        if (shopss == false)
        {
            //움직이는 범위 
            movevar = 0.2f;
            MaxSkinNum = 6;
        }
        else
        {
            movevar = 0.25f;
            MaxSkinNum = 5;
        }
        if (skinnum + 1 < MaxSkinNum)
        {
           

            skinnum++;
            shopslider.value += movevar;  //나중에 숫자구해서 넣기
            buybut();


                for (int idx = 0; idx < soundlist.Count; idx++)
            {
                //print(soundlist[skinnum]);
                //if()문써서 띄어주셈
                if (soundlist[skinnum] == 0)
                {
                    nom.SetActive(true);


                }
                if (soundlist[skinnum] == 1)
                {
                    nom.SetActive(false);

                }
            }

            //swich case 문 써서 text에 뭐라 띄울지 
            switch(skinnum)
            {
                case 0:
                    CA_skin_text_name.text = "Normal";
                    CA_skin_text_price.text = "FREE";
                    BG_skin_text_name.text = "Space";
                    BG_skin_text_price.text = "FREE";

                    break;
                case 1:
                    CA_skin_text_name.text = "Korean Melon";
                    CA_skin_text_price.text = "600";
                    BG_skin_text_name.text = "Aurora";
                    BG_skin_text_price.text = "600";
                    break;
                case 2:
                    CA_skin_text_name.text = "Pumpkin";
                    CA_skin_text_price.text = "600";
                    BG_skin_text_name.text = "Forest";
                    BG_skin_text_price.text = "600";

                    break;
                case 3:
                    CA_skin_text_name.text = "Water Melon";
                    CA_skin_text_price.text = "600";
                    BG_skin_text_name.text = "Desert";
                    BG_skin_text_price.text = "600";

                    break;
                case 4:
                    CA_skin_text_name.text = "Cat";
                    CA_skin_text_price.text = "600";
                    BG_skin_text_name.text = "Mountain";
                    BG_skin_text_price.text = "600";

                    break;
                case 5:
                    //CA_skin_text_name.text = "Korean Melon";
                    //CA_skin_text_price.text = "600";
                    BG_skin_text_name.text = "Ocean";
                    BG_skin_text_price.text = "600";

                    break;
            }
        }
        if(skinnum +1==MaxSkinNum)
        {
            rightbut.SetActive(false);
            Brightbut.SetActive(false);
        }

    }
    public void downbutton()
    {
        rightbut.SetActive(true);
        Brightbut.SetActive(true);
        if (shopss== false)
        {
            //움직이는 범위 
            movevar = 0.2f;
            MaxSkinNum = 6;
        }
        else
        {
            movevar = 0.25f;
            MaxSkinNum = 5;
        }
        if (skinnum > 0)
        {//버튼 사라짐 
           
            skinnum--;
            shopslider.value -= movevar;
            buybut();
            //soundlist 써서 text에 뭐라 띄울지  skinnum
            for (int idx = 0; idx < soundlist.Count; idx++)
            {
                //print(soundlist[skinnum]);
                //if()문써서 띄어주셈
                if (soundlist[skinnum] == 0)
                {
                    nom.SetActive(true);

                    
                }
                if (soundlist[skinnum] == 1)
                {
                    nom.SetActive(false);

                }
            }
            switch (skinnum)
            {
                case 0:
                    CA_skin_text_name.text = "Normal";
                    CA_skin_text_price.text = "FREE";
                    BG_skin_text_name.text = "Space";
                    BG_skin_text_price.text = "FREE";

                    break;
                case 1:
                    CA_skin_text_name.text = "Korean Melon";
                    CA_skin_text_price.text = "600";
                    BG_skin_text_name.text = "Aurora";
                    BG_skin_text_price.text = "600";
                    break;
                case 2:
                    CA_skin_text_name.text = "Pumpkin";
                    CA_skin_text_price.text = "600";
                    BG_skin_text_name.text = "Forest";
                    BG_skin_text_price.text = "600";

                    break;
                case 3:
                    CA_skin_text_name.text = "Water Melon";
                    CA_skin_text_price.text = "600";
                    BG_skin_text_name.text = "Desert";
                    BG_skin_text_price.text = "600";

                    break;
                case 4:
                    CA_skin_text_name.text = "Cat";
                    CA_skin_text_price.text = "600";
                    BG_skin_text_name.text = "Mountain";
                    BG_skin_text_price.text = "600";

                    break;
                case 5:
                    //CA_skin_text_name.text = "Korean Melon";
                    //CA_skin_text_price.text = "600";
                    BG_skin_text_name.text = "Ocean";
                    BG_skin_text_price.text = "600";

                    break;
            }
        }


        if (skinnum == 0)
        {
            Bleftbut.SetActive(false);
            leftbut.SetActive(false);
            
        }
    }
    public void gomain()
    {
        goplayerskinshop();
        skinnum = 0;
        shopslider.value = 0.025f;
        SaveManager.mapskinload(SaveManager.Load());
        for (int idx = 0; idx < SaveManager.smapskin.Count; idx++)
        {
            if (SaveManager.smapskin[idx] == 2)
            {
                Bbackgrund.sprite = mapsprite[idx];
                break;
            }
        }
    }

    public void sliderbutton()
    {
        //float value = (skinnum * 0.3f);

        if (shopslider.value < 0.025)
        {
            shopslider.value = 0.025f;
        }
        if (shopslider.value > 0.975)
        {
            shopslider.value = 0.975f;
        }

        // skinnum = (int)value * 10 / 3;
        print(skinnum);

    }


    public void buybut()
    {
        List<int> skinlist;
        if (shopss == true)
        {
            skin.sprite = playersprite[skinnum];
            skinlist = SaveManager.skinload(SaveManager.Load());


        }
        else
        {
            backgrund.sprite = mapsprite[skinnum];
             skinlist = SaveManager.mapskinload(SaveManager.Load());

        }

        if (skinlist[skinnum] == 2)
        {
            buy1.SetActive(false);
            buy2.SetActive(false);
        }
        if (skinlist[skinnum] == 1)
        {
            //버튼  ->장착
            buy1.SetActive(false);

            buy2.SetActive(true);
        }
        if (skinlist[skinnum] == 0)
        {
            //버튼 -> 구매
            buy1.SetActive(true);
            buy2.SetActive(false);
        }


    }

    public void buy()
    {

        print(shopss);
        //상점이 뭔지 봐야함

        if (shopss == true)
        {
            List<int> skinlist = SaveManager.skinload(SaveManager.Load());

            int mny = SaveManager.moneyload(SaveManager.Load());


            if (skinlist[skinnum] == 1)
            {
                for (int idx = 0; idx < skinlist.Count; idx++)
                {
                    if (skinlist[idx] == 2)
                    {
                        SaveManager.skinysave(idx, 1);
                        SaveManager.skinysave(skinnum, 2);
                    }
                }


                print("스킨장착");
            }
            else if (skinlist[skinnum] == 2) { print("장착중"); }
            else if (600 <= mny)
            {


                print("구매선공");
                mny = -600;
                SaveManager.moneysave(mny);
                SaveManager.skinysave(skinnum, 1);

            }
            else if (600 > SaveManager.moneyload(SaveManager.Load()))
            {
                print("구매실패");

            }
        }
        
        
        if(shopss==false) //맵상점
        {
            List<int> skinlist = SaveManager.mapskinload(SaveManager.Load());

            int mny = SaveManager.moneyload(SaveManager.Load());


            if (skinlist[skinnum] == 1)
            {
                for (int idx = 0; idx < skinlist.Count; idx++)
                {  
                   
                    if (skinlist[idx] == 2)
                    {
                       SaveManager.mapskinsave(idx, 1);
                        SaveManager.mapskinsave(skinnum, 2);
                        Bbackgrund.sprite = mapsprite[skinnum];
                    }
                }



                print("스킨장착" + Bbackgrund.sprite);
            }
            else if (skinlist[skinnum] == 2)
            {
                print("장착중");
            }
            else if (600 <= mny)
            {


                print("구매선공");
                mny = -600;
                SaveManager.moneysave(mny);
                SaveManager.mapskinsave(skinnum, 1);

            }
            else if (600 > SaveManager.moneyload(SaveManager.Load()))
            {
                print("구매실패");

            }


           

        } 
        buybut();
        SaveManager.Save();



    }
}

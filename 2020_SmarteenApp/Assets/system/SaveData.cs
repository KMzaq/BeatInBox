using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    //여러가지 타입이 가능하지만, Dictionary는 안된다.
    [SerializeField] private float EFTsound;
    [SerializeField] private float zzzzzz;
    [SerializeField] private float BGMsound;
    [SerializeField] private int score;
    [SerializeField] private float money;
    [SerializeField]  List<int> useskin;
    [SerializeField]  List<int> Mapskin;
    //외부 Json 라이브러리가 아닌 JsonUtility를 쓰면 Vector3도 저장할 수 있다.
    // [SerializeField] private Vector3 lastPosition;

    float BackData;
       List<int> BuseskinList;
    //생성자
    public SaveData(float t_effet,float t_BGM,int t_score, int t_money,float zzz,List<int> t_skin,List<int> t_mapskin)
    {
        zzzzzz = zzz;
        BGMsound = t_BGM;
        EFTsound =t_effet;
        score = t_score;
        money = t_money ;

        //일일이 값을 복사하는게 깔끔하다.
        useskin = new List<int>();
        foreach (var num in t_skin)
        {
            useskin.Add(num);
        }
        Mapskin = new List<int>();
        foreach (var num in t_mapskin)
        {
            Mapskin.Add(num);
        }


        // lastPosition = new Vector3(t_lastPosition.x, t_lastPosition.y, t_lastPosition.z);
    }
        public float Load( string backname)
        {
        switch (backname)
        {
            case "EFTsound":
                BackData = EFTsound;
                break;
            case "BGMsound":
                BackData = BGMsound;
                break;
            case "score":
                BackData = score;
                break;
            case "money":
                BackData = money;
                break;
            case "zzz":
                BackData = zzzzzz;
                break;
              
        }

        return BackData;
        }


    public  List<int> skinLoad()
    {

        BuseskinList = useskin;
        return BuseskinList;
    }
    public List<int> mapskinLoad()
    {

        BuseskinList = Mapskin;
        return BuseskinList;
    }

}

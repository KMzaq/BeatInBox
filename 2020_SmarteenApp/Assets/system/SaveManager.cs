using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Security.Cryptography;
using UnityEngine.UI;
using System.Dynamic;

public class SaveManager : MonoBehaviour
{
    public Slider BGsound;
    public Slider EFTsound;
    public Slider zzzzz;
    public static int Sscore;
    public static int Smoney;
    public static float SBGsound;
    public static float SEFTsound;
    public static float szzzzz;
    public static List<int> Sskinlist;
    public static List<int> smapskin;
    private void Start()
    {
        SaveData sd;
        sd = Load();
        soundload(sd);
       
        BGsound.value =SBGsound  ;
        EFTsound.value =SEFTsound ;
        zzzzz.value = szzzzz;
        moneyload(sd);
        scoreload(sd);
        Sskinlist = skinload(Load());
        smapskin = mapskinload(Load());
    }



    public void soundload(SaveData sd)
    {
        SBGsound = sd.Load("BGMsound");
        SEFTsound = sd.Load("EFTsound");
        szzzzz = sd.Load("zzz");

    }
    public  void soundsave()
    {
        SEFTsound= EFTsound.value ;
        SBGsound = BGsound.value;
        szzzzz = zzzzz.value;
        Save();
    }

    public static int scoreload(SaveData sd)
    {
        Sscore = (int)sd.Load("score"); 
        return Sscore;
    }


    public static void scoresave(int score)
    {
       
        Sscore = score;
        Save();
    }

    public static int  moneyload(SaveData sd)
    {
        Smoney = (int)sd.Load("money");
        return Smoney;
    }
    public static void moneysave(int money)
    {
        Smoney = moneyload(Load()) + money;
        Save();

    }
    public static void skinysave(int num,int sa)
    {
        if (Sskinlist[num].Equals(null))
        {
            Sskinlist.Insert(num,sa);
        }else
            Sskinlist[num] = sa;
        
  
       
        Save();
    }    public static void mapskinsave(int num,int sa)
    {
        if (smapskin[num].Equals(null))
        {
            smapskin.Insert(num,sa);
        }else
            smapskin[num] = sa;

     

        Save();
    }

    public static List<int> skinload(SaveData sd)
    {

        Sskinlist = sd.skinLoad();
        return Sskinlist;
    }
    public static List<int> mapskinload(SaveData sd)
    {
       
        smapskin = sd.mapskinLoad();
        return smapskin ;
    }

    private static readonly string privateKey = "f0jsdlfjds4odry3ckza1718hy9dsz9x9ba9ue1";

    public static void Save()
    {
        
        int score = Sscore;
        int money = Smoney;
        float BGsound = SBGsound ;
        float EFTsound = SEFTsound;
        float zzzzz = szzzzz;
        List<int> mapskin = smapskin;
        List<int> skinlist = Sskinlist;

        //원래라면 플레이어 정보나 인벤토리 등에서 긁어모아야 할 정보들.
        SaveData sd = new SaveData(
            EFTsound,
            BGsound,
            score, //점수
            money, //돈
            zzzzz,
             skinlist,
             mapskin

           ); //가지고 있는 아이템 번호 맨앞두개는 장착
        print(sd);
        string jsonString = DataToJson(sd);
        string encryptString = Encrypt(jsonString);
        SaveFile(encryptString);
    }

    public static SaveData Load()
    {
       
        //파일이 존재하는지부터 체크.
        if (!File.Exists(GetPath()))
        {
            Debug.Log("세이브 파일이 존재하지 않음.");
            //기본데이타
             Sscore=0;
            Smoney =0;
            SBGsound =1;
            SEFTsound =1;
            szzzzz = 1;
            Sskinlist =new List<int> {2,0,0,0,0,0,0};
            smapskin =new List<int> {2,0,0,0,0,0,0};
            Save();
            return null;
        }

        string encryptData = LoadFile(GetPath());
        string decryptData = Decrypt(encryptData);

        //Debug.Log(decryptData);


    SaveData sd = JsonToData(decryptData);

         
        return sd;
    }

    ////////////////////////////////////////////////////////////////////////////////////////

    //세이브 데이터를 json string으로 변환
    static string DataToJson(SaveData sd)
    {
        string jsonData = JsonUtility.ToJson(sd);
        return jsonData;
    }

    //json string을 SaveData로 변환
    static SaveData JsonToData(string jsonData)
    {
        SaveData sd = JsonUtility.FromJson<SaveData>(jsonData);
        return sd;
    }

    ////////////////////////////////////////////////////////////////////////////////////////

    //json string을 파일로 저장
    static void SaveFile(string jsonData)
    {
        using (FileStream fs = new FileStream(GetPath(), FileMode.Create, FileAccess.Write))
        {
            //파일로 저장할 수 있게 바이트화
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(jsonData);

            //bytes의 내용물을 0 ~ max 길이까지 fs에 복사
            fs.Write(bytes, 0, bytes.Length);
        }
    }

    //파일 불러오기
    static string LoadFile(string path)
    {
        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            //파일을 바이트화 했을 때 담을 변수를 제작
            byte[] bytes = new byte[(int)fs.Length];

            //파일스트림으로 부터 바이트 추출
            fs.Read(bytes, 0, (int)fs.Length);

            //추출한 바이트를 json string으로 인코딩
            string jsonString = System.Text.Encoding.UTF8.GetString(bytes);
            return jsonString;
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////

    private static string Encrypt(string data)
    {

        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(data);
        RijndaelManaged rm = CreateRijndaelManaged();
        ICryptoTransform ct = rm.CreateEncryptor();
        byte[] results = ct.TransformFinalBlock(bytes, 0, bytes.Length);
        return System.Convert.ToBase64String(results, 0, results.Length);

    }

    private static string Decrypt(string data)
    {

        byte[] bytes = System.Convert.FromBase64String(data);
        RijndaelManaged rm = CreateRijndaelManaged();
        ICryptoTransform ct = rm.CreateDecryptor();
        byte[] resultArray = ct.TransformFinalBlock(bytes, 0, bytes.Length);
        return System.Text.Encoding.UTF8.GetString(resultArray);
    }


    private static RijndaelManaged CreateRijndaelManaged()
    {
        byte[] keyArray = System.Text.Encoding.UTF8.GetBytes(privateKey);
        RijndaelManaged result = new RijndaelManaged();

        byte[] newKeysArray = new byte[16];
        System.Array.Copy(keyArray, 0, newKeysArray, 0, 16);

        result.Key = newKeysArray;
        result.Mode = CipherMode.ECB;
        result.Padding = PaddingMode.PKCS7;
        return result;
    }

    ////////////////////////////////////////////////////////////////////////////////////////

    //저장할 주소를 반환
    static string GetPath()
    {  
        //print(Path.Combine(Application.persistentDataPath, "save"));
        return Path.Combine(Application.persistentDataPath, "\'saacwee");
      
    }




}
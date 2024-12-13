using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using Unity.VisualScripting;
using System.IO;

public class DayTime : MonoBehaviour
{

    int dtIntAW; int dtIntNow;
    DateTime dt; DateTime dt2;
    public TextMeshProUGUI DayText;

    [Serializable]
    public class jsonDayTime
    {
        public string dt_now;
        public string dt_afterweek;

    }



    // Start is called before the first frame update
    void Start()
    {

        jsonInitialize();

#if UNITY_EDITOR
        if (File.Exists(Application.persistentDataPath + "Dtdata.json"))
        {

#elif UNITY_ANDROID              
        if (File.Exists(Path.Combine(Application.persistentDataPath, "Directory_path/Dtdata.json")))
        {

#endif
            jsonDayTime jsonDayTime = new jsonDayTime();
            StreamReader reader;

#if UNITY_EDITOR
            reader = new StreamReader(Application.persistentDataPath + "Dtdata.json");

#elif UNITY_ANDROID
            reader = new StreamReader(Path.Combine(Application.persistentDataPath, "Directory_path/Dtdata.json"), Encoding.GetEncoding("utf-8"));
#endif
            string dtData = reader.ReadToEnd();

            reader.Close();

            dt = DateTime.Now;

            jsonDayTime = JsonUtility.FromJson<jsonDayTime>(dtData);

            dtIntNow = int.Parse(jsonDayTime.dt_now);

            string jsonDt = jsonDayTime.dt_now;

            if (dtIntNow < int.Parse(dt.ToString("yyyyMMdd")))
            {

                dtIntNow = int.Parse(dt.ToString("yyyyMMdd"));
                jsonDayTime.dt_now = dt.ToString("yyyyMMdd");
                jsonDt = JsonUtility.ToJson(jsonDayTime);

#if UNITY_ANDROID

                if (Directory.Exists(Path.Combine(Application.persistentDataPath, "Directory_path")))
                {

                }
                else
                {
                    Directory.CreateDirectory(Path.Combine(Application.persistentDataPath, "Directory_path"));
                }

#endif

                StreamWriter writer;

#if UNITY_EDITOR
                writer = new StreamWriter(Application.persistentDataPath + "Dtdata.json", false);//LPost/Assets/savedata //trueÇ≈í«â¡èëÇ´çûÇ›
#elif UNITY_ANDROID
writer = new StreamWriter(Path.Combine(Application.persistentDataPath ,"Directory_path/Dtdata.json") , true, Encoding.GetEncoding("utf-8"));
 Debug.Log(Path.Combine(Application.persistentDataPath, "Directory_path/savedata.json"));
#endif
                writer.Write(jsonDt);
                writer.Flush();
                writer.Close();

            }

            DayText.text = jsonDayTime.dt_now;

            jsonDebug();

        }


        if (int.Parse(dt.ToString("yyyyMMdd")) >= int.Parse(PlayerPrefs.GetString("dtAfterWeek")))
        {

            dt2 = dt + TimeSpan.FromDays(7);
            PlayerPrefs.SetString("dtAfterWeek", dt2.ToString("yyyyMMdd"));

            //Ç¢Ç¬Ç©Ç±Ç±Ç…àÍèTä‘Ç…Ç∆Ç¡ÇΩÇ‚Ç¬ÇÃèàóùÇèëÇ≠


        }

        dtIntAW = int.Parse(PlayerPrefs.GetString("dtAfterWeek"));

        Debug.Log(dtIntAW + " : " + dtIntNow);



    }

    // Update is called once per frame
    void Update()
    {

    }

    void jsonInitialize()
    {


#if UNITY_ANDROID

        if (Directory.Exists(Path.Combine(Application.persistentDataPath, "Directory_path")))
        {
            Debug.Log(Application.persistentDataPath);
        }
        else
        {
            Debug.Log("bbb");
            Directory.CreateDirectory(Path.Combine(Application.persistentDataPath, "Directory_path"));
        }

#endif

        StreamWriter writer;
        jsonDayTime jsonDiary = new jsonDayTime();
        jsonDiary.dt_now = "0";
        jsonDiary.dt_afterweek = "0";

        string jsonstr = JsonUtility.ToJson(jsonDiary);

#if UNITY_EDITOR
        writer = new StreamWriter(Application.persistentDataPath + "Dtdata.json", false);//LPost/Assets/savedata //trueÇ≈í«â¡èëÇ´çûÇ›
#elif UNITY_ANDROID
writer = new StreamWriter(Path.Combine(Application.persistentDataPath ,"Directory_path/Dtdata.json") , true, Encoding.GetEncoding("utf-8"));
 Debug.Log(Path.Combine(Application.persistentDataPath, "Directory_path/savedata.json"));
#endif
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();

    }

    void jsonDebug()
    {
#if UNITY_EDITOR
        if (File.Exists(Application.persistentDataPath + "Dtdata.json"))
        {

#elif UNITY_ANDROID              
        if (File.Exists(Path.Combine(Application.persistentDataPath, "Directory_path/Dtdata.json")))
        {

#endif
            jsonDayTime jsonDayTime = new jsonDayTime();
            StreamReader reader;

#if UNITY_EDITOR
            reader = new StreamReader(Application.persistentDataPath + "Dtdata.json");

#elif UNITY_ANDROID
            reader = new StreamReader(Path.Combine(Application.persistentDataPath, "Directory_path/Dtdata.json"), Encoding.GetEncoding("utf-8"));
#endif
            string dtData = reader.ReadToEnd();

            reader.Close();

            Debug.Log(dtData);

        }

    }
}


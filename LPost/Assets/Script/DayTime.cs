using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using Unity.VisualScripting;
using System.IO;
using System.Text;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class DayTime : MonoBehaviour
{

    int dtIntAW; int dtIntNow;
    DateTime dt; DateTime dt2;
    public TextMeshProUGUI DayText;
    [SerializeField] private UnityEvent SceneChangeIvent;
    GameObject GameManager;
    SaveVariable saveVariable;
    


    [Serializable]
    public class jsonDayTime
    {
        public string dt_now;
        public string dt_afterweek;

    }



    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        saveVariable = GameManager.GetComponent<SaveVariable>();
         

        jsonInitialize();
        jsonDayTime jsonDayTime = new jsonDayTime();
        jsonDebug();

#if UNITY_EDITOR
        if (File.Exists(Application.persistentDataPath + "Dtdata.json"))
        {

#elif UNITY_ANDROID              
        if (File.Exists(Path.Combine(Application.persistentDataPath, "Directory_path/Dtdata.json")))
        {

#endif
            
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
                writer = new StreamWriter(Application.persistentDataPath + "Dtdata.json", false);//LPost/Assets/savedata //true‚Å’Ç‰Á‘‚«ž‚Ý
#elif UNITY_ANDROID
writer = new StreamWriter(Path.Combine(Application.persistentDataPath ,"Directory_path/Dtdata.json") , false, Encoding.GetEncoding("utf-8"));
#endif
                writer.Write(jsonDt);
                writer.Flush();
                writer.Close();

            }

            DayText.text = jsonDayTime.dt_now;

        }
       

        if (int.Parse(dt.ToString("yyyyMMdd")) >= int.Parse(jsonDayTime.dt_afterweek)|| saveVariable.NumberWeekJudge == 7)
        {
            
            dt2 = dt + TimeSpan.FromDays(7);
            jsonDayTime.dt_afterweek = dt2.ToString("yyyyMMdd");
            string jsonDtAW = JsonUtility.ToJson(jsonDayTime);

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
            writer = new StreamWriter(Application.persistentDataPath + "Dtdata.json", false);//LPost/Assets/savedata //true‚Å’Ç‰Á‘‚«ž‚Ý
#elif UNITY_ANDROID
writer = new StreamWriter(Path.Combine(Application.persistentDataPath ,"Directory_path/Dtdata.json") , false, Encoding.GetEncoding("utf-8"));
#endif
            writer.Write(jsonDtAW);
            writer.Flush();
            writer.Close();

            //‚¢‚Â‚©‚±‚±‚ÉˆêTŠÔ‚É‚Æ‚Á‚½‚â‚Â‚Ìˆ—‚ð‘‚­
            saveVariable.NumberWeekJudge = 0;
            WeekJudge();
            

        }

        Debug.Log(jsonDayTime.dt_afterweek + " : " + jsonDayTime.dt_now);
        Debug.Log(this.gameObject);

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
            return;
        }
        else
        {
            Debug.Log("Create Directory");
            Directory.CreateDirectory(Path.Combine(Application.persistentDataPath, "Directory_path"));
        }

#endif

        StreamWriter writer;
        jsonDayTime jsonDiary = new jsonDayTime();
        jsonDiary.dt_now = "0";
        jsonDiary.dt_afterweek = "0";

        string jsonstr = JsonUtility.ToJson(jsonDiary);

#if UNITY_EDITOR
        writer = new StreamWriter(Application.persistentDataPath + "Dtdata.json", false);//LPost/Assets/savedata //true‚Å’Ç‰Á‘‚«ž‚Ý
#elif UNITY_ANDROID
writer = new StreamWriter(Path.Combine(Application.persistentDataPath ,"Directory_path/Dtdata.json") , false, Encoding.GetEncoding("utf-8"));
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

    public void WeekJudge()
    {
        if (LPPoint.LPower_week >= 105)
        {
            SceneChangeIvent.Invoke();
            LPPoint.LPower_week = 0;
        }
    }
}


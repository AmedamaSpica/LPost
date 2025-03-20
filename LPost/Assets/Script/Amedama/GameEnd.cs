
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameEnd : MonoBehaviour
{

    [Serializable]
    public class LPointjson
    {
        public int LP;
        public int LP_week;

    }

    // Start is called before the first frame update
    void Start()
    {
        jsonInitialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void OnApplicationQuit()
     {

        LPointjson lPointjson = new LPointjson(); 
        
        lPointjson.LP = LPPoint.LPower;
        lPointjson.LP_week = LPPoint.LPower_week;
        string jsonLP = JsonUtility.ToJson(lPointjson);

        StreamWriter writer = writerOpen();

        writer.Write(jsonLP);
        writer.Flush();
        writer.Close();

        jsonDebug();
        Application.Quit();
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
        LPointjson lPointjson = new LPointjson();
        lPointjson.LP = 0;
        lPointjson.LP_week = 0;

        string jsonstr = JsonUtility.ToJson(lPointjson);

#if UNITY_EDITOR
        writer = new StreamWriter(Application.persistentDataPath + "LPdata.json", false);//LPost/Assets/savedata //trueで追加書き込み
#elif UNITY_ANDROID
writer = new StreamWriter(Path.Combine(Application.persistentDataPath ,"Directory_path/LPdata.json") , false, System.Text.Encoding.GetEncoding("utf-8"));
#endif
       

        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();

    }

    void jsonDebug()
    {
#if UNITY_EDITOR
        if (File.Exists(Application.persistentDataPath + "LPdata.json"))
        {

#elif UNITY_ANDROID              
        if (File.Exists(Path.Combine(Application.persistentDataPath, "Directory_path/LPdata.json")))
        {

#endif
            LPointjson jsonDayTime = new LPointjson();
            StreamReader reader;

#if UNITY_EDITOR
            reader = new StreamReader(Application.persistentDataPath + "LPdata.json");

#elif UNITY_ANDROID
            reader = new StreamReader(Path.Combine(Application.persistentDataPath, "Directory_path/LPdata.json"), System.Text.Encoding.GetEncoding("utf-8"));
#endif
            string Data = reader.ReadToEnd();

            reader.Close();

            Debug.Log(Data);

        }

    }

    StreamWriter writerOpen()//開きたいものに合わせえてファイルパスをいじくってね
    {

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
        writer = new StreamWriter(Application.persistentDataPath + "LPdata.json", false);//LPost/Assets/savedata //trueで追加書き込み
#elif UNITY_ANDROID
        writer = new StreamWriter(Path.Combine(Application.persistentDataPath ,"Directory_path/LPdata.json") , false, System.Text.Encoding.GetEncoding("utf-8"));
#endif

        return writer;

    }
}

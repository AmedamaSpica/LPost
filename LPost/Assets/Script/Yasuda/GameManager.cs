using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    
    GameEnd GameEnd = new GameEnd();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {

        
        if (instance == null)
        {
            instance = this;
            GameEnd.LPointjson lPointjson = new GameEnd.LPointjson();

#if UNITY_EDITOR
            if (File.Exists(Application.persistentDataPath + "LPdata.json"))
            {

#elif UNITY_ANDROID
            if (File.Exists(Path.Combine(Application.persistentDataPath, "Directory_path/LPdata.json")))
            {

#endif

                StreamReader reader;

#if UNITY_EDITOR
                reader = new StreamReader(Application.persistentDataPath + "LPdata.json");

#elif UNITY_ANDROID
                reader = new StreamReader(Path.Combine(Application.persistentDataPath, "Directory_path/LPdata.json"), Encoding.GetEncoding("utf-8"));
#endif

                string LPData = reader.ReadToEnd();

                reader.Close();

                lPointjson = JsonUtility.FromJson<GameEnd.LPointjson>(LPData);


                LPPoint.LPower = lPointjson.LP;
                LPPoint.LPower_week = lPointjson.LP_week;


            }
     
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

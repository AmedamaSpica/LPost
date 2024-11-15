using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;


[Serializable]
public class Diary
{
    public string dt_string;
    public string diary_text;

}


public class DiarySave : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    
    public void wei()
    {
        Diary diary = new Diary();
        StreamWriter writer;

        diary.dt_string = DateTime.Now.ToString("yyyy/MM/dd");
        diary.diary_text = text.text;

        string jsonstr = JsonUtility.ToJson(diary) + "\n";

        Debug.Log(jsonstr);

        writer = new StreamWriter(Application.dataPath + "/savedata.json", true);//LPost/Assets/savedata //trueÇ≈í«â¡èëÇ´çûÇ›
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();
    }

    
}

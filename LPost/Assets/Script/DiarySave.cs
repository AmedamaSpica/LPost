using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System.Text;


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
        text.text = String.Empty;
    }

    // Update is called once per frame
    void Update()
    {

    }

    
    public void wei()
    {
        Diary diary = new Diary();
        StreamWriter writer;

        if ((int)text.text[0] != 8203)
        {

            diary.dt_string = DateTime.Now.ToString("yyyy/MM/dd");
            diary.diary_text = text.text;

            string jsonstr = JsonUtility.ToJson(diary) + "\n";

            Debug.Log(jsonstr);


#if UNITY_ANDROID

            if (Directory.Exists(Path.Combine(Application.persistentDataPath, "Directory_path")))
            {
               
            }
            else
            {
                Directory.CreateDirectory(Path.Combine(Application.persistentDataPath, "Directory_path"));
            }

#endif

            

#if UNITY_EDITOR
            writer = new StreamWriter(Application.persistentDataPath +"savedata.json", true);//LPost/Assets/savedata //trueÇ≈í«â¡èëÇ´çûÇ›
#elif UNITY_ANDROID
writer = new StreamWriter(Path.Combine(Application.persistentDataPath ,"Directory_path/savedata.json") , true, Encoding.GetEncoding("utf-8"));
 Debug.Log(Path.Combine(Application.persistentDataPath, "Directory_path/savedata.json"));
#endif
            writer.Write(jsonstr);
            writer.Flush();
            writer.Close();

        }
    }

    
}

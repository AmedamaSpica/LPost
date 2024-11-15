using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class outputDiary : MonoBehaviour
{

    [SerializeField]private TextMeshProUGUI text;

    private string[] splitText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void wewei()
    {

        Diary diary = new Diary();

        if (File.Exists(Application.dataPath + "/savedata.json"))
        {
            StreamReader reader;
            reader = new StreamReader(Application.dataPath + "/savedata.json");
            string data = reader.ReadToEnd();

            

            reader.Close();

            splitText = data.Split(char.Parse("\n"));

            foreach (string line in splitText)
            {
                if (line.Length > 0)
                {
                    diary = JsonUtility.FromJson<Diary>(line);
                    Debug.Log(diary.diary_text);
                }
            }
        }

        text.text = diary.diary_text;
    }
}

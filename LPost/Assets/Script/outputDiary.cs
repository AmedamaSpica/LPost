using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class outputDiary : MonoBehaviour
{

    [SerializeField]private TextMeshProUGUI text;

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

            Debug.Log(data);

            reader.Close();
            diary = JsonUtility.FromJson<Diary>(data);

        }

        text.text = diary.diary_text;
    }
}

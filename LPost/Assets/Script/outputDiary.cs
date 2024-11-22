using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class outputDiary : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private ScrollView scrollView;

    private string[] splitText;
    List<string> splitList = new List<string>();
    private int[] CountDiaryDays = new int[2];

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
            string diaryDay = "0";
            string data = reader.ReadToEnd();
            int i = -1;

            reader.Close();

            splitText = data.Split(char.Parse("\n"));

            foreach (string line in splitText)
            {

                
                if (line.Length > 0)
                {

                    diary = JsonUtility.FromJson<Diary>(line);
                    
                    if (diaryDay != diary.dt_string)
                    {
                        
                        diaryDay = diary.dt_string;                        
                        Debug.Log(diaryDay);
                        splitList.Add(diaryDay);

                        i++;
                        
                    }
                    
                    CountDiaryDays[i] += 1;
                    Debug.Log(CountDiaryDays[i]);
                }
            }
        }

        text.text = diary.diary_text;

        dropdown.ClearOptions();
        dropdown.AddOptions(splitList);
    
    }

    public void ChangeScrollViewFromDropdown()
    {

        switch (dropdown.value)
        {

            case 0:

                Debug.Log(CountDiaryDays[0]);

                break;

            case 1:
                Debug.Log(CountDiaryDays[1]);
                break;

        }
    }

    
    
}

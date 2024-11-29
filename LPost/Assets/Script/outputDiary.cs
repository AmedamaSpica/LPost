using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Unity.VisualScripting;
using System.Text;

public class outputDiary : MonoBehaviour
{

    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private ScrollView scrollView;
    [SerializeField] private DayDropdown dayDropdown = new DayDropdown();

    private string[] splitText;
    List<string> splitList = new List<string>();
    [HideInInspector] public int[] CountDiaryDays;
    [HideInInspector] public Diary[] Public_Diary;

    // Start is called before the first frame update
    void Start()
    {

        wewewi();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void wewewi()
    {

        Diary diary = new Diary();

#if UNITY_EDITOR
        if (File.Exists(Application.dataPath + "savedata.json"))
        {
//#elif UNITY_ANDROID
  //          if (File.Exists(Application.dataPath +"/Directory_path/savedata.json")){
        
#endif
            StreamReader reader;

#if UNITY_EDITOR
            reader = new StreamReader(Application.dataPath + "savedata.json");
//#elif UNITY_ANDROID
  //          reader = new StreamReader(Application.persistentDataPath + "/Directory_path/savedata.json", Encoding.GetEncoding("utf-8"));
#endif

            string diaryDay = "0";
            string data = reader.ReadToEnd();


            reader.Close();

            splitText = data.Split(char.Parse("\n"));

            Public_Diary = new Diary[splitText.Length];

            int DayCount = 0;

            int i = 0;

            foreach (string line in splitText)
            {
                if (line.Length > 0)
                {

                    diary = JsonUtility.FromJson<Diary>(line);
                    Public_Diary[i] = diary;

                    if (diaryDay != diary.dt_string)
                    {

                        diaryDay = diary.dt_string;
                        DayCount++;

                        splitList.Add(diaryDay);

                    }

                    i++;
                }
            }

            CountDiaryDays = new int[DayCount];

            int j = -1;
            foreach (string line in splitText)
            {
                if (line.Length > 0)
                {

                    diary = JsonUtility.FromJson<Diary>(line);

                    if (diaryDay != diary.dt_string)
                    {
                        diaryDay = diary.dt_string;
                        j++;
                    }

                    CountDiaryDays[j] += 1;
                }
            }
        }

        dropdown.ClearOptions();
        dropdown.AddOptions(splitList);


        dayDropdown.ChangeScrollViewFromDropdown();



    }



}
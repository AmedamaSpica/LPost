using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class DayDropdown : MonoBehaviour
{

    [SerializeField] TMP_Dropdown dropdown;
    [SerializeField] outputDiary outputdiary;

    [SerializeField] private GameObject UI_Diary;
    [SerializeField] private Transform contect;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeScrollViewFromDropdown()
    {

        Transform[] UI_Diary_Hairetu = new Transform[outputdiary.CountDiaryDays[dropdown.value]];
        TextMeshProUGUI[] UI_Text = new TextMeshProUGUI[outputdiary.CountDiaryDays[dropdown.value]];

        for(int i = 0;i < contect.childCount;i++)
        {
            contect.GetChild(i).gameObject.SetActive(false);
            Destroy(contect.GetChild(i).gameObject);
        }
        

        for (int i = 0,j = 0; i < outputdiary.CountDiaryDays[dropdown.value] && j < outputdiary.Public_Diary.Length; j++)
        {
            

            if (dropdown.options[dropdown.value].text == outputdiary.Public_Diary[j].dt_string)
            {
                UI_Diary_Hairetu[i] = Instantiate(UI_Diary, contect).transform;
                UI_Text[i] = UI_Diary_Hairetu[i].GetComponent<TextMeshProUGUI>();
                
                UI_Text[i].text = outputdiary.Public_Diary[j].diary_text;
                i++;
            }
            
        }


    }

}



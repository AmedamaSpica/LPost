using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using Unity.VisualScripting;

public class DayTime : MonoBehaviour
{

    int dtIntAW;int dtIntNow;
    DateTime dt;DateTime dt2;
    public TextMeshProUGUI DayText;
    // Start is called before the first frame update
    void Start()
    {
        dt = DateTime.Now;

        dtIntNow = int.Parse(PlayerPrefs.GetString("dt"));

        if(dtIntNow < int.Parse(dt.ToString("yyyyMMdd")))
        {
            PlayerPrefs.SetString("dt", dt.ToString("yyyyMMdd"));
        }

        DayText.text = PlayerPrefs.GetString("dt");

        

        

        if (int.Parse(dt.ToString("yyyyMMdd")) >= int.Parse(PlayerPrefs.GetString("dtAfterWeek")))
        {

            dt2 = dt + TimeSpan.FromDays(7);
            PlayerPrefs.SetString("dtAfterWeek", dt2.ToString("yyyyMMdd"));

        }

        dtIntAW = int.Parse(PlayerPrefs.GetString("dtAfterWeek"));

        Debug.Log(dtIntAW + " : " + dtIntNow);
        

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

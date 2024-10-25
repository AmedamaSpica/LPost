using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class DayTime : MonoBehaviour
{

    int dtInt ;
    DateTime dt;DateTime dt2;
    public TextMeshProUGUI DayText;
    // Start is called before the first frame update
    void Start()
    {
        dt = DateTime.Now;
        dt += TimeSpan.FromDays(7);
         
        PlayerPrefs.SetString("dt", dt.ToString("yyyyMMdd"));
        //コンソールに表示
        DayText.text = PlayerPrefs.GetString("dt");

        dtInt = int.Parse(PlayerPrefs.GetString("dt"));

        Debug.Log(dtInt -1);
        Debug.Log(DateTime.Compare(dt,dt2));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

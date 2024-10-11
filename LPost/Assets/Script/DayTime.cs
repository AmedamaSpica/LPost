using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class DayTime : MonoBehaviour
{

    DateTime dt;
    public TextMeshProUGUI DayText;
    // Start is called before the first frame update
    void Start()
    {
        dt = DateTime.Now;
        //コンソールに表示
        DayText.text = PlayerPrefs.GetString("dt");
        PlayerPrefs.SetString("dt", dt.ToString("yyyy/MM/dd HH:mm:ss"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NextDayButton : MonoBehaviour
{

    [SerializeField] UnityEvent SceneChangeEvent;
    SaveVariable SaveVariable;


    // Start is called before the first frame update
    void Start()
    {
        SaveVariable = GameObject.Find("GameManager").GetComponent<SaveVariable>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextDay()
    {
        LPPoint.LPower_week += 15;
        SaveVariable.NumberWeekJudge++;
        SceneChangeEvent.Invoke();
    }
}

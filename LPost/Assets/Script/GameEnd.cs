
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("LPower", LPPoint.LPower);
        Debug.Log(LPPoint.LPower);
        PlayerPrefs.Save();
        Application.Quit();
    }
}

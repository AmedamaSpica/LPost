using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {

        
        if (instance == null)
        {
            instance = this;
            LPPoint.LPower = PlayerPrefs.GetInt("LPower", 300);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

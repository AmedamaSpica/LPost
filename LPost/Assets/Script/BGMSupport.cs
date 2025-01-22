using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMSupport : MonoBehaviour
{
    [SerializeField] int BGM_No;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NumberChange()
    {
        SelectBGM.BGM_Number = BGM_No;
    }
}

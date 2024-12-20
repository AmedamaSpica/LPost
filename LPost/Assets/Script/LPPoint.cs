using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LPPoint : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI LPowerCount;
    LPCount LPCount;
    public static int LPower;
    public static int LPower_week;

    // Start is called before the first frame update
    void Start()
    {
        
        LPowerCount.text = LPower.ToString();

    }

    // Update is called once per frame
    void Update()
    {

    }
}

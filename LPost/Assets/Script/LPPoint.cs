using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LPPoint : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI LPowerCount;
    LPCount LPCount;
    public static int LPower;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteKey("LPower");
        LPower = PlayerPrefs.GetInt("LPower",300);
        LPowerCount.text = LPower.ToString();

    }

    // Update is called once per frame
    void Update()
    {

    }
}

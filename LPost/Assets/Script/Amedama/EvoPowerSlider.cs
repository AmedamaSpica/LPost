using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvoPowerSlider : MonoBehaviour
{

    Slider EvoSlider;

    // Start is called before the first frame update
    void Start()
    {
        EvoSlider = GameObject.Find("EvoSlider").GetComponent<Slider>();
        EvoSlider.value = LPPoint.LPower_week;
    }

    // Update is called once per frame
    void Update()
    {
        EvoSlider.value = LPPoint.LPower_week;
    }
}

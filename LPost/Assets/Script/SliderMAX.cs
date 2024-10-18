using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderMAX : MonoBehaviour
{

    [SerializeField] Slider Slider;
    LPPoint LPPoint;
    // Start is called before the first frame update
    void Start()
    {
        Slider.maxValue = LPPoint.LPower;
        Slider.value = LPPoint.LPower;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

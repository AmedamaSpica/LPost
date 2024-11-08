using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharactorTouch : MonoBehaviour
{


    [SerializeField] private GameObject clickedGameObject;
    [SerializeField] private Slider LPower_Slider;
    [SerializeField] private TextMeshProUGUI LPowerCount;
    [SerializeField] int Slider_TimesOfCount = 20;
    
    float LPower_minus;
    float LPower_OneFlame_minus;




    // Start is called before the first frame update
    void Start()
    {
        LPower_minus = LPPoint.LPower;
        LPower_OneFlame_minus = (float)LPPoint.LPower / Slider_TimesOfCount;

       
    }

    // Update is called once per frame

    void OnMouseDrag()
    {
        if (LPower_Slider.value > 0)
        {


            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit))
            {
                clickedGameObject = hit.collider.gameObject;
                LPower_Slider.value -= LPower_OneFlame_minus;

                

                LPowerCount.text = ((int)LPower_Slider.value).ToString();
                LPPoint.LPower = ((int)LPower_Slider.value);

            }

        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LPCount : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI LPowerCount;
    int LPower;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "tokoroten")
        {

            LPower++;            

            if (LPowerCount.enabled == false)
            {
                LPowerCount.enabled = true;
            }
  
            LPowerCount.text = LPower.ToString();
        }
    }
}

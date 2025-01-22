using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class LPCount : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI LPowerCount;
    [SerializeField] private AudioClip Sound;
    int charge_LPower;
    AudioSource AudioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GameObject.Find("GameManager").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "tokoroten")
        {

            charge_LPower++;
            LPPoint.LPower++;
            AudioSource.PlayOneShot(Sound);

            if (LPowerCount.enabled == false)
            {
                LPowerCount.enabled = true;
            }

            LPowerCount.text = charge_LPower.ToString();

        }
    }
}

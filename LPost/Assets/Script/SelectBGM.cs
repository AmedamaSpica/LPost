using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectBGM : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] BGMClip;
    [HideInInspector]public static int BGM_Number;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BGM()
    {
        audioSource.Stop();
        audioSource.clip = BGMClip[BGM_Number];
        audioSource.Play();
    }
}

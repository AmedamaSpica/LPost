using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{

    [SerializeField] AudioClip sound1;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.Find("GameManager").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SoundOneShot()
    {

        Debug.Log("‰¹‚Í‚È‚Á‚Ä‚é‚æ‚ñ");
        audioSource.PlayOneShot(sound1);
    }
}

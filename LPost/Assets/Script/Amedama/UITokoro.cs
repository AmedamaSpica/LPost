using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITokoro : MonoBehaviour
{

    [SerializeField] private GameObject MainCamera;
    // Start is called before the first frame update
    void Start()
    {
        if (MainCamera == null)
        {
            MainCamera = Camera.main.gameObject;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void LateUpdate()
    {
        //@ƒJƒƒ‰‚Æ“¯‚¶Œü‚«‚Éİ’è
        transform.rotation = MainCamera.transform.rotation;
    }
}


   

   


    

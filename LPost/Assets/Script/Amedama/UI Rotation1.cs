using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRotation1 : MonoBehaviour
{

    [SerializeField] private GameObject MainCamera;

    void Start()
    {
        if(MainCamera == null)
        {
            MainCamera = Camera.main.gameObject;
        }    
    }


    void LateUpdate()
    {
        //�@�J�����Ɠ��������ɐݒ�
        transform.rotation = MainCamera.transform.rotation;
    }
}

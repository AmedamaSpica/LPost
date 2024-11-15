using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryManager : MonoBehaviour
{
    [Header("ラベルの画像")]
    [SerializeField] private GameObject[] labels;

    [Header("0...ラベルを選んでね")]
    [SerializeField] private GameObject[] texts;
    //[SerializeField] private GameObject canvas;

    private bool selectLabel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetText()
    {
        if(selectLabel)
        {
            //ラベルを選んでね
            texts[0].SetActive(false);
        }
        else
        {
            texts[0].SetActive(true);
        }
    }

    public void Button1()
    {
        if (!selectLabel)
        {
            labels[0].SetActive(true);
            selectLabel = true;
        }
    }
    public void Button2()
    {
        if (!selectLabel)
        {
            labels[1].SetActive(true);
            selectLabel = true;
        }
    }
    public void Button3()
    {
        if (!selectLabel)
        {
            labels[2].SetActive(true);
            selectLabel = true;
        }
    }
    public void Button4()
    {
        if (!selectLabel)
        {
            labels[3].SetActive(true);
            selectLabel = true;
        }
    }
}

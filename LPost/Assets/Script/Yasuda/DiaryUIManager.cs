using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DiaryUIManager : MonoBehaviour
{
    [Header("0...ƒ‰ƒxƒ‹‚ð‘I‚ñ‚Å‚Ë")]
    [SerializeField] private GameObject[] texts;
    [SerializeField] private GameObject[] buttons;
    [SerializeField] private GameObject inputField;
    [SerializeField] private Image[] images;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private TextMeshProUGUI diaryText;
    //[SerializeField] private GameObject canvas;

    private InputField inputText;
    private int returnTimes;
    private int labelNumber;
    private bool firstText;
    private bool selectLabel;
    private bool writeDone;

    // Start is called before the first frame update
    void Start()
    {
        Set();
    }

    // Update is called once per frame
    void Update()
    {
        SetText();
        SetButton();
        SetImage();

        if(selectLabel)
        {
            inputField.SetActive(true);
        }
        else
        {
            inputField.SetActive(false);
        }
    }

    private void Set()
    {
        labelNumber = 0;
        returnTimes = 0;
        selectLabel= false;
        firstText = false;
        writeDone = false;
        inputText = inputField.GetComponent<InputField>();
    }

    private void SetText()
    {
        if (firstText)
        {
            texts[0].SetActive(false);
        }
        else
        {
            texts[0].SetActive(true);
        }
    }

    private void SetButton()
    {
        if (selectLabel)
        {
            for (int i = 1; i < 6; i++)
            {
                buttons[i].SetActive(false);
            }
            buttons[0].SetActive(true);
        }
        else
        {
            for (int i = 1; i < 6; i++)
            {
                buttons[i].SetActive(true);
            }
            buttons[0].SetActive(false);
        }
    }

    private void SetImage()
    {
        if (firstText)
        {
            images[0].enabled = true;
            images[0].sprite = sprites[labelNumber];
        }
        else
        {
            images[0].enabled = false;
        }
    }

    public void Button1()
    {
        labelNumber = 0;
        firstText = true;
    }
    public void Button2()
    {
        labelNumber = 1;
        firstText = true;
    }
    public void Button3()
    {
        labelNumber = 2;
        firstText = true;
    }
    public void Button4()
    {
        labelNumber = 3;
        firstText = true;
    }
    public void Back()
    {
        firstText = false;
        selectLabel = false;
    }
    public void Decision()
    {

        selectLabel = true;
    }

    public void InputText()
    {
        if (selectLabel)
        {
            if (inputText != null)
            {
                diaryText.text = inputText.text;
            }
        }
    }
}

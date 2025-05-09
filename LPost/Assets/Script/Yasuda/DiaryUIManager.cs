using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;



public class DiaryUIManager : MonoBehaviour
{
    //0...Ex
    //1...日記
    [SerializeField] private TextMeshProUGUI[] texts;
    [SerializeField] private GameObject[] buttons;
    [SerializeField] private GameObject inputField;
    [SerializeField] private Image[] images;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private TextMeshProUGUI diaryText;
    //[SerializeField] private GameObject canvas;

    private TMP_InputField inputText;
    private int returnTimes;
    private int labelNumber;
    private bool firstText;
    private bool selectLabel;

    public bool writeDone { get; set; }

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

        //Debug.Log(writeDone);

        /*if(writeDone)
        {
            SceneManager.LoadScene("Mix");
        }*/
    }

    private void Set()
    {
        labelNumber = 0;
        returnTimes = 0;
        selectLabel= false;
        firstText = false;
        writeDone = false;
        inputText = inputField.GetComponent<TMP_InputField>();
    }

    private void SetText()
    {
        if (firstText)
        {
            texts[0].text = "";
        }
        else
        {
            texts[0].text = "気持ちを選んでね！";
        }

        if(!selectLabel)
        {
            texts[2].text = "戻る";
        }
        else
        {
            texts[2].text = "選びなおす";
        }

        if (writeDone)
        {
            texts[0].text = "楽しそうだね！";
        }
    }

    private void SetButton()
    {
        if (selectLabel)
        {
            for (int i = 2; i < 6; i++)
            {
                buttons[i].SetActive(false);
            }
            buttons[0].SetActive(true);

            inputField.SetActive(true);
            texts[1].enabled = true;
        }
        else
        {
            for (int i = 2; i < 6; i++)
            {
                buttons[i].SetActive(true);
            }
            buttons[0].SetActive(true);

            inputField.SetActive(false);
            texts[1].enabled = false;
        }

        if(writeDone)
        {

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

        if(writeDone)
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
        if (!selectLabel)
        {
            SceneManager.LoadScene("Sample Scene");
        }

        firstText = false;
        selectLabel = false;
        buttons[1].SetActive(true);
        buttons[6].SetActive(false);
    }

    public void Decision()
    {
        if (!selectLabel)
        {
            selectLabel = true;
            buttons[1].SetActive(false);
            buttons[6].SetActive(true);
        }
        else
        {
            if (diaryText.text.Length > 0)
            {
                writeDone = true;
            }
        }
    }

    public void InputText()
    {
        if (selectLabel)
        {
            if (inputText.text.Length < 77)
            {
                diaryText.text = inputText.text;
            }
        }
    }
}

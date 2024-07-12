using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MixLetter : MonoBehaviour
{
    [SerializeField] TMP_InputField inputfield;
    [SerializeField] TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        inputfield = inputfield.GetComponent<TMP_InputField>();
        text = text.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InputText()
    {
        text.text = inputfield.text;
    }
}

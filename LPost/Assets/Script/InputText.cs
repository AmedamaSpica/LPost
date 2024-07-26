using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputText : MonoBehaviour
{
    TMP_InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        inputField = GameObject.Find("InputField (TMP)").GetComponent<TMP_InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InputName()
    {
        string name = inputField.text;
        Debug.Log(name);
    }
}

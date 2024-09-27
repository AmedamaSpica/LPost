using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputText : MonoBehaviour
{
    [SerializeField] private GameObject mix;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TMP_InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        inputField = GameObject.Find("InputField (TMP)").GetComponent<TMP_InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Return))
        {
            mix.SetActive(true);
        }
    }

    public void Inputtext()
    {
        text.text = inputField.text;
    }
}

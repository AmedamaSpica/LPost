using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.TextCore.Text;
using System.Data;

public class CharaFureai : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI CharacterText;
    [SerializeField] private UnityEngine.TextAsset Character_textAsset;

    private string loadText;
    private string[] splitText;
    private int textNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        loadText = Character_textAsset.text;
        splitText = loadText.Split(char.Parse("\n"));

        Debug.Log(splitText[0]);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();



            if (Physics.Raycast(ray, out hit))
            {

                if (splitText[textNum] != "")
                {
                    CharacterText.text = splitText[textNum];
                    textNum++;
                    if (textNum >= splitText.Length)
                    {
                        textNum = 0;
                    }
                }
                else
                {
                    CharacterText.text = "";
                    textNum++;
                }

            }

        }
    }
}




using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextColor : MonoBehaviour
{
    Vector2 nowPos = new Vector2();
    Vector2 lastPos = new Vector2();

    public TextMeshProUGUI text;

    private float mycolor;

    GameObject Pofin = new GameObject();
    Mix mix;

    // Start is called before the first frame update
    void Start()
    {
        Pofin = GameObject.Find("pofin");
        mix = Pofin.GetComponent<Mix>();
        mycolor = mix.textColor;

        text = this.GetComponent<TextMeshProUGUI>();
        //RectTransform_get.anchoredPosition = lastPos;
    }

    // Update is called once per frame
    void Update()
    {
        mycolor = mix.textColor;
        text.color = new Color(0.7f, 0.6f, 0.0f, mycolor);
    }
}

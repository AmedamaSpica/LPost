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

    // Start is called before the first frame update
    void Start()
    {
        text = this.GetComponent<TextMeshProUGUI>();
        mycolor = 1.0f;
        //RectTransform_get.anchoredPosition = lastPos;
    }

    // Update is called once per frame
    void Update()
    {
        //RectTransform_get.anchoredPosition = nowPos;
        if (mycolor > 0)
        {
            mycolor = mycolor - 0.01f;
        }

        text.color = new Color(0, 0, 0, mycolor);
    }
}

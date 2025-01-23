using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Tokorotenn : MonoBehaviour
{
    Vector2 nowPosition = new Vector2();
    private RectTransform RectTransform_get;

    // Start is called before the first frame update
    void Start()
    {
        RectTransform_get = this.GetComponent<RectTransform>();

        RectTransform_get.anchoredPosition = nowPosition;

        RectTransform_get.anchoredPosition = new Vector2(-313.0f, 431.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 nowPos = Input.mousePosition;

        //int touchCount = Input.touchCount;
        //Vector2 nowPos = Input.GetTouch(0).position;


        RectTransform_get.anchoredPosition = new Vector2(nowPosition.x + -313.0f, nowPos.y - 200.0f);

        if (RectTransform_get.anchoredPosition.y > 700.0f)
        {
            RectTransform_get.anchoredPosition = new Vector2(nowPosition.x + -313.0f, 700.0f);
        }

        if (RectTransform_get.anchoredPosition.y < -80.0f)
        {
            RectTransform_get.anchoredPosition = new Vector2(nowPosition.x + -313.0f, -80.0f);
        }
    }
}

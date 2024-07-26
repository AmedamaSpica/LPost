using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Mix : MonoBehaviour
{
    [SerializeField] private GameObject inputTextBox;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject PP;

    private string inputText;
    private float rotationSpeed;
    private bool Separate;

    private GameObject pp;
    private Vector3 lastMousePosition;
    private RectTransform imageRectTransform;
    private RectTransform RectTransform_get;

    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = 1.0f;
        Separate = true;

        imageRectTransform = GetComponent<RectTransform>();
        inputText = text.text;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();

        if (Separate)
        {
            if (text.text == null)
            {
                inputText = text.text;
                return;
            }

            TextSeparate();
            pp= Instantiate(PP);
            Separate = false;

            if (pp.transform.localScale.x > 100.0f)
            {
                SceneManager.LoadScene("amedama Scene 1");
            }
        }
    }

    private void Rotate()
    {
        if (Input.GetMouseButton(0))
        {
            // 現在のマウスの位置を取得
            Vector3 currentMousePosition = Input.mousePosition;

            // マウスの移動量を計算して回転角度に変換
            Vector3 mouseDelta = currentMousePosition - lastMousePosition;
            float rotationAngle = -mouseDelta.x * rotationSpeed;

            // 画像をZ軸を中心に回転させる
            transform.Rotate(Vector3.forward, rotationAngle);
            text.transform.Rotate(Vector3.forward,1.0f);

            // 現在のマウス位置を前フレームの位置として保存
            lastMousePosition = currentMousePosition;

            pp.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
        }
    }

    private void TextSeparate()
    {
        for (int i = 1; i <= inputText.Length; i++)
        {
            // プレハブ生成(この時点では、まだ、空のText)
            TextMeshProUGUI word = Resources.Load<TextMeshProUGUI>("Word");
            TextMeshProUGUI newObj = Instantiate(word,Vector3.zero, Quaternion.identity,inputTextBox.transform);

            // 生成された各オブジェクトに文字を1文字ずつ入れる
            newObj.text = inputText.Substring(i - 1, 1);

            // 生成された各オブジェクトの名前を変更
            newObj.name = "word" + "(" + newObj.text + ")";

            // 各文字の位置を調整
            float offset = 2.0f; // 文字間のオフセット（適宜調整する）
            RectTransform_get = newObj.GetComponent<RectTransform>();
            RectTransform_get.position = new Vector2(imageRectTransform.position.x + i, imageRectTransform.position.y);
        }

        inputTextBox.transform.position = new Vector3(-inputText.Length * 0.5f, 0.0f, 0.0f);
    }
}

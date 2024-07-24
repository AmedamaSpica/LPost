using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Mix : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private GameObject inputTextBox;
    private string inputText;
     private float rotationSpeed;
    private Vector3 lastMousePosition;

    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        InputText();
        Rotate();
        TextSeparate();
    }

    public void InputText()
    {
        inputText = inputField.text;
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

            // 現在のマウス位置を前フレームの位置として保存
            lastMousePosition = currentMousePosition;
        }
    }

    private void TextSeparate()
    {

        for (int i = 1; i <= inputText.Length; i++)
        {
            // プレハブ生成(この時点では、まだ、空のText)
            GameObject word = (GameObject)Resources.Load("Word");
            var newObj = Instantiate(word, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity) as GameObject;

            // 生成された各オブジェクトに文字を1文字ずつ入れる
            newObj.GetComponent<TextMesh>().text = inputText.Substring(i - 1, 1);

            // 生成された各オブジェクトの名前を変更
            newObj.name = "word" + "(" + inputText.Substring(i - 1, 1) + ")";

            // 各文字の位置を調整
            newObj.transform.parent = inputTextBox.transform;
            newObj.transform.localPosition = new Vector3(160.0f * (i - 1), -151.0f, 0.0f);
            inputTextBox.transform.localPosition = new Vector3(-80.0f * (i - 1), 0.0f, 0.0f);
        }
    }
}

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
            // ���݂̃}�E�X�̈ʒu���擾
            Vector3 currentMousePosition = Input.mousePosition;

            // �}�E�X�̈ړ��ʂ��v�Z���ĉ�]�p�x�ɕϊ�
            Vector3 mouseDelta = currentMousePosition - lastMousePosition;
            float rotationAngle = -mouseDelta.x * rotationSpeed;

            // �摜��Z���𒆐S�ɉ�]������
            transform.Rotate(Vector3.forward, rotationAngle);

            // ���݂̃}�E�X�ʒu��O�t���[���̈ʒu�Ƃ��ĕۑ�
            lastMousePosition = currentMousePosition;
        }
    }

    private void TextSeparate()
    {

        for (int i = 1; i <= inputText.Length; i++)
        {
            // �v���n�u����(���̎��_�ł́A�܂��A���Text)
            GameObject word = (GameObject)Resources.Load("Word");
            var newObj = Instantiate(word, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity) as GameObject;

            // �������ꂽ�e�I�u�W�F�N�g�ɕ�����1�����������
            newObj.GetComponent<TextMesh>().text = inputText.Substring(i - 1, 1);

            // �������ꂽ�e�I�u�W�F�N�g�̖��O��ύX
            newObj.name = "word" + "(" + inputText.Substring(i - 1, 1) + ")";

            // �e�����̈ʒu�𒲐�
            newObj.transform.parent = inputTextBox.transform;
            newObj.transform.localPosition = new Vector3(160.0f * (i - 1), -151.0f, 0.0f);
            inputTextBox.transform.localPosition = new Vector3(-80.0f * (i - 1), 0.0f, 0.0f);
        }
    }
}

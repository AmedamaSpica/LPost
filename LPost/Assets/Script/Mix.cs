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
    private Vector2 lastTouchPosition;
    private Vector3 imagePosition;
    private RectTransform imageRectTransform;
    private RectTransform RectTransform_get;

    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = 1.0f;
        Separate = true;
        imagePosition = this.transform.position;

        imageRectTransform = GetComponent<RectTransform>();
        inputText = text.text;
    }

    // Update is called once per frame
    void Update()
    {
        MouseRotate();
        TouchRotate();

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
        }

        if (pp.transform.localScale.x > 10.0f)
        {
            SceneManager.LoadScene("amedama Scene 1");
        }
    }

    private void MouseRotate()
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
            text.transform.Rotate(Vector3.forward,1.0f);

            // ���݂̃}�E�X�ʒu��O�t���[���̈ʒu�Ƃ��ĕۑ�
            lastMousePosition = currentMousePosition;

            pp.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
        }
    }

    private void TouchRotate()
    {
        // �^�b�`����Ă���w�̐����擾
        int touchCount = Input.touchCount;

        // �^�b�`����Ă���w��1�{�ȏ�̏ꍇ
        if (touchCount > 0)
        {
            // �ŏ��̃^�b�`�ʒu���擾
            Touch touch = Input.GetTouch(0);

            // �^�b�`�̎�ނ��ړ��ŁA�O�t���[���Ƃ̈ʒu�̍���������ꍇ
            if (touch.phase == TouchPhase.Moved)
            {
                // �^�b�`�̍������v�Z���ĉ�]�p�x�ɕϊ�
                Vector2 touchDelta = touch.position - lastTouchPosition;
                float rotationAngle = touchDelta.x * rotationSpeed;

                // �摜����]������
                transform.Rotate(Vector3.up, -rotationAngle);
                pp.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
            }

            // ���݂̃^�b�`�ʒu��O�t���[���̈ʒu�Ƃ��ĕۑ�
            lastTouchPosition = touch.position;
        }
    }

    private void TextSeparate()
    {
        for (int i = 1; i <= inputText.Length; i++)
        {
            // �v���n�u����(���̎��_�ł́A�܂��A���Text)
            TextMeshProUGUI word = Resources.Load<TextMeshProUGUI>("Word");
            TextMeshProUGUI newObj = Instantiate(word,Vector3.zero, Quaternion.identity,inputTextBox.transform);

            // �������ꂽ�e�I�u�W�F�N�g�ɕ�����1�����������
            newObj.text = inputText.Substring(i - 1, 1);

            // �������ꂽ�e�I�u�W�F�N�g�̖��O��ύX
            newObj.name = "word" + "(" + newObj.text + ")";

            // �e�����̈ʒu�𒲐�
            float offset = 2.0f; // �����Ԃ̃I�t�Z�b�g�i�K�X��������j
            RectTransform_get = newObj.GetComponent<RectTransform>();
            RectTransform_get.position = new Vector2(imageRectTransform.position.x + i, imageRectTransform.position.y);
        }

        inputTextBox.transform.position = new Vector3(-inputText.Length * 0.5f, 0.0f, 0.0f);
    }
}

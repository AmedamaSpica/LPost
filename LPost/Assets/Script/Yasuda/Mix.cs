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
    private string inputText;
    private float rotationSpeed;
    private bool Separate;
    private bool ableMix;
    private Vector3 lastPos = new Vector3();
    private Vector2 lastTouchPosition;   
    private Vector3 imagePosition;
    private RectTransform imageRectTransform;
    private RectTransform RectTransform_get;
    private float change;
    private float textColor;
    private bool isText;

    private Color[] mixText;

    // Start is called before the first frame update
    void Start()
    {
        Set();
        SetText();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MouseRotate();
        TouchRotate();

        if(ableMix)
        {
            Debug.Log("Mix");
            //MixText();
            //SetText();
        }

        if (change > 8.0f)
        {
            Debug.Log(change);
            SceneManager.LoadScene("amedama Scene 1");
        }

        if (isText)
        {
            for (int i = 0; i < mixText.Length; i++)
            {
               //mixText[i].color = new Color(1, 0, 0, textColor);
            }
        }
    }

    private void Set()
    {
        GameObject DiaryBase = GameObject.Find("DiaryBase");
        DiaryManager diarymanager;
        diarymanager = DiaryBase.GetComponent<DiaryManager>();
        inputText = diarymanager.DiaryText;

        rotationSpeed = 4.0f;
        Separate = true;
        ableMix = false;
        imagePosition = this.transform.position;

        imageRectTransform = GetComponent<RectTransform>();

        change = 0.0f;
        textColor = 8.0f;
        isText = false;
    }

    private void MouseRotate()
    {
        if (Input.GetMouseButton(0))
        {
            // ���݂̃}�E�X�̈ʒu���擾
            Vector3 nowPos = Input.mousePosition;
            Vector3 difference = nowPos - lastPos;

            //���Ɛ̂̍����{��
            if (difference.x < 0)
            {
                difference.x = -difference.x;
            }
            if (difference.y < 0)
            {
                difference.y = -difference.y;
            }

            //�~���l�������Ĉړ��ʂłǂ����ɉ񂵂Ă邩���f����
            if (difference.x > 3 || difference.y > 3)
            {
                ableMix = true;
                if (difference.x > difference.y)
                {
                    if (nowPos.y > 1103 && nowPos.y < 1583)
                    {
                        if (lastPos.x > nowPos.x)
                        {
                            transform.Rotate(Vector3.forward, rotationSpeed);
                        }
                        else
                        {
                            transform.Rotate(Vector3.forward, -rotationSpeed);
                        }
                    }
                    else if (nowPos.y > 614 && nowPos.y <= 1103)
                    {
                        if (lastPos.x > nowPos.x)
                        {
                            transform.Rotate(Vector3.forward, -rotationSpeed);
                        }
                        else
                        {
                            transform.Rotate(Vector3.forward, rotationSpeed);
                        }
                    }
                }
                else
                {
                    if (nowPos.x > 527 && nowPos.x < 1010)
                    {
                        if (lastPos.y > nowPos.y)
                        {
                            transform.Rotate(Vector3.forward, -rotationSpeed);
                        }
                        else
                        {
                            transform.Rotate(Vector3.forward, rotationSpeed);
                        }
                    }
                    else if (nowPos.x > 34 && nowPos.x <= 527)
                    {
                        if (lastPos.y > nowPos.y)
                        {
                            transform.Rotate(Vector3.forward, rotationSpeed);
                        }
                        else
                        {
                            transform.Rotate(Vector3.forward, -rotationSpeed);
                        }
                    }
                }

                change += 0.05f;
                textColor -= change;
            }
            else
            {
                ableMix = false;
            }

            // ���݂̃}�E�X�ʒu��O�t���[���̈ʒu�Ƃ��ĕۑ�
            lastPos = nowPos;

            //pp.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
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
            //Touch touch = Input.GetTouch(0);
            Vector2 nowPos = Input.GetTouch(0).position;
            Vector2 difference = nowPos - lastTouchPosition;

            //���Ɛ̂̍����{��
            if (difference.x < 0)
            {
                difference.x = -difference.x;
            }
            if (difference.y < 0)
            {
                difference.y = -difference.y;
            }

            //�~���l�������Ĉړ��ʂłǂ����ɉ񂵂Ă邩���f����
            if (difference.x > 3 || difference.y > 3)
            {
                ableMix = true;
                if (difference.x > difference.y)
                {
                    if (nowPos.y > 1103 && nowPos.y < 1583)
                    {
                        if (lastTouchPosition.x > nowPos.x)
                        {
                            transform.Rotate(Vector3.forward, rotationSpeed);
                        }
                        else
                        {
                            transform.Rotate(Vector3.forward, -rotationSpeed);
                        }
                    }
                    else if (nowPos.y > 614 && nowPos.y <= 1103)
                    {
                        if (lastTouchPosition.x > nowPos.x)
                        {
                            transform.Rotate(Vector3.forward, -rotationSpeed);
                        }
                        else
                        {
                            transform.Rotate(Vector3.forward, rotationSpeed);
                        }
                    }
                }
                else
                {
                    if (nowPos.x > 527 && nowPos.x < 1010)
                    {
                        if (lastTouchPosition.y > nowPos.y)
                        {
                            transform.Rotate(Vector3.forward, -rotationSpeed);
                        }
                        else
                        {
                            transform.Rotate(Vector3.forward, rotationSpeed);
                        }
                    }
                    else if (nowPos.x > 34 && nowPos.x <= 527)
                    {
                        if (lastTouchPosition.y > nowPos.y)
                        {
                            transform.Rotate(Vector3.forward, rotationSpeed);
                        }
                        else
                        {
                            transform.Rotate(Vector3.forward, -rotationSpeed);
                        }
                    }
                }

                change += 0.05f;
            }
            else
            {
                ableMix = false;
            }

            // ���݂̃^�b�`�ʒu��O�t���[���̈ʒu�Ƃ��ĕۑ�
            lastTouchPosition = nowPos;
        }
    }

    float changeAngle = 90.0f;
    float changeRadius = 300.0f;

    TextMeshProUGUI newObj;
    private void SetText()
    {
        int CircleSeparate;
        float addangle;
        float addradius;
        float[] angle = new float[inputText.Length];
        float[] radius = new float[inputText.Length];

        addangle = 360.0f / inputText.Length;
        addradius = 300.0f / inputText.Length;

        if (inputText.Length % 2 >= 1)
        {
            CircleSeparate = inputText.Length + 1;
        }

        for (int i = 0; i < inputText.Length; i++)
        {
            //����90���ŏ��̕����̈ʒu���w��
            angle[i] = ((-addangle * i) + changeAngle);
            radius[i] = changeRadius - (addradius * i);
        }

        for (int i = 0; i < inputText.Length; i++)
        {
            // �v���n�u����(���̎��_�ł́A�܂��A���Text)
            TextMeshProUGUI word = Resources.Load<TextMeshProUGUI>("Word");//�z��ɂ���΂����̂ł́H�H
            newObj = Instantiate(word, Vector3.zero, Quaternion.identity, gameObject.transform);

            // �������ꂽ�e�I�u�W�F�N�g�ɕ�����1�����������
            newObj.text = inputText.Substring(i, 1);

            // �������ꂽ�e�I�u�W�F�N�g�̖��O��ύX
            newObj.name = "word" + "(" + newObj.text + ")";

            //�e�L�X�g��z�u
            newObj.fontSize = 200 - ((100 / inputText.Length) * i);
            RectTransform_get = newObj.GetComponent<RectTransform>();
            RectTransform_get.anchoredPosition = new Vector2((radius[i] * Mathf.Cos(angle[i])) - 65.0f, (radius[i] * Mathf.Sin(angle[i])) + 10.0f);

            //mixText[i] = newObj.color;

            if (i == inputText.Length - 1)
            {
                isText = true;
            }
        }
    }

    private void MixText()
    {
        changeAngle -= 5.0f;
        changeRadius -= 5.0f;
    }
}
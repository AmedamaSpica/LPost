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

    // Start is called before the first frame update
    void Start()
    {
        Set();
        SetText();
    }

    // Update is called once per frame
    void Update()
    {
        MouseRotate();
        TouchRotate();

        if(ableMix)
        {
            Debug.Log("Mix");
            MixText();
            SetText();
        }
    }

    private void Set()
    {
        GameObject DiaryBase = GameObject.Find("DiaryBase");
        DiaryManager diarymanager;
        diarymanager = DiaryBase.GetComponent<DiaryManager>();
        inputText = diarymanager.DiaryText;

        rotationSpeed = 1.0f;
        Separate = true;
        ableMix = false;
        imagePosition = this.transform.position;

        imageRectTransform = GetComponent<RectTransform>();
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
                            transform.Rotate(Vector3.forward, 1.0f);
                        }
                        else
                        {
                            transform.Rotate(Vector3.forward, -1.0f);
                        }
                    }
                    else if (nowPos.y > 614 && nowPos.y <= 1103)
                    {
                        if (lastPos.x > nowPos.x)
                        {
                            transform.Rotate(Vector3.forward, -1.0f);
                        }
                        else
                        {
                            transform.Rotate(Vector3.forward, 1.0f);
                        }
                    }
                }
                else
                {
                    if (nowPos.x > 527 && nowPos.x < 1010)
                    {
                        if (lastPos.y > nowPos.y)
                        {
                            transform.Rotate(Vector3.forward, -1.0f);
                        }
                        else
                        {
                            transform.Rotate(Vector3.forward, 1.0f);
                        }
                    }
                    else if (nowPos.x > 34 && nowPos.x <= 527)
                    {
                        if (lastPos.y > nowPos.y)
                        {
                            transform.Rotate(Vector3.forward, 1.0f);
                        }
                        else
                        {
                            transform.Rotate(Vector3.forward, -1.0f);
                        }
                    }
                }
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
            Touch touch = Input.GetTouch(0);

            // �^�b�`�̎�ނ��ړ��ŁA�O�t���[���Ƃ̈ʒu�̍���������ꍇ
            if (touch.phase == TouchPhase.Moved)
            {
                // �^�b�`�̍������v�Z���ĉ�]�p�x�ɕϊ�
                Vector2 touchDelta = touch.position - lastTouchPosition;
                float rotationAngle = touchDelta.x * rotationSpeed;

                // �摜����]������
                transform.Rotate(Vector3.forward, -rotationAngle);
                //pp.transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
            }

            // ���݂̃^�b�`�ʒu��O�t���[���̈ʒu�Ƃ��ĕۑ�
            lastTouchPosition = touch.position;
        }
    }

    private TextMeshProUGUI[] mixText;
    float changeAngle = 90.0f;
    float changeRadius = 410.0f;

    private void SetText()
    {
        int CircleSeparate;
        float addangle;
        float addradius;
        float[] angle = new float[inputText.Length];
        float[] radius = new float[inputText.Length];

        addangle = 360.0f / inputText.Length;
        addradius = 410.0f / inputText.Length;

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
            TextMeshProUGUI newObj = Instantiate(word, Vector3.zero, Quaternion.identity, gameObject.transform);

            // �������ꂽ�e�I�u�W�F�N�g�ɕ�����1�����������
            newObj.text = inputText.Substring(i, 1);

            // �������ꂽ�e�I�u�W�F�N�g�̖��O��ύX
            newObj.name = "word" + "(" + newObj.text + ")";

            //�e�L�X�g��z�u
            newObj.fontSize = 200 - ((100 / inputText.Length) * i);
            RectTransform_get = newObj.GetComponent<RectTransform>();
            RectTransform_get.anchoredPosition = new Vector2((radius[i] * Mathf.Cos(angle[i])) - 70.0f, (radius[i] * Mathf.Sin(angle[i])) + 15.0f);
            mixText[i] = newObj;
        }
    }

    private void MixText()
    {
        changeAngle -= 5.0f;
        changeRadius -= 5.0f;
    }
}
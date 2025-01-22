using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class kiziMix : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 3.0f;
    [SerializeField] private AudioClip sound;

    private bool ableMix;
    private bool isPlaying;
    private bool music;
    private Vector3 lastPos = new Vector3();
    private Vector2 lastTouchPosition;
    private float change;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        ableMix = false;
        music = true;
        isPlaying = false;
        change = 0.0f;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //audioSource.Play();
    }

    void FixedUpdate()
    {
        MouseRotate();
        TouchRotate();

        if (isPlaying)
        {
            if (music)
            {
                audioSource.Play();
                Debug.Log("流れてる");
                music = false;
            }
        }
        else
        {
            audioSource.Stop();
            music = true;
        }
    }

    private void MouseRotate()
    {
        if (Input.GetMouseButton(0))
        {
            // 現在のマウスの位置を取得
            Vector3 nowPos = Input.mousePosition;
            Vector3 difference = nowPos - lastPos;

            //今と昔の差を＋に
            if (difference.x < 0)
            {
                difference.x = -difference.x;
            }
            if (difference.y < 0)
            {
                difference.y = -difference.y;
            }

            //円を四分割して移動量でどっちに回してるか判断した
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

                isPlaying = true;
            }
            else
            {
                isPlaying = false;
                ableMix = false;
            }
            
            // 現在のマウス位置を前フレームの位置として保存
            lastPos = nowPos;

            //pp.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
        }
    }

    private void TouchRotate()
    {
        // タッチされている指の数を取得
        int touchCount = Input.touchCount;

        // タッチされている指が1本以上の場合
        if (touchCount > 0)
        {
            // 最初のタッチ位置を取得
            //Touch touch = Input.GetTouch(0);
            Vector2 nowPos = Input.GetTouch(0).position;
            Vector2 difference = nowPos - lastTouchPosition;

            //今と昔の差を＋に
            if (difference.x < 0)
            {
                difference.x = -difference.x;
            }
            if (difference.y < 0)
            {
                difference.y = -difference.y;
            }

            //円を四分割して移動量でどっちに回してるか判断した
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
                isPlaying = true;
            }
            else
            {
                isPlaying = false;
                ableMix = false;
            }

            // 現在のタッチ位置を前フレームの位置として保存
            lastTouchPosition = nowPos;
        }
    }
}

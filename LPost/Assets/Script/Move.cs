using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] GameObject cube;

    private GameObject TouchArea;

    // Start is called before the first frame update
    void Start()
    {
        TouchArea = Instantiate(cube, Vector3.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        //Input.touchCount�͉�ʂɉ��{�w���G��Ă��邩�̔���
        if (Input.touchCount > 0 || Input.GetMouseButton(0))
        { // Editor/�}�E�X����̏ꍇ�� Input.GetMouseButton(0) �ɂ���

            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            TouchArea.transform.position = pos;

        }
    }
}
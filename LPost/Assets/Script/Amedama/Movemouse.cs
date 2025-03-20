using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movemouse : MonoBehaviour
{ 
    private Vector3 mOffset;
    private float mZCoord;
    private Vector3 firstMousePoint;
    private Vector3 ObjectLocalScale = Vector3.one;
    public GameObject transformObject;

    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();

        firstMousePoint = GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {

        transform.position = GetMouseWorldPos() + mOffset;

    }
}
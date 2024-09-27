using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharactorTouch : MonoBehaviour
{


    [SerializeField] private GameObject clickedGameObject;
    [SerializeField] private Slider LPower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    void OnMouseDrag()
    {

        

           // clickedGameObject = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit))
            {
                clickedGameObject = hit.collider.gameObject;
                LPower.value -= 0.1f;
            }

            Debug.Log(clickedGameObject);
       
    }
}

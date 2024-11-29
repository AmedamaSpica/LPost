using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TokorotenPush : MonoBehaviour
{

    [SerializeField] private GameObject tokorotenPrefab;
    [SerializeField] private GameObject MainCamera;

    [SerializeField] private Animator CameraTransition;
    
    // Start is called before the first frame update
    void Start()
    {
        CameraTransition = MainCamera.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    private void OnTriggerStay(Collider other)
    {

        

        if(other.name == "tokoroten border" )
        {
           
            
            if (transform.localScale.y >= 0.01f)
            {

               
                transform.localScale += new Vector3(0, 1, 0) * -0.1f;

                GameObject tokorotenBlock = Instantiate(tokorotenPrefab, transform.position + Vector3.down * 1 + new Vector3(-1,0,-1) * Random.Range(-3.0f, 3.0f), Quaternion.identity);
            }
            else 
            {
                Destroy(gameObject);

                
               
                CameraTransition.SetBool("AllPushed", true);

            }
            
        }
        
    }
}

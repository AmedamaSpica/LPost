using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokorotenPush : MonoBehaviour
{

    [SerializeField] private GameObject tokorotenPrefab;
    public GameObject[] Cameras;

    int a;
    // Start is called before the first frame update
    void Start()
    {
        
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

                a++;
                Debug.Log(a);
                transform.localScale += new Vector3(0, 1, 0) * -0.1f;

                GameObject tokorotenBlock = Instantiate(tokorotenPrefab, transform.position + Vector3.down * 1 + new Vector3(-1,0,-1) * Random.Range(-2.0f, 2.0f), Quaternion.identity);
            }
            else 
            {
                Destroy(gameObject);

                
                Cameras[0].gameObject.SetActive(false);
                Cameras[1].gameObject.SetActive(true);
            }
            
        }
        
    }
}

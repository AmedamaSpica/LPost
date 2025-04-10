using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UIElements;


public class TokorotenPush : MonoBehaviour
{

    [SerializeField] private GameObject tokorotenPrefab;
    [SerializeField] private GameObject MainCamera;
    [SerializeField] private AudioClip Sound;
    [SerializeField] private Animator CameraTransition;
    [SerializeField] private GameObject BackButton;

    AudioSource AudioSource;
    int tokorotenPoint = GameManager.GMPoint;
    readonly ChatGPTManager GPT = new();

    // Start is called before the first frame update
    void Start()
    {

        BackButton.SetActive(false);
        CameraTransition = MainCamera.GetComponent<Animator>();
        //transform.localScale = new Vector3(6.065966f, GameManager.GMPoint * 0.1f, 5)  ;
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    private void OnTriggerStay(Collider other)
    {
        


        if (other.name == "tokoroten border" )
        {
           
            
            if (tokorotenPoint > 0)
            {

               
                //transform.localScale += new Vector3(0, 1, 0) * -0.1f;

                GameObject tokorotenBlock = Instantiate(tokorotenPrefab, transform.position + Vector3.down * 1 + new Vector3(-1,0,-1) * Random.Range(-3.0f, 3.0f), Quaternion.identity);
                tokorotenPoint--;

            }
            else 
            {
                Destroy(gameObject);
                BackButton.SetActive(true);
                CameraTransition.SetBool("AllPushed", true);

            }
            
        }
        
    }
}

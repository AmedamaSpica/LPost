using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    public bool AbleChange;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("DiaryBase");
        Destroy(obj);
        AbleChange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(AbleChange)
        {
            SceneManager.LoadScene("amedama Scene 1");
        }
    }
}

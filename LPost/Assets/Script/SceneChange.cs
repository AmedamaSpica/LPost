using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    [SerializeField]SceneAsset ChangeScene;//ˆÚ“®‚·‚éScene‚ðŒˆ’è



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneChange_func()
    {
        SceneManager.LoadScene(ChangeScene.name.ToString());
    }

}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    [SerializeField]SceneAsset ChangeScene;//ˆÚ“®‚·‚éScene‚ðŒˆ’è



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneChange_func()
    {
        SceneManager.LoadScene(ChangeScene.name.ToString());
    }

}
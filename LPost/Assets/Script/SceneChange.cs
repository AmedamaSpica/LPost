using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    [SerializeField] SceneAsset ChangeScene;//移動するSceneを決定



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
        PlayerPrefs.SetInt("LPower", LPPoint.LPower);

    }

    public void SceneChange_designation_func(SceneAsset scene)
    {
        SceneManager.LoadScene(scene.name.ToString());
        PlayerPrefs.SetInt("LPower", LPPoint.LPower);
    }
}

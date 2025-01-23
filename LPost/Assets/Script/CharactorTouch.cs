using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System.IO;

public class CharactorTouch : MonoBehaviour
{


    //[SerializeField] private GameObject clickedGameObject;
    [SerializeField] private Slider LPower_Slider;
    [SerializeField] private TextMeshProUGUI LPowerCount;
    [SerializeField] private AudioClip Sound;
    [SerializeField] int Slider_TimesOfCount = 20;

    GameEnd GameEnd = new GameEnd();
    float LPower_minus;
    float LPower_OneFlame_minus;
    int LPoint_MAX = 0;
    bool OneCall = true;
    AudioSource AudioSource;



    // Start is called before the first frame update
    void Start()
    {
        LPower_minus = LPPoint.LPower;
        LPower_OneFlame_minus = (float)LPPoint.LPower / Slider_TimesOfCount;
        AudioSource = GameObject.Find("GameManager").GetComponent<AudioSource>();
        LPower_Slider = GameObject.Find("PowerSlider").GetComponent<Slider>();
        LPowerCount = GameObject.Find("PowerText").GetComponent<TextMeshProUGUI>();
       
    }

    // Update is called once per frame

    void OnMouseDrag()
    {
        if (OneCall == true)
        {
            LPoint_MAX = LPPoint.LPower;
            OneCall = false;
            AudioSource.PlayOneShot(Sound);

        }

        if (LPower_Slider.value > 0)
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit))
            {
                //clickedGameObject = hit.collider.gameObject;
                LPower_Slider.value -= LPower_OneFlame_minus * Time.deltaTime * 500;

                

                LPowerCount.text = ((int)LPower_Slider.value).ToString();
                LPPoint.LPower = ((int)LPower_Slider.value);

            }

        }
    }

    private void OnMouseUp()
    {
        OneCall = true;
        GameEnd.LPointjson lPointjson = new GameEnd.LPointjson();

#if UNITY_EDITOR
        if (File.Exists(Application.persistentDataPath + "LPdata.json"))
        {

#elif UNITY_ANDROID
        if (File.Exists(Path.Combine(Application.persistentDataPath, "Directory_path/LPdata.json")))
        {

#endif

            StreamReader reader;

#if UNITY_EDITOR
            reader = new StreamReader(Application.persistentDataPath + "LPdata.json");

#elif UNITY_ANDROID
            reader = new StreamReader(Path.Combine(Application.persistentDataPath, "Directory_path/LPdata.json"), System.Text.Encoding.GetEncoding("utf-8"));
#endif

            string LPData = reader.ReadToEnd();

            reader.Close();

            lPointjson = JsonUtility.FromJson<GameEnd.LPointjson>(LPData);

            

            lPointjson.LP_week += LPoint_MAX - LPPoint.LPower;
            lPointjson.LP = LPPoint.LPower;
            string jsonLP = JsonUtility.ToJson(lPointjson);

            LPPoint.LPower_week = lPointjson.LP_week;

            StreamWriter writer = writerOpen();

            writer.Write(jsonLP);
            writer.Flush();
            writer.Close();

            Debug.Log(jsonLP);

        }
    }

    StreamWriter writerOpen()//開きたいものに合わせえてファイルパスをいじくってね
    {

#if UNITY_ANDROID

        if (Directory.Exists(Path.Combine(Application.persistentDataPath, "Directory_path")))
        {

        }
        else
        {
            Directory.CreateDirectory(Path.Combine(Application.persistentDataPath, "Directory_path"));
        }

#endif

        StreamWriter writer;

#if UNITY_EDITOR
        writer = new StreamWriter(Application.persistentDataPath + "LPdata.json", false);//LPost/Assets/savedata //trueで追加書き込み
#elif UNITY_ANDROID
        writer = new StreamWriter(Path.Combine(Application.persistentDataPath ,"Directory_path/LPdata.json") , false, System.Text.Encoding.GetEncoding("utf-8"));
#endif

        return writer;

    }
}


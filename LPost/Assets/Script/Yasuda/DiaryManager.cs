using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiaryManager : MonoBehaviour
{
    [Header("èëÇ¢ÇΩì˙ãL")]
    [SerializeField] private TextMeshProUGUI diaryText;

    public string DiaryText { get; set; }
    List<string> Diary = new List<string>();

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DiaryText = diaryText.text;
    }
}

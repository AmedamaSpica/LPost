using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class ImageFlash : MonoBehaviour
{
    [SerializeField] private GameObject image;
    [SerializeField] private UnityEvent CharacterChangeIvent;
    [SerializeField] private TextMeshProUGUI CharactorEvoText;

    private UnityEngine.Color color;
    private Image _image;

    // Start is called before the first frame update
    void Start()
    {
        _image = GetComponent<Image>();
        color = new Color(1.0f, 1.0f, 1.0f,0.01f);
        _image.color = Color.clear;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        _image.color += color;
        if (_image.color.a >= 1.0f)
        {
            _image.color = Color.clear;
            image.SetActive(false);
            CharactorSet.Character_No++;
            CharacterChangeIvent.Invoke();
            CharactorEvoText.text = "おめでとう！キャラクターは進化した！";
        }
    }
}

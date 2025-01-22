using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorSet : MonoBehaviour
{
    [SerializeField] GameObject[] Characters;
    GameObject NowCharacter;
    public static int Character_No = 0;
    // Start is called before the first frame update
    void Start()
    {

        CharacterSet_func();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CharacterSet_func()
    {
        Destroy(NowCharacter);
        NowCharacter = Instantiate(Characters[Character_No], Characters[Character_No].transform.position, Characters[Character_No].transform.rotation);
    }
}

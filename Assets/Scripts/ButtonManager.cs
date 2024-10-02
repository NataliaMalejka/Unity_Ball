using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    int level;

    void Start()
    {
        //zapamietywamnie postepu gracza. Druga wartosc to wartosc zwracana jezeli nie istnieje wartosc level
        if(level > PlayerPrefs.GetInt("level", 1))
        {
            //przycisk na szaro
            transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = Color.grey;
            //wylaczenie przycisku
            GetComponent<Button>().interactable = false;
        }
    }

}

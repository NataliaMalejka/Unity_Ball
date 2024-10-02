using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //do sceny

public class Respawn : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)  //wchodzenie w obiekt
    {
        SceneManager.LoadScene("Level1"); //przeladowuje scene
    }
}
//ostatecznie ten skrypt nie jest uzywany
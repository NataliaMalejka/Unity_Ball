using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//wymusza na obiekcie implementowanie danego komponentu
//[RequireComponent(typeof(AudioSource))] //dodaje komponent

public class AddTime : MonoBehaviour
{
    public float timeToAdd = 5f;
    public GameObject bonusParticle;
    GameManager gm;
    //mozemy tu przeciagnac nagranie z asetow
    //public AudioClip bonusaudio;
    //AudioSource audioSource;

    SoundsManager soundsManager;

    private void Start()
    {
        gm = GameObject.FindWithTag("GameController").GetComponent<GameManager>();

        //audioSource = GetComponent<AudioSource>();
        soundsManager = GameObject.FindWithTag("Soundsmanager").GetComponent<SoundsManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //audioSource.PlayOneShot(bonusaudio);
            soundsManager.playSounds(SoundsManager.Sounds.Bonus);
            gm.time += timeToAdd;
            //dodanie czasteczek
            Instantiate(bonusParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

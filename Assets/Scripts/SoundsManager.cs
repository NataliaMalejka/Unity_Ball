using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundsManager : MonoBehaviour
{
    public enum Sounds
    {
        Bonus, Win, Lose
    }

    public AudioClip bonusAudio;
    public AudioClip winAudio;
    public AudioClip loseAudio;

    AudioSource audioSource;

    private void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("Soundsmanager").Length > 1)
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //nie niszczy obiektu po wczytaniu nowej sceny
        DontDestroyOnLoad(this.gameObject);
    }

    public void playSounds(Sounds sounds)
    {
        switch(sounds)
        {
            case Sounds.Bonus:
                audioSource.PlayOneShot(bonusAudio);
                break;
            case Sounds.Win:
                audioSource.PlayOneShot(winAudio);
                break;
            case Sounds.Lose:
                audioSource.PlayOneShot(loseAudio);
                break;
            default:
                break;
        }
    }
}

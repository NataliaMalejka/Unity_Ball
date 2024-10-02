using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Ball Settings")]
    public GameObject ballPrefab;
    public Transform startPosition;

    [Header("Time Settings")]
    public TextMeshProUGUI timeText;
    public float time;
    //do spowalniania czasu
    public float slowTimeSeconds;
    public float slowTimeAmount;

    AudioSource audioSource;
    SoundsManager soundsManager;

    //wykonuje sie przed metoda start
    private void Awake()
    {
        //tworzenie obiektu
        Instantiate(ballPrefab, startPosition.position, Quaternion.identity); //domyslna rotacja
    }

    private void Start()
    {
        //wylaczenie myszki
        Cursor.visible = false;
        //po wczystaniu levelu resetujemy skale czasu
        Time.timeScale = 1f;
        audioSource = GetComponent<AudioSource>();

        soundsManager = GameObject.FindWithTag("Soundsmanager").GetComponent<SoundsManager>();
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        time -= Time.deltaTime;
        //zaokraglanie do liczb calkowitych i bez ujemnych
        timeText.text = "Time: " + Mathf.Clamp( Mathf.CeilToInt(time), 0, int.MaxValue).ToString(); 

        if(time <= 0)
        {
            restartlevel();
        }

        if(Time.timeScale >= 1f && time <=slowTimeSeconds)
        {
            Time.timeScale = slowTimeAmount; //im mniejsza skala czasu tym czas jest wolniejszy

            timeText.enableVertexGradient = false;
            timeText.color = new Color(1f, 0.2f, 0, 2f);

            audioSource.Play();
        }
        else if(Time.timeScale < 1f && time > slowTimeSeconds)
        {
            Time.timeScale = 1f; //normalna predkosc
            timeText.enableVertexGradient = true;
            timeText.color = new Color(1f, 1f, 1f); //zeby gradient mial wlasciwe kolory

            audioSource.Stop();
        }

        //Debug.Log($"deltaTime = {Time.deltaTime}"); //zawsze normalna sekunda
        //Debug.Log($"unscaled deltaTime = {Time.unscaledDeltaTime}"); //ta wartosc jest mozona razy skale czasu czyli 0.5
    }

    public void restartlevel()
    {
        soundsManager.playSounds(SoundsManager.Sounds.Lose);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        soundsManager.playSounds(SoundsManager.Sounds.Win);

        int activeScene = SceneManager.GetActiveScene().buildIndex;

        if(PlayerPrefs.GetInt("level", 1) < activeScene +1)
        {
            //odblokowywanie poziomu
            PlayerPrefs.SetInt("level", activeScene + 1);
        }

        if (SceneManager.sceneCountInBuildSettings > activeScene + 1)
        {
            //wczytanie sceny
            SceneManager.LoadScene(activeScene + 1);
        }
        else
            SceneManager.LoadScene(0);

    }
}

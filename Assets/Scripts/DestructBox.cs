using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructBox : MonoBehaviour
{
    public Color startColor;
    public Color endColor;
    public int life;
    public bool isRigidbody = false;

    private Material material;
    private int maxLife = 3;
    Rigidbody rb;

    //public AudioClip hitAudio;
    //AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {

        //audioSource = GetComponent<AudioSource>();

        //zmienna, min, max
        life = Mathf.Clamp(life, 1, maxLife);
        //przypisanie materialu do zmiennej
        material = GetComponent<MeshRenderer>().material;

        setColor();

        if (isRigidbody)
        {
            //gameObject.AddComponent<Rigidbody>();
            rb = gameObject.AddComponent<Rigidbody>();
            //zeby mozna nylo modyfikowac wlasciwosci
            rb.interpolation = RigidbodyInterpolation.Interpolate;
            rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
            rb.mass = 0.75f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //audioSource.PlayOneShot(hitAudio); //nie odtwarza dzwieku na ostatnim zyciu boxa
            //AudioSource.PlayClipAtPoint(hitAudio, transform.position); //odtwarza wybrany dzwiek na wybranej pozycji
            //AudioSource.PlayClipAtPoint(hitAudio, collision.contacts[0].point); //odtwarza dzwiek dokladnie w mijscu kolizji
            life--;

            if (life > 0) 
            {
                setColor();
            }
            else
            {
                //samo this usuwa skrypt
                Destroy(this.gameObject);
            }
        }
    }
    void setColor()
    {
        //liniowe interpolowanie
        material.color = Color.Lerp(endColor, startColor, (float)(life - 1) / (float)(maxLife - 1)); //odejmowanie zeby byl dobry kolor 
    }
    //uruchamioana przed uruchomieniem rozgrywki regauje na zmiany w inspektorze
    //wykonuje sie tylko wtedy jezli gre testujemy w edytorze
    private void OnValidate()
    {
        //pojawia sie blad poniewaz material jest przypisany dopiero w start()
        //nie mozna wyciac materialu z start
        material = GetComponent<MeshRenderer>().sharedMaterial; //shareMaterial referencja do orginalu
        //poprawia blad tak ze nie pojawiaja sie te same kolory w podgladzie. Wylacza wspoldzielenie referencyjne materialu
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        material = renderer.sharedMaterial;

        setColor();
    }
}

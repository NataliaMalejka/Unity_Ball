using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBox : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    public bool reverse = false;
    Vector3 force;

    void Start()
    {
        force = Vector3.left * speed;

        if (reverse)
        {
            ReverseVector();
        }
    }

    private void FixedUpdate()
    {
        //rzuca promien widoczny po uruchomieniu gry i wybraniu zakladki scena
        //pozycja startowa, kierunek, kolor, czas trwania, inne obiekty nie przyslaniaja promienia
        Debug.DrawRay(transform.position, direction, Color.red, 0.1f, false);
        //tworzenie promienia
        Ray ray = new Ray(transform.position, direction);
        RaycastHit hit;
        //sprawdzanie czy w cos uderza
        if(Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.transform.gameObject.name);

            if(hit.transform.gameObject.CompareTag("Floor") || hit.transform.gameObject.CompareTag("Player"))
            {
                Move();
                //transform.GetComponent<Rigidbody>().AddForce(force);
            }
            else
            {
                //transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
                ReverseVector();
                Move();
            }
        }
        else
        {
            //transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
            ReverseVector();
            Move();
        }
    }

    void Move()
    {
        transform.GetComponent<Rigidbody>().velocity = force;
    }

    void ReverseVector()
    {
        force = -force;
        direction.Set(-direction.x, direction.y, direction.z);
    }
}

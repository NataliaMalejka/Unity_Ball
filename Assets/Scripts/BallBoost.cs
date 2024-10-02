using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallBoost : MonoBehaviour
{
    [SerializeField]
    float boostForce = 1f;

    GameObject boostText;
    Rigidbody rb;

    bool boostActivated = false;
    bool boostReady = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        boostText = GameObject.Find("BoostText").gameObject;
        TextVisible();
    }

    void Update()
    {
        Debug.Log(rb.velocity.normalized); //vektor znormalizowany 0- nie porusza sie, 1-porusza sie. predkosc nie jest istotna
        TextVisible();

        if(Input.GetKeyDown(KeyCode.Space) && boostReady && rb.velocity != Vector3.zero)
        {
            boostActivated = true;
            boostReady = false;
        }
    }

    private void FixedUpdate()
    {
        if(boostActivated)
        {
            rb.AddForce(rb.velocity.normalized * boostForce, ForceMode.Impulse);
            boostActivated = false;
            //wywolanie korutyny
            StartCoroutine("BoostCoroutine");
        }
    }
    //korutyna - troche jak osobny watek
    IEnumerator BoostCoroutine()
    {
        yield return new WaitForSeconds(3f);
        boostReady = true;
        //przerwanie korutyny
        yield break;
    }

    private void TextVisible()
    {
        if(boostReady)
        {
            boostText.SetActive(true);
        }
        else
        {
            boostText.SetActive(false);
        }
    }
}

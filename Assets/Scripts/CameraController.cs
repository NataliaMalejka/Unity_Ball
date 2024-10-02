using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //public Transform ballTransform;
    public Vector3 distance;
    public float lookUp;
    public float lerpAmount; //wartosc posrednia miedzy tp i btp + d od 0 do 1

    private GameObject ballObject;

    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 60;

        //szukanie obiektu
        ballObject = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //przeniesione z powodu drzenia kamery

        ////lerp wygladzanie dwoch pozycji, wyznaczanie wartosci posrednich
        //// sprawia ze kamera czeka az pilka ruszy
        //transform.position = Vector3.Lerp(transform.position, ballObject.transform.position + distance, lerpAmount); 
        ////transform.position = ballTransform.position;
        ////transform.position = ballObject.transform.position + distance;
        //transform.LookAt(ballObject.transform.position);
        //transform.Rotate(-lookUp, 0, 0);
    }

    private void FixedUpdate()
    {
        //transform.position = Vector3.Lerp(transform.position, ballObject.transform.position + distance, lerpAmount);
        //transform.LookAt(ballObject.transform.position);
        //transform.Rotate(-lookUp, 0, 0);
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, ballObject.transform.position + distance, lerpAmount * Time.deltaTime);
        transform.LookAt(ballObject.transform.position);
        transform.Rotate(-lookUp, 0, 0);
    }
}

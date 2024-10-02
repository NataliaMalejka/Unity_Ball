using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    //[HideInInspector]//ukrywa speed w unity component. Tak samo dziala private zmienna
    [Header("Control Settings")] //naglowek

    [SerializeField] //pokazuje zmienne prywatne w unity copmonent.
    private float speed = 1f;

    private Rigidbody rb;
    private bool isRigidbody;

    private GameManager gameManager;

    public float maxAngularVelocity;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(transform.position);
        //Debug.Log(transform.rotation.eulerAngles);
        //Debug.Log(transform.localScale);

        //rb = GetComponent<Rigidbody>();

        if(isRigidbody = TryGetComponent<Rigidbody>(out rb)) // out - referencja
        {
            rb.maxAngularVelocity = maxAngularVelocity;
            //Debug.Log(rb.maxAngularVelocity);
        }

        //szukanie gamemanager
        //gameManager = GameObject.FindObjectOfType<GameManager>(); 
        //gameManager = GameObject.FindGameObjectsWithTag("GameController").GetComponent<GameManager>(); //nie dziala
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>(); //lepsze od pierwszej wersj
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= -10f)
        {
            //restart
            gameManager.restartlevel();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //wczytuje obecnie otwarta scene
        }

        //float Hdirection;
        //float Vdirection;

        ////Debug.Log(Input.GetAxis("Horizontal"));

        //if (isRigidbody && (Hdirection = Input.GetAxis("Horizontal")) != 0)
        //{
        //    //transform.Translate(direction * Time.deltaTime * speed, 0, 0, Space.World);
        //    //rb.AddForce(direction * Time.deltaTime * speed, 0, 0); //mozna dodac ForceMode
        //    rb.AddTorque(0, 0, -Hdirection * Time.deltaTime * speed); //ruch obrotowy.  Minus zeby poruszalo sie we elasciwa strone
        //}
        //if (isRigidbody && (Vdirection = Input.GetAxis("Vertical")) != 0)
        //{
        //    rb.AddTorque(Vdirection * Time.deltaTime * speed, 0, 0);
        //}

        //if(Input.GetKey(KeyCode.LeftArrow))
        //{
        //   // transform.position += new Vector3(-1f * Time.deltaTime * speed, 0, 0);
        //    transform.Translate(-1f * Time.deltaTime * speed, 0, 0, Space.World);
        //    //Space.World powoduje ze ball porusza sie po osi x nie zaleznie od rotacji
        //}
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    transform.Translate(1f * Time.deltaTime * speed, 0, 0, Space.World);
        //}
    }

    private void FixedUpdate()
    {
        float Hdirection;
        float Vdirection;

        if (isRigidbody && (Hdirection = Input.GetAxis("Horizontal")) != 0)
        {
            rb.AddTorque(0, 0, -Hdirection * speed * Time.fixedDeltaTime); //time opcjonalne 
        }
        if (isRigidbody && (Vdirection = Input.GetAxis("Vertical")) != 0)
        {
            rb.AddTorque(Vdirection * speed * Time.fixedDeltaTime, 0, 0);
        }
    }
}

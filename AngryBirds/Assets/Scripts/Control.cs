using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Control : MonoBehaviour
{
    private Camera camara;
    private Rigidbody2D jugadorRig;
    private SpringJoint2D jugadorSpring;

    public GameObject jugador;
    public Rigidbody2D pivote;
    public float tiempoQuitarSpring;
    public float tiempoFinJuego;

    private bool estaArrastrando;
    public LineRenderer goma;
    
    void Start()
    {
        camara = Camera.main;
        jugadorRig = jugador.GetComponent<Rigidbody2D>();
        jugadorSpring = jugador.GetComponent<SpringJoint2D>();
        


        jugadorSpring.connectedBody = pivote;
    }

   
    void Update()
    {
        if (jugadorRig == null)
        {
            return;
        }

        if(!Touchscreen.current.primaryTouch.press.isPressed)
        {
            if (estaArrastrando)
            {
                LanzarPájaro();
            }

            estaArrastrando = false;
            return;
        }

        estaArrastrando = true;

        jugadorRig.isKinematic = true;
        Vector2 posicionTocar = Touchscreen.current.primaryTouch.position.ReadValue();
        Vector2 posicionMundo = camara.ScreenToWorldPoint(posicionTocar);
        jugador.transform.position = posicionMundo;
        goma.SetPosition(1, posicionMundo);

    }
    void LanzarPájaro()
    {
        jugadorRig.isKinematic = false;
        jugadorRig = null; //hatirado = true

        Invoke(nameof(QuitarSpring), tiempoQuitarSpring);
        Destroy(goma, 0.5f);
    }
    void QuitarSpring()
    {
        jugadorSpring.enabled = false;
        jugadorSpring = null;

        Invoke(nameof(FinJuego), tiempoFinJuego);
    }
    void FinJuego()
    {
        //Debug.Log("FinJuego");
    }
}

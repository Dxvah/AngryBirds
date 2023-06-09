using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalMapa : MonoBehaviour
{
    public Rigidbody2D rbFinal;
    [SerializeField] private Puntuacion puntaje;
    [SerializeField] private float cantidadPuntos;
    void Start()
    {
        rbFinal.GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemigo"))
        {
            puntaje.SumarPuntos(cantidadPuntos);
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.CompareTag("Madera"))
        {
            puntaje.SumarPuntos(cantidadPuntos);
            Destroy(collision.gameObject);
        }
    }
}

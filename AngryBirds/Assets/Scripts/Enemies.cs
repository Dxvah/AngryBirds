using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] private float cantidadPuntos;
    [SerializeField] private Puntuacion puntaje;
    public Rigidbody2D rbEnemy;
    public int dañoCaida = 5;
    public int vida = 1;
    public float mass = 1f;
    void Start()
    {
        rbEnemy.GetComponent<Rigidbody2D>();
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.CompareTag("Player"))
        {
            puntaje.SumarPuntos(cantidadPuntos);
            vida--;
            
        }
        if (col.gameObject.CompareTag("Ground"))
        {
            float velocidadCaida = Mathf.Abs(col.relativeVelocity.y * rbEnemy.mass);
            if (velocidadCaida > 3f)
            {
                puntaje.SumarPuntos(cantidadPuntos);
                Destroy(this.gameObject);
               
            }
        }
        if(vida == 0)
        {
            Destroy(this.gameObject);
        }
        if(col.gameObject.CompareTag("Madera"))
        {
            float velocidadColision = Mathf.Abs(col.relativeVelocity.y * rbEnemy.mass);
            {
                if(velocidadColision > 2f)
                {
                    puntaje.SumarPuntos(cantidadPuntos);
                    vida--;
                }
            }
        }
    }
}

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
    private AudioSource audioSource;
    [SerializeField] private AudioClip aaah;
    [SerializeField] private AudioClip pam;
    void Start()
    {
        rbEnemy.GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        aaah = Resources.Load<AudioClip>("Sounds/aaah");
        pam = Resources.Load<AudioClip>("Sounds/pam");
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.CompareTag("Player"))
        {
            puntaje.SumarPuntos(cantidadPuntos);
            vida--;    
            if (audioSource.enabled)
            {          
               audioSource.Play();
            }
        }
        if (col.gameObject.CompareTag("Ground"))
        {
            float velocidadCaida = Mathf.Abs(col.relativeVelocity.y * rbEnemy.mass);
            if (velocidadCaida > 3f)
            {
                 if (audioSource.enabled)
                 {       
                        audioSource.Play();
                 }

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
                    if (audioSource.enabled)
                    {       
                         audioSource.Play();
                    }
                    
                }
            }
        }
    }
}

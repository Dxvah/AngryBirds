using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 startPos;
    public float explosionRadio = 5f;
    public float explosionFuerza = 25f;
    private bool bombaColocada = false;
    private AudioSource audioSource;
    [SerializeField] private AudioClip boom;


    void Start()
    {    
        startPos = transform.position;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = boom;
        
        
    }
    private void OnMouseDown()
    {
      if (bombaColocada)
      {
        Explotar();
      }
      else
      {
        bombaColocada = true;
      }
    }
    private void Explotar()
    {
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadio);

        foreach (Collider2D collider in colliders)
        {
            
            Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 direction = collider.transform.position - transform.position;
                rb.AddForce(direction.normalized * explosionFuerza, ForceMode2D.Impulse);
            }
            if (audioSource.enabled)
            {
                audioSource.Play(); 
            }
             Invoke("DestruirObjeto", 0.5f);
             bombaColocada = false;
           
        }
    }

    private void DestruirObjeto()
    {
        Destroy(this.gameObject);
    }

    void OnDrawGizmosSelected()
    {
        
        if (bombaColocada)
        {
            
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, explosionRadio);
        }
    }
}

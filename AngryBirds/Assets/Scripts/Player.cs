using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 startPos;
   // public Collider2D col;
     void Start()
     {

        rb.GetComponent<Rigidbody2D>();
        startPos = transform.position;
        //col.GetComponent<Collision2D>();
        //Collider2D[] listaPuntosChoque = Physics2D.OverlapCircleAll(startPos, 15);
        //Debug.Log(listaPuntosChoque.Length);     
     }
    private void Update()
    {
        Collider2D[] listaPuntosChoque = Physics2D.OverlapCircleAll(startPos, 15);

        if (!Touchscreen.current.primaryTouch.press.isPressed)
        {
            Debug.Log("ha Tocado");
            //for (int i = 0; i < listaPuntosChoque.Length; i++)
            //{
                //Collider2D objetoChocado = listaPuntosChoque[i];
                //Rigidbody2D rbObjetoChocado = objetoChocado.gameObject.GetComponent<Rigidbody2D>();
                //rbObjetoChocado.AddForce(new Vector3(1, 1, 0), ForceMode2D.Force);
            //}
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {

        //Debug.Log(col.relativeVelocity + " " +col.gameObject.tag + " " + col.relativeVelocity.magnitude);
        
    }


    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        
        Gizmos.DrawSphere(transform.position, 1);
    }
}

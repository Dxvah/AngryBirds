using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    }
    void OnCollisionEnter2D(Collision2D col)
    {      
        
        //Debug.Log(col.relativeVelocity + " " +col.gameObject.tag + " " + col.relativeVelocity.magnitude);
    }
    

 
}

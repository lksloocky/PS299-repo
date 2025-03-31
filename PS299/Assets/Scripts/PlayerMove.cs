using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerMove : MonoBehaviour
{

    public float speed = 5;

    public Rigidbody2D rb2d;


    private void start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

private void FixedUpdate() 
{
   MovePlayer();
}
   void MovePlayer()
   {
    float horizontalMove = Input.GetAxisRaw("Horizontal");
    float verticalMove = Input.GetAxisRaw("Vertical");

    rb2d.linearVelocity = new Vector2(horizontalMove * speed, verticalMove * speed);
   
   }
}

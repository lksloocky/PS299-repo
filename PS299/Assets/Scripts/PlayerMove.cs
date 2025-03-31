using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public class PlayerMove : MonoBehaviour
{

    public float speed = 5;

    public Rigidbody2D rb2d;
    public TrailRenderer _trailRenderer;

//variaveis do Dash
[SerializeField] private float _dashingVelocity = 14f;
[SerializeField] private float _dashingTime = 0.5f;
private Vector2 _dashingDir;
private bool _isDashing;
private bool _canDash = true;


    private void start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        _trailRenderer = GetComponent<TrailRenderer>();
    }

private void Update() 
{

 MovePlayer();

     //Dash
   var dashInput = Input.GetButtonDown("Dash");

    if(dashInput && _canDash)
    {
        _isDashing = true;
        _canDash = false;
        _trailRenderer.emitting = true;
        _dashingDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if(_dashingDir == Vector2.zero)
        {
            _dashingDir = new Vector2(transform.localScale.x, 0);
        }
        //para o dash
        StartCoroutine(StopDash());

    }
    if(_isDashing)
    {
        rb2d.linearVelocity = _dashingDir.normalized * _dashingVelocity;
    }

}


   void MovePlayer()
   {
    float horizontalMove = Input.GetAxisRaw("Horizontal");
    float verticalMove = Input.GetAxisRaw("Vertical");

    rb2d.linearVelocity = new Vector2(horizontalMove * speed, verticalMove * speed); 
   }

   private IEnumerator StopDash()
   {
    yield return new WaitForSeconds(_dashingTime);
    _trailRenderer.emitting = false;
    _isDashing = false;
    _canDash = true;
   }
}

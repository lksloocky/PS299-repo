using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public class PlayerMove : MonoBehaviour
{
    public string _state = "";

    public float speed = 5;

    public Rigidbody2D rb2d;
    public TrailRenderer _trailRenderer;

//variaveis do Dash
[SerializeField] private float _dashingVelocity = 14f;
[SerializeField] private float _dashingTime = 0.5f;
private Vector2 _dashingDir;
private bool _canDash = true;


    private void start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        _state = Globais.P_IDLE;
        _trailRenderer = GetComponent<TrailRenderer>();
    }

private void Update() 
{

 MovePlayer();
 PlayerDash();
 print(_state);

}


    void PlayerDash()
    {
     //Dash
   var dashInput = Input.GetButtonDown("Dash");

    if(_state == "IDLE" || _state == "WALKING")
    {
        _canDash = true;
    }

    if(dashInput && _canDash)
    {
        _state = Globais.P_DASHING;
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
    if(_state == "DASHING")
    {
        rb2d.linearVelocity = _dashingDir.normalized * _dashingVelocity;
    }
    }


private IEnumerator StopDash()
   {
    yield return new WaitForSeconds(_dashingTime);
    _trailRenderer.emitting = false;
    _state = Globais.P_IDLE;
   }


   void MovePlayer()
   {
    float horizontalMove = Input.GetAxisRaw("Horizontal");
    float verticalMove = Input.GetAxisRaw("Vertical");

    rb2d.linearVelocity = new Vector2(horizontalMove * speed, verticalMove * speed); 

    if(_state != "DASHING" && rb2d.linearVelocity != Vector2.zero) 
    {
        _state = Globais.P_WALKING;
    }
    
   if(rb2d.linearVelocity == Vector2.zero) 
    {
        _state = Globais.P_IDLE;
    }
   }

   
}

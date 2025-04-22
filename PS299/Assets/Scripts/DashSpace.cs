using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSpace : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _collider;
    [SerializeField] private BoxCollider2D _detection;

    void Start() 
    {
        _collider = GetComponent<BoxCollider2D>();
        _detection = GetComponent<BoxCollider2D>();    
    }
    
    void OnTriggerEnter2D(Collider2D _collision) 
    {
        if(_collision.CompareTag("Player")) 
        {
            //acessa o script PlayerMove
            PlayerMove _playerMove = _collision.GetComponent<PlayerMove>();

            if(_playerMove != null && _playerMove._state == "DASHING")
            {
                _collider.isTrigger = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D _collision)
    {
        if(_collision.CompareTag("Player"))
        {
            if(_collider != null)
            {
                _collider.isTrigger = false;
            }
        }
    }
}

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Patrulha : MonoBehaviour
{
    //patrol
    [SerializeField] private Transform[] _waypoints;
    public float speed;
    public float _waitTime = 1f;
    private int _currentWaypointIndex = 0;
    private bool _isWaiting;

    //chase
    private bool _isChasing;
    public float chaseSpeed = 5f;
    [SerializeField] private Transform _player;
    [SerializeField] private CircleCollider2D _range;

 void Start() 
 {
    _player = GameObject.FindWithTag("Player")?.transform;
    _range = GetComponent<CircleCollider2D>();
 }
    
    void Update()
    {
        if(_isChasing) ChasePlayer();

        else Patrol();
    }

    void Patrol() 
    {
        if(_isWaiting) return;

        Transform _targetWaypoint = _waypoints[_currentWaypointIndex];

         //move para o waypoint atual
        transform.position = Vector2.MoveTowards(transform.position, _targetWaypoint.position, speed * Time.deltaTime);

        //verifica se chegou no waypoint
        if(Vector2.Distance(transform.position, _targetWaypoint.position) < 0.1f) StartCoroutine(WaitAtWaypoint());
    }

    private IEnumerator WaitAtWaypoint() 
    {
        _isWaiting = true;
        yield return new WaitForSeconds(_waitTime);
        _isWaiting = false;

        _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
    }

    void ChasePlayer() 
    {
        if(_player == null) return;

        transform.position = Vector2.MoveTowards(transform.position, _player.position, chaseSpeed * Time.deltaTime);

        //lógica de ataque
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player")) _isChasing = true;
    }


     void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Player")) _isChasing = false;
    }


}

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Patrulha : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    public float speed;
    public float _waitTime = 1f;

    private int _currentWaypointIndex = 0;
    private bool _isWaiting;
 
    
    void Update()
    {
        Patrol();
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
}

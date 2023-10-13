using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawPathFinder : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private Transform pathPrefab;
    [SerializeField] private float rotationSpeed;
    private List<Transform> _waypoints;
    private int _waypointIndex;

    private void Start()
    {
        GetWaypoints();
        transform.position = _waypoints[0].position;
    }

    private void GetWaypoints()
    {
        _waypoints = new List<Transform>();
        foreach (Transform child  in pathPrefab)
            _waypoints.Add(child);
        Debug.Log("Waypoints length :" + _waypoints.Count);
    }

    private void Update()
    {
        FollowPath();
    }

    private void FollowPath()
    {
        
        if (_waypointIndex < _waypoints.Count)
        {
            
            var target = _waypoints[_waypointIndex].position;

            if (target == transform.position)
            {
                _waypointIndex++;
                return;
            }
            var speed = movementSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target, speed);
            if (gameObject.CompareTag(TagsAndLayers.EnemyTag))
                transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
        else 
            _waypointIndex = 0;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinPathFinder : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private Transform pathPrefab;
    [SerializeField] private float waitTime;
    private List<Transform> _waypoints;
    private int _waypointIndex;
    private Animator _animator;
    private bool _isWalking;
    public bool enable;

    private void Start()
    {
        GetWaypoints();
        transform.position = _waypoints[0].position;
        _animator = GetComponent<Animator>();
        _isWalking = true;
        enable = true;
    }

    private void GetWaypoints()
    {
        _waypoints = new List<Transform>();
        foreach (Transform child  in pathPrefab)
            _waypoints.Add(child);
    }

    private void Update()
    {
        if (_isWalking && enable)
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
                StartCoroutine(Wait());
                transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
                return;
            }
            var speed = movementSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target, speed);
        }
        else 
            _waypointIndex = 0;
    }

    private IEnumerator Wait()
    {
        _isWalking = false;
        _animator.SetBool("isWalking", false);
        yield return new WaitForSeconds(waitTime);
        _isWalking = true;
        _animator.SetBool("isWalking", true);
    }

    public void Disable()
    {
        _animator.SetBool("isWalking", false);
        enable = false;
    }

    public void Enable()
    {
        _animator.SetBool("isWalking", _isWalking);
        enable = true;
    }
    
    
}

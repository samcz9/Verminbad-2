using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using BehaviorTree;

public class Patrol : Node
{
    private Transform _transform;
    private Transform[] _waypoints;
    private UnityEngine.AI.NavMeshAgent _navAgent;
    private Animator _animator;

     private int _currentWaypointIndex = 0;

    private float _waitTime = 1f; // in seconds
    private float _waitCounter = 0f;
    private bool _waiting = false;


    public Patrol(Transform transform, Transform[] waypoints)
    {
        _transform = transform;
        _waypoints = waypoints;
        _animator = transform.GetComponent<Animator>();
        _navAgent = transform.GetComponent<UnityEngine.AI.NavMeshAgent>();
        _animator.SetInteger("animation", 1);
    }

    public override NodeState Evaluate()
    {
        if (_waiting)
        {
            _waitCounter += Time.deltaTime;
            if (_waitCounter >= _waitTime)
            {
                _waiting = false;
                Debug.Log("starting walk animation");
                _animator.SetInteger("animation", 1);
            }
        }
        else
        {
            Transform wp = _waypoints[_currentWaypointIndex];
            if (Vector3.Distance(_transform.position, wp.position) < 1f)
            {
                _waitCounter = 0f;
                _waiting = true;
                _animator.SetInteger("animation", 0);
                _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
            }
            else
            {
                _navAgent.SetDestination(wp.position);
            }
        }
    
        state = NodeState.RUNNING;
        return state;
    }

}

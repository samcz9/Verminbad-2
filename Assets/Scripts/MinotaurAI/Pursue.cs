using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class Pursue : Node
{
    private Transform _transform;
    private UnityEngine.AI.NavMeshAgent _navAgent;
    private Animator _animator;

    public Pursue(Transform transform)
    {
        _transform = transform;
        _navAgent = transform.GetComponent<UnityEngine.AI.NavMeshAgent>();
        _animator = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");

        if (Vector3.Distance(_transform.position, target.position) > .5f)
        {
            _navAgent.destination = target.position;
            _navAgent.speed = MinotaurBehaviour.sprintSpeed;
            _animator.SetInteger("animation", 2);
            _transform.LookAt(target.position);
        }

        state = NodeState.RUNNING;
        return state;
    }

}
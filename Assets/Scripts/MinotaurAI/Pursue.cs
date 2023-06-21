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

        if (Vector3.Distance(_transform.position, target.position) > 3f)
        {
            Quaternion lookOnLook = Quaternion.LookRotation(target.position - _transform.position);
            _transform.rotation = Quaternion.Slerp(_transform.rotation, lookOnLook, Time.deltaTime);

            _navAgent.SetDestination(target.position);
            _navAgent.speed = MinotaurBehaviour.sprintSpeed;
            _animator.SetInteger("animation", 2);
        }

        state = NodeState.RUNNING;
        return state;
    }

}
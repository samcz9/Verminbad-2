using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;


public class BasicAttack : Node
{
    private Transform _lastTarget;
    private PlayerManager _playerManager;
    private UnityEngine.AI.NavMeshAgent _navAgent;
    private Animator _animator;
    private float _attackTime = 2f;
    private float _attackCounter = 0f;


    public BasicAttack(Transform transform)
    {
        _navAgent = transform.GetComponent<UnityEngine.AI.NavMeshAgent>();
        _animator = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");
        if (target != _lastTarget)
        {
            _playerManager = target.GetComponent<PlayerManager>();
            _lastTarget = target;
        }

        _attackCounter += Time.deltaTime;
        if (_attackCounter >= _attackTime)
        { 
            _animator.SetBool("attack1", true);
            _navAgent.isStopped = true;
            _attackCounter = 0f;
        }

        state = NodeState.RUNNING;
        return state;
    }

}
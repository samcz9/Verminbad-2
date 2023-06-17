using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class ScanForTargets : Node
{
    private Transform _transform;
    private Animator _animator;
    private LayerMask _playerCharacterMask;

    public ScanForTargets(Transform transform)
    {
        _transform = transform;
        _animator = transform.GetComponent<Animator>();
        _playerCharacterMask = LayerMask.GetMask("Character");
    }

    public override NodeState Evaluate()
    {
        object t = GetData("target");
        if (t == null)
        {
            Collider[] colliders = Physics.OverlapSphere(
                _transform.position, MinotaurBehaviour.fovRange, _playerCharacterMask);

            if (colliders.Length > 0)
            {
                parent.parent.SetData("target", colliders[0].transform);
                _animator.SetInteger("animation", 2);
                state = NodeState.SUCCESS;
                return state;
            }

            state = NodeState.FAILURE;
            return state;
        }

        state = NodeState.SUCCESS;
        return state;
    }

}
using System.Collections.Generic;
using BehaviorTree;

public class MinotaurBehaviour : Tree
{
    public UnityEngine.Transform[] waypoints;
    public static float speed = 2f;
    public static float sprintSpeed = 6f;
    public static float fovRange = 6f;

    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new ScanForTargets(transform),
                new Pursue(transform),
            }),
            new Patrol(transform, waypoints),
        });
        return root;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private EnemyUnit enemy;
    private Transform childTransform;
    private Transform playerTransform;
    private UnityEngine.AI.NavMeshAgent agent;
    private Animator animator;

    private void Awake()
    {
        enemy = GetComponent<EnemyUnit>();
        animator = GetComponent<Animator>();
        childTransform = transform.GetChild(0);
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        // Get the Animator component
        //  animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Calculate direction and distance to player
        Vector3 directionToPlayer = playerTransform.position - childTransform.position;
        float distanceToPlayer = directionToPlayer.magnitude;

        Debug.Log(distanceToPlayer);
        Debug.Log(enemy.attackRange);

        agent.destination = playerTransform.position;

        animator.SetInteger("animation", 1);
        // Normalize direction and move enemy towards player
        /*{ if (distanceToPlayer > enemy.attackRange)
        {
            Vector3 direction = directionToPlayer.normalized;
            childTransform.Translate(direction * enemy.moveSpeed * Time.deltaTime);

            // Set the "isAttacking" parameter to false
            // animator.SetBool("isAttacking", false);
        }
        */
    }
}

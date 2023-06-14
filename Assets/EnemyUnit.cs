using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : MonoBehaviour
{
    public int health;
    public int attackPower;
    public float moveSpeed;
    public float attackRange;

    // Animations
    public Animator animator;

    // Prefabs
    public GameObject prefab;
}

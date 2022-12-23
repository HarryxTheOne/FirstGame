using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackRange = 1f;
    public int attackDamage = 1;
    public float attackRate = 1f;

    private float nextAttackTime;
    private GameObject player;
    private PlayerHealth playerHealth;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer < attackRange && Time.time > nextAttackTime)
        {
            Attack();
        }
    }

    void Attack()
    {
        nextAttackTime = Time.time + attackRate;
        playerHealth.TakeDamage(attackDamage);
    }
}

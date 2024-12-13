//Kanaan Gute 12/04/24
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    private float moveTimer;
    private float losePlayerTimer;
    private float attackCooldownTimer;

    public override void Enter()
    {
        Debug.Log("Entered Attack State");
    }

    public override void Exit()
    {
        Debug.Log("Exited Attack State");
    }

    public override void Perform()
    {
        if (enemy.CanSeePlayer())
        {
            losePlayerTimer = 0;
            moveTimer += Time.deltaTime;

            // Look at the player
            enemy.transform.LookAt(enemy.Player.transform);

            // Check if in attack range
            float distanceToPlayer = Vector3.Distance(enemy.transform.position, enemy.Player.transform.position);
            if (distanceToPlayer <= enemy.attackRange)
            {
                // Perform attack if cooldown is over
                if (attackCooldownTimer <= 0)
                {
                    // Trigger attack animation
                    enemy.Attack(); // Trigger attack animation
                    attackCooldownTimer = enemy.attackCooldown; // Reset cooldown timer

                    // Apply damage to the player
                    PlayerHealth playerHealth = enemy.Player.GetComponent<PlayerHealth>();
                    if (playerHealth != null)
                    {
                        playerHealth.TakeDamage(10f); // Deal 10 damage to the player
                    }
                }
            }
            else
            {
                // Move closer to the player
                if (moveTimer > Random.Range(3, 7))
                {
                    enemy.Agent.SetDestination(enemy.Player.transform.position); // Move toward the player
                    moveTimer = 0;
                }
            }
        }
        else
        {
            losePlayerTimer += Time.deltaTime;
            if (losePlayerTimer > 8)
            {
                stateMachine.ChangeState(new PatrolState());
            }
        }

        // Reduce cooldown timer
        if (attackCooldownTimer > 0)
        {
            attackCooldownTimer -= Time.deltaTime;
        }
    }
}

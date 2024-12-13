//Kanaan Gute 12/07/24
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private StateMachine stateMachine;
    private NavMeshAgent agent;
    private GameObject player;
    private Animator animator; // Add reference to Animator

    public NavMeshAgent Agent { get => agent; }
    public GameObject Player { get => player; }
    public Path path;

    [Header("Sight Values")]
    public float sightDistance = 20f;
    public float fieldOfView = 85f;
    public float eyeHeight;

    [Header("Attack Values")]
    public float attackRange = 2f; // Distance to perform a melee attack
    public float attackCooldown = 1f; // Time between attacks

    [Header("Health Values")]
    public float maxHealth = 100f;
    private float currentHealth;
    private bool isDead = false; // To check if the enemy is dead

    [SerializeField]
    private string currentState;

    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>(); // Get the Animator component
        stateMachine.Initialise();
        player = GameObject.FindGameObjectWithTag("Player");
        currentHealth = maxHealth; // Set initial health
    }

    void Update()
    {
        CanSeePlayer();
        currentState = stateMachine.activeState.ToString();
        
    }

    public bool CanSeePlayer()
    {
        if (player != null)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < sightDistance)
            {
                Vector3 targetDirection = player.transform.position - transform.position - (Vector3.up * eyeHeight);
                float angleToPlayer = Vector3.Angle(targetDirection, transform.forward);
                if (angleToPlayer >= -fieldOfView && angleToPlayer <= fieldOfView)
                {
                    Ray ray = new Ray(transform.position + (Vector3.up * eyeHeight), targetDirection);
                    RaycastHit hitInfo = new RaycastHit();
                    if (Physics.Raycast(ray, out hitInfo, sightDistance))
                    {
                        if (hitInfo.transform.gameObject == player)
                        {
                            Debug.DrawRay(ray.origin, ray.direction * sightDistance, Color.green);
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }

    // Method to take damage
    public void TakeDamage(float damage)
    {
        if (isDead) return; // If the enemy is already dead, don't apply damage
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Method for enemy death
    private void Die()
    {
        if (isDead) return; // Prevent multiple calls to Die()
        isDead = true;

        
    }

    // Trigger attack animation
    public void Attack()
    {
        if (!isDead)
        {
            animator.SetTrigger("attackTrigger");
        }
    }
}

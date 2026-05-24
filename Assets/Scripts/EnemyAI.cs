using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float chaseRange = 10f;
     public float rotationSpeed = 5f;
    public int damageAmount = 10;

    private Transform player;
    private Rigidbody rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= chaseRange)
        {
            ChasePlayer();
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }
    }
    

    void ChasePlayer()
    {
    Vector3 direction = (player.position - transform.position).normalized;

    // Prevent vertical movement
    direction.y = 0;

    Quaternion targetRotation = Quaternion.LookRotation(direction);
    rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime));

    Vector3 movement = direction * moveSpeed * Time.fixedDeltaTime;

    rb.MovePosition(rb.position + movement);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}
    
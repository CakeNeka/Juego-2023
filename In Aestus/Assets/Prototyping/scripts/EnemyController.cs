using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] private float initialMovementSpeed;
    private float movementSpeed;
    [SerializeField] private int damage;

    private bool touchingPlayer = false;
    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        movementSpeed = initialMovementSpeed;
    }

    private void FixedUpdate() {
        Transform playerTransform = GameManager.Instance.PlayerTransform;
        Vector2 dir = (playerTransform.position - transform.position).normalized;
        Vector2 movement = dir * movementSpeed;

        if (!touchingPlayer) {
            rb.velocity = movement;
        } else {
            Debug.Log("Enemy touching player");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Player")) {
            HealthSystem playerHealth = collision.collider.GetComponent<HealthSystem>();
            if (playerHealth.IsVulnerable) {
                playerHealth.TakeDamage(damage);
            }

            touchingPlayer = true;
            rb.velocity = Vector2.zero;
        }
    }

    /*
    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.collider.CompareTag("Player")) {
            touchingPlayer = true;
        }
    }
    */

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.collider.CompareTag("Player")) {
            touchingPlayer = false;
        }
        
    }


}

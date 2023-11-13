using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    private Rigidbody2D rb;
    private Transform playerTransform;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; 
    }

    private void FixedUpdate() {
        Vector2 dir = (playerTransform.position - transform.position).normalized;
        Vector2 movement = dir * movementSpeed;
        rb.velocity = movement;
    }
}

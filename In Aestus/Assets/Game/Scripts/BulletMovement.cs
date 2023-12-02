using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private float speed;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() {
        // bullet.transform previously set to firepoint.transform
        rb.velocity = transform.up * speed;
    }
}

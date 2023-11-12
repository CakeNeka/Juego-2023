using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controla el movimiento y la rotación del personaje.
/// </summary>
[RequireComponent(typeof(Rigidbody2D), typeof(PlayerStats))]
public class Movement : MonoBehaviour {

    Rigidbody2D rb2d;
    private Vector2 movementDir;
    private PlayerStats playerStats;
    Transform spriteTransform;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        playerStats = GetComponent<PlayerStats>();
        spriteTransform = transform.GetChild(0);
    }

    void Update() {
        movementDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        if (movementDir.magnitude != 0) {
            RotatePlayerSprite();
        }
    }

    private void FixedUpdate() {
        Vector2 movement = movementDir * playerStats.MovementSpeed;
        rb2d.velocity = movement;
    }

    private void RotatePlayerSprite() {
        float angle = Mathf.Atan2(movementDir.y, movementDir.x) * Mathf.Rad2Deg - 90; // -90 usando primitives, eliminar con sprites mirando a la derecha
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Debug.Log(targetRotation.eulerAngles);
        spriteTransform.rotation = Quaternion.Slerp(spriteTransform.rotation, targetRotation, 5f * Time.deltaTime);
    }

    public static void SmoothRotation(Transform t, Vector2 lookDirection, float rotationSpeed) {
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90; // -90 usando primitives, eliminar con sprites mirando a la derecha
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        t.rotation = Quaternion.Slerp(t.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}

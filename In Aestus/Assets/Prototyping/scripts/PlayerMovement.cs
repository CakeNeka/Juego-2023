using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controla el movimiento y la rotación del personaje.
/// </summary>
[RequireComponent(typeof(Rigidbody2D), typeof(PlayerStatsHandler))]
public class PlayerMovement : MonoBehaviour {

    Rigidbody2D rb2d;

    private Vector2 movementDir;
    public float MovementSpeed { get; set; }
    public float RotationSpeed { get; set; }
    Transform spriteTransform;      

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();

        spriteTransform = transform.GetChild(0);
    }

    void Update() {

        movementDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if (movementDir.magnitude != 0) {
            RotatePlayerSprite();
        }
    }

    private void FixedUpdate() {

        Vector2 movement = movementDir * MovementSpeed;
        rb2d.velocity = movement;
    }

    // TODO fix duplicated code
    private void RotatePlayerSprite() {
        float angle = Mathf.Atan2(movementDir.y, movementDir.x) * Mathf.Rad2Deg - 90; // -90 usando primitives, eliminar con sprites mirando a la derecha
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        spriteTransform.rotation = Quaternion.Slerp(spriteTransform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Busca el enemigo m�s cercano
/// </summary>
public class TrackingCannon : MonoBehaviour
{
    public float RotationSpeed { get; set; }

    private void Update() {
        Transform target = FindNearestEnemy();

        if (target) {
            LookAtEnemy(target, 10f);
        }
    }

    private Transform FindNearestEnemy() {
        Vector2 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0)); // esquina inferior izquierda
        Vector2 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1));   // esquina superior derecha
        Collider2D[] colliders = Physics2D.OverlapAreaAll(bottomLeft, topRight);  // Colliders en el área que forman

        Transform nearestEnemy = null;
        float bestDistance = Mathf.Infinity;

        foreach (Collider2D collider in colliders) {
            if (collider.CompareTag("Enemy")) {
                float distance = Vector3.Distance(transform.parent.position, collider.transform.position);
                if (distance < bestDistance) {
                    bestDistance = distance;
                    nearestEnemy = collider.transform;
                }
            }
        }

        return nearestEnemy;
    }

    private void LookAtEnemy(Transform enemyTransform, float rotationSpeed) {
        Vector2 lookDirection = enemyTransform.position - transform.position;

        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90; // -90 usando primitives, eliminar con sprites mirando a la derecha
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}

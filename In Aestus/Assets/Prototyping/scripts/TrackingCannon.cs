using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Busca el enemigo m�s cercano
/// </summary>
public class TrackingCannon : MonoBehaviour
{

    private void Update() {
        Transform target = FindNearestEnemy();

        if (target != null) {
            SmoothRotation(transform, target.position - transform.position, 10f);
        }
    }

    private Transform FindNearestEnemy() {
        Vector2 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0));
        Vector2 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1));
        Collider2D[] colliders = Physics2D.OverlapAreaAll(bottomLeft, topRight);

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

    private void SmoothRotation(Transform t, Vector2 lookDirection, float rotationSpeed) {
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90; // -90 usando primitives, eliminar con sprites mirando a la derecha
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        t.rotation = Quaternion.Slerp(t.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Busca el enemigo más cercano
/// </summary>
public class TrackingCannon : MonoBehaviour
{


    private void Update() {
        Movement.SmoothRotation(transform, FindNearestEnemy().position - transform.position, 10f);
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

}

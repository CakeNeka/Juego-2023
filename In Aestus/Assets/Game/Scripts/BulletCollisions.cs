using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisions : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField]
    private List<string> hostileTags;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hostileTags.Contains(collision.tag)) {
            HealthSystem healthSystem = collision.GetComponent<HealthSystem>();
            if (healthSystem != null && healthSystem.IsVulnerable) { // Causa daño si el objeto es vulnerable
                healthSystem.TakeDamage(damage, false);
            }
        }
    }
        

}

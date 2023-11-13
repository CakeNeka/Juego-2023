using UnityEngine;
using System.Collections;

public class HealthSystem : MonoBehaviour
{
    public int currentHp;
    public int maxHp;

    HealthBar healthBar;

    private void Start() {
        currentHp = maxHp;
        healthBar = GetComponentInChildren<HealthBar>();
        healthBar.SetMaxHealth(maxHp);
    }

    public void ReceiveDamage(int hp) {
        currentHp -= hp;
        Debug.Log($"{currentHp}/{maxHp}");
        if (currentHp <= 0) {
            Destroy(gameObject);
        } else {
            healthBar.SetHealth(currentHp);
        }
    }

    public void Heal(int hp) {
        currentHp += hp;
        if (currentHp > maxHp) {
            currentHp = maxHp;
        }
        healthBar.SetHealth(currentHp);
    }

    
}


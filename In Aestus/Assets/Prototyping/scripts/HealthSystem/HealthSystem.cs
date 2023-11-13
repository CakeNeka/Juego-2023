using UnityEngine;
using System.Collections;

public abstract class HealthSystem : MonoBehaviour
{
    [SerializeField] private int maxHp;
    private int currentHp;

    public int MaxHp { get { return maxHp; } }
    public int CurrentHp => currentHp; // getter abreviado

    HealthBar healthBar;

    private void Start() {
        currentHp = maxHp;
        // healthBar = GetComponentInChildren<HealthBar>();
        // healthBar.SetMaxHealth(maxHp);
    }


    public void ChangeHp(int hp) {
        currentHp += hp;
        Mathf.Clamp(currentHp, 0, maxHp);
        if (currentHp == 0) {
            Die();
        }
        // healthBar.SetHealth(currentHp);
    }

    protected abstract void Die();
}


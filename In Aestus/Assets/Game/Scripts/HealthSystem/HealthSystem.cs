using UnityEngine;
using System.Collections;

public abstract class HealthSystem : MonoBehaviour {
    
    [SerializeField] private int maxHp;
    [SerializeField] private int currentHp;
    [SerializeField] private float invulnerabilityDuration;
    [SerializeField] Transform healthBar;
    private bool isVulnerable = true;

    public int MaxHp { 
        get { return maxHp; } 
        set { maxHp = value; }
    }
    public int CurrentHp => currentHp; // '=>' indica propiedad de solo lectura (solo getter, sin setter)
    public float InvulnerabilityDuration {
        get { return invulnerabilityDuration; }
        set { if (value >= 0) invulnerabilityDuration = value; }
    }
    public bool IsVulnerable => isVulnerable;
    private float GetHealthPercent() {
        return (float)currentHp / maxHp;
    }

    private void Start() {
        currentHp = maxHp;
        // healthBar = GetComponentInChildren<HealthBar>();
        // healthBar.SetMaxHealth(maxHp);
    }

    public void RestoreHealth() {
        int healAmount = maxHp - currentHp;
        Heal(healAmount);
    }

    public void Heal(int healing) {
        ChangeHp(healing);
    }

    public void TakeDamage(int damage) {
        TakeDamage(damage, true);
    }

    public void TakeDamage(int damage, bool enablesInvulnerability) {
        if (tag.Equals("Player"))   // Remove, used just for debugging

        if (!IsVulnerable) {
            Debug.LogError("Trying to damage an invincible object!");
            return;
        }

        ChangeHp(-damage);
        UpdateHealthBar();
        if (invulnerabilityDuration > 0 && enablesInvulnerability) {
            StartIframes();
        }
    }

    private void ChangeHp(int hp) {
        currentHp += hp;
        Mathf.Clamp(currentHp, 0, maxHp);
        if (currentHp == 0) {
            Die();
        }
        // healthBar.SetHealth(currentHp);
    }

    private IEnumerator StartInvulnerability(float duration) {
        if (IsVulnerable) {
            isVulnerable = false;
            yield return new WaitForSeconds(duration);
            isVulnerable = true;
        }
    }

    public void StartIframes() {
        StartCoroutine(StartInvulnerability(invulnerabilityDuration));
    }

    protected abstract void Die();

    private void UpdateHealthBar() {
        if (healthBar) {
            healthBar.localScale = new Vector3(GetHealthPercent(), 1, 1);
        }
    }
}

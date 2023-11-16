using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    private HealthSystem playerHealthSystem;

    [Header("Movement")]
    [SerializeField] private float rotationSpeed;
    public float RotationSpeed => rotationSpeed;

    [SerializeField] private float movementSpeed;
    public float MovementSpeed {
        get {
            return movementSpeed; // * modifiers
        } 
    }

    [Header("Health System")]
    [SerializeField] private int maxHealth;
    [SerializeField] private float invulnerabilityDuration;

    [Header("Shooting")]
    [SerializeField] private float rotatingCannonPeriod;

    private void Start() {
        playerHealthSystem = GetComponentInChildren<HealthSystem>();
       
        playerHealthSystem.MaxHp = maxHealth;
        playerHealthSystem.RestoreHealth();
        playerHealthSystem.InvulnerabilityDuration = invulnerabilityDuration;
    }

}

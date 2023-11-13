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
    [SerializeField] private float health;
    

    [Header("Shooting")]
    [SerializeField] private float rotatingCannonPeriod;

    private void Start() {
        playerHealthSystem = GetComponent<HealthSystem>();
    }

}

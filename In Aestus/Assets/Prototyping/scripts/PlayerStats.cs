using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
    [Header("Movimiento")]
    [SerializeField]
    private float rotationSpeed;
    public float RotationSpeed {
        get {
            return rotationSpeed;
        }
    }

    [SerializeField]
    private float movementSpeed;
    public float MovementSpeed {
        get {
            return movementSpeed; // * modifiers
        } 
    }

    [Header("Health System")]
    [SerializeField] 
    private float health;

    
}

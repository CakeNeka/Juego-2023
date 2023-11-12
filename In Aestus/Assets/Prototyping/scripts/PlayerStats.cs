using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
    [SerializeField]
    private float movementSpeed;
    public float MovementSpeed {
        get {
            return movementSpeed; // * modifiers
        }
    }

    [SerializeField] 
    private float health;
}

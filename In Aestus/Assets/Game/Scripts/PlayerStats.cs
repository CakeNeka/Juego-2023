using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
[SerializeField]
[CreateAssetMenu(fileName = "TestScriptbleObject", menuName = "ScriptableObjects/TestScriptableObject")]
public class PlayerStats : ScriptableObject
{
    [Header("Movement")]
    public float rotationSpeed;
    public float movementSpeed;

    [Header("Health System")]
    public int maxHealth;
    public float invulnerabilityDuration;

    [Header("Shooting")]
    public float trackingCannonRotationSpeed;
    public float trackingCannonDelay;
    public float frontCannonDelay;


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsHandler : MonoBehaviour {

    private HealthSystem playerHealthSystem;
    private TrackingCannon trackingCannon;
    private PlayerMovement playerMovement;


    [SerializeField] private AutoShooting trackingCannonShooting;
    [SerializeField] private AutoShooting frontLeftCannonShooting;
    [SerializeField] private AutoShooting frontRightCannonShooting;

    [SerializeField] private PlayerStats playerStats;


    private void Start() {
        playerHealthSystem = GetComponentInChildren<HealthSystem>();
        trackingCannon = GetComponentInChildren<TrackingCannon>();
        playerMovement = GetComponent<PlayerMovement>();

        UpdatePlayerStats(playerStats);
    }

    public void UpdatePlayerStats(PlayerStats newPlayerStats) {
        if (newPlayerStats != null) {
            playerStats = newPlayerStats;
        }
        
        playerHealthSystem.MaxHp = playerStats.maxHealth;
        playerHealthSystem.RestoreHealth();
        playerHealthSystem.InvulnerabilityDuration = playerStats.invulnerabilityDuration;

        trackingCannon.RotationSpeed = playerStats.trackingCannonRotationSpeed;
        trackingCannonShooting.ShootDelay = playerStats.trackingCannonDelay;
        frontLeftCannonShooting.ShootDelay = playerStats.frontCannonDelay;
        frontRightCannonShooting.ShootDelay = playerStats.frontCannonDelay;

        playerMovement.RotationSpeed = playerStats.rotationSpeed;
        playerMovement.MovementSpeed = playerStats.movementSpeed;
    }
}

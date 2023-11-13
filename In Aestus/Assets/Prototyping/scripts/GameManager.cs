using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles endgame operations
/// </summary>
public class GameManager : MonoBehaviour { 
    public static GameManager Instance {  get; private set; }

    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            Debug.LogError("2 or more GameManagers found in scene");
        }
        Instance = this;
    }

    public void GameOver() {
        Debug.LogError("TODO Implement game over"); 
    }
    // GameManager can hold modifiers, points...
}

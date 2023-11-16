using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles endgame operations. Singleton class
/// </summary>
public class GameManager : MonoBehaviour { 
    public static GameManager Instance {  get; private set; } // The only instance of GameManager.


    private Transform playerTransform;
    public Transform PlayerTransform => playerTransform;
    private UIManager uiManager;

    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            Debug.LogError("2 or more GameManagers found in scene");
        }
        Time.timeScale = 1.0f;
        Instance = this;
    }

    private void Start() {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; 
        uiManager = FindObjectOfType<UIManager>();
    }

    public void GameOver() {
        uiManager.showGameOverMenu();
        Time.timeScale = 0f; // 
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    // GameManager can hold modifiers, points...
}

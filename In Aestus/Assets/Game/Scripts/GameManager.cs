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
    private UIManager uiManager;
    private EnemySpawner spawner;

    [Header("Sound assets")]

    [SerializeField]
    private SoundAudioClip[] soundAudioClipArray;
    public Dictionary<SoundManager.Sound, AudioClip> soundAudioClipMap;

    [Serializable]
    public class SoundAudioClip {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
    }

    public Transform PlayerTransform => playerTransform;

    private void Awake() {
        Application.targetFrameRate = 144;
        if (Instance != null) {
            Destroy(gameObject);
            Debug.LogError("2 or more GameManagers found in scene");
            return;
        }

        Time.timeScale = 1.0f;
        Instance = this;
        InitializeSoundAudioCipMap();
    }

    private void Start() {
        playerTransform = GameObject.Find("Player").transform; // Instantiate(playerPrefab, Vector3.zero, Quaternion.identity).transform;
        playerTransform.gameObject.name = "Player";

        uiManager = FindObjectOfType<UIManager>();
    }

    private void InitializeSoundAudioCipMap() {
        soundAudioClipMap = new Dictionary<SoundManager.Sound, AudioClip>();
        foreach (var sound in soundAudioClipArray) {
            soundAudioClipMap.Add(sound.sound, sound.audioClip);
        }
    }

    public void GameOver() {
        uiManager.showGameOverMenu();
        Time.timeScale = 0f;
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    // GameManager can hold modifiers, points...
}

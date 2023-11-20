using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField] private GameObject gameOverPanel;

    private void Start() {
        gameOverPanel.SetActive(false);
        gameManager = GameManager.Instance;
    }

    public void showGameOverMenu() {
        gameOverPanel.SetActive(true);
    }

    public void ExitToMenu() {
        Debug.Log("Quitting game");
        // TODO load scene 'menu' (1)
    }

    public void Restart() {
        Debug.Log("Restarting game...");
        gameManager.RestartGame();
    }
}

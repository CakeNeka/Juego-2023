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
        SceneManager.LoadScene(0);
    }

    public void Restart() {
        gameManager.RestartGame();
    }
}

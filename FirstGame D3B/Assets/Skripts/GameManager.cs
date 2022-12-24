using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject gameOverPanel;
    public GameObject restartButton;

    void Update()
    {
        if (player.GetComponent<PlayerHealth>().isDead)
        {
            gameOverPanel.SetActive(true);
            restartButton.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

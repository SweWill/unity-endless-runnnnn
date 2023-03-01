using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadGUI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel; // Serialized field to assign the game over panel in the Inspector

    private void Awake()
    {
        if (gameOverPanel != null) // Check if the game over panel is assigned
        {
            gameOverPanel.SetActive(false); // Disable the game over panel on start
        }
    }

    private void Update()
    {
        if (IsPlayerDead()) // Check if player is dead
        {
            gameOverPanel.SetActive(true); // Activate the game over panel if the player is dead
        }
    }

    private bool IsPlayerDead()
    {
        return GameObject.FindGameObjectWithTag("Player") == null; // Return true if there is no GameObject with the tag "Player"
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }
}

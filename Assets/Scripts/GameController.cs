//Matthew Gocool  12/04/24

using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class GameController : MonoBehaviour
{
    public GameObject player;
    public PlayerHealth playerHealth;
    public PlayerMotor playerMotor; // Reference to the PlayerMotor script

    public PlayerHealth GetPlayerHealth()
    {
        return playerHealth;
    }

    public void RestartGame(PlayerHealth playerHealth)
    {

        // Re-enable the player motor to allow movement
        playerMotor.enabled = true; // Ensure movement script is active

        // Optionally reset position or other player stats
        player.transform.position = new Vector3(0f, 1f, 0f); // Set starting position (example)

        // Reload the current scene to restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

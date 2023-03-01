// Import necessary Unity libraries
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Create a new ScoreCounter class
public class ScoreCounter : MonoBehaviour
{
    // Declare private variables
    [SerializeField] private TextMeshProUGUI scoreText; // Text field to display the score
    [SerializeField] private string playerTag = "Player"; // Tag of the player object
    private float score; // Current score

    // Start is called before the first frame update
    private void Start()
    {
        // Check if scoreText is null and assign it to the TextMeshProUGUI component of this object if so
        if (scoreText == null)
        {
            scoreText = GetComponent<TextMeshProUGUI>();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        // Find the player object in the scene using its tag
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);
        // If the player exists in the scene
        if (player != null)
        {
            // Increase the score by the amount of time since the last frame
            score += Time.deltaTime;
            // Update the score text field with the current score, rounded down to the nearest integer
            scoreText.text = Mathf.FloorToInt(score).ToString();
        }
    }
}

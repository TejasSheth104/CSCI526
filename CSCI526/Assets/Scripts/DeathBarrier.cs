using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBarrier : MonoBehaviour
{
    private GameManager gameManager;
    private Color pitColor;

    void Start()
    {
        gameManager = GameManager.Instance;
        pitColor = GetComponent<SpriteRenderer>().color;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerColorChange playerColorChange = other.GetComponent<PlayerColorChange>();
            if (playerColorChange != null && playerColorChange.GetColor() == pitColor)
            {
                // Decrease counter if player's color matches pit's color
                gameManager.UpdateCounter(playerColorChange.GetColorName(), -1);
                other.gameObject.SetActive(false); // Turn off the player
                gameManager.DestroyGameInstance(); // Destroy the game instance
            }
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class HeartHealthUI : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private PlayerHealth playerHealth; // drag your player object here

    [Header("Heart Images (size = 5)")]
    [SerializeField] private Image[] hearts;

    [Header("Sprites")]
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite halfHeart;
    [SerializeField] private Sprite emptyHeart;

    [Header("Settings")]
    [SerializeField] private int heartCount = 5;

    private void Start()
    {
        if (playerHealth == null)
        {
            Debug.LogError("HeartHealthUI: PlayerHealth reference not set in Inspector.");
            return;
        }

        playerHealth.OnHealthChanged += UpdateHearts;

        // initialize immediately
        UpdateHearts(playerHealth.CurrentHealth, playerHealth.maxHealth);
    }

    private void OnDestroy()
    {
        if (playerHealth != null)
            playerHealth.OnHealthChanged -= UpdateHearts;
    }

    private void UpdateHearts(int currentHealth, int maxHealth)
    {
        int totalHalfHearts = heartCount * 2;

        int currentHalfHearts = Mathf.RoundToInt((float)currentHealth / maxHealth * totalHalfHearts);
        currentHalfHearts = Mathf.Clamp(currentHalfHearts, 0, totalHalfHearts);

        for (int i = 0; i < heartCount; i++)
        {
            int heartHalfIndex = i * 2;

            if (currentHalfHearts >= heartHalfIndex + 2)
                hearts[i].sprite = fullHeart;
            else if (currentHalfHearts == heartHalfIndex + 1)
                hearts[i].sprite = halfHeart;
            else
                hearts[i].sprite = emptyHeart;
        }
    }
}
using TMPro;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    [SerializeField] int baseHealth = 5;
    [SerializeField] int damage = 1;

    float currentHealth;
    TextMeshProUGUI healthDisplay;

    private void Start()
    {
        currentHealth = baseHealth; // TODO baseHealth - difficulty

        healthDisplay = GetComponentInChildren<TextMeshProUGUI>();
        UpdateHealthDisplay();

    }

    public void AddHealth(int amount)
    {
        currentHealth += amount;
        UpdateHealthDisplay();
    }

    public void ReduceHealth()
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }

        UpdateHealthDisplay();
    }

    private void UpdateHealthDisplay()
    {
        healthDisplay.text = currentHealth.ToString();
    }
}

using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth = 100f;

    float currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void DealDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            // TODO Trigger death VFX
            Destroy(gameObject);
        }
    }
}

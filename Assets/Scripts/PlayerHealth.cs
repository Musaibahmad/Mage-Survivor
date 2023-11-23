using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    public Image healthSlider;
    public float powerIncreaseInterval =30f;
    private float timeSinceLastDamage;

    void Start()
    {
        currentHealth = maxHealth;
        timeSinceLastDamage = Time.time;
        UpdateHealthSlider();
    }

    private void Update()
    {
        if (!FindObjectOfType<PlayerController>().isDamage)
        {
            //IncreasePower();
        }
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Max(currentHealth, 0);

        // Update UI slider for health
        UpdateHealthSlider();

        if (currentHealth <= 0)
        {
            Die();
        }

        // Reset the time only when not taking damage
        if (damageAmount <= 0)
        {
            timeSinceLastDamage = Time.time;
        }
    }

    void Die()
    {
        Debug.Log("Player has died!");
        FindObjectOfType<CameraFollow>().isDead = true;
        Destroy(gameObject);
    }

    void UpdateHealthSlider()
    {
        float healthFillAmount = currentHealth / maxHealth;
        healthSlider.fillAmount = healthFillAmount;
    }

   public  void IncreasePower()
    {
        if (Time.time - timeSinceLastDamage > powerIncreaseInterval)
        {
            Debug.Log("Increase Power");
            currentHealth += 5f;
            currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
            UpdateHealthSlider();
        }
    }

   
}

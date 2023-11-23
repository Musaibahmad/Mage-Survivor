using UnityEngine;
using UnityEngine.UI;

public class EnemyWithPower : MonoBehaviour
{
    public float initialPower = 100f;
    private float currentPower;
    public Image powerSlider;

    void Start()
    {
        currentPower = initialPower;
        UpdateFillBar();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
                DecreasePower(10);
                Destroy(collision.gameObject);
        }
    }

    public void DecreasePower(float amount)
    {
        currentPower -= amount;
        currentPower = Mathf.Max(currentPower, 0);
        UpdateFillBar();
        if (currentPower <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
    void UpdateFillBar()
    {
        float fillAmount = currentPower / initialPower;
        powerSlider.fillAmount = fillAmount;
    }
}

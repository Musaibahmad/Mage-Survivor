using UnityEngine;

public class EnemyDamageRadius : MonoBehaviour
{
    public float damageAmount = 5f;
    public float damageInterval = 1f; // Time between each damage tick
    public LayerMask playerLayer;

    private float timeSinceLastDamage;

    private void OnCollisionEnter(Collision collision)
    {
        if (IsPlayer(collision))
        {
            timeSinceLastDamage = Time.time;
            InvokeRepeating(nameof(DamagePlayer), 0f, damageInterval);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (IsPlayer(collision))
        {
            Debug.Log("Player Detect");
            CancelInvoke(nameof(DamagePlayer));
        }
    }
   
    private void DamagePlayer()
    {
      PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();

        if (playerHealth != null)
        {
             playerHealth.TakeDamage(damageAmount);
        }
    }

    private bool IsPlayer(Collision other)
    {
        return (playerLayer.value & (1 << other.gameObject.layer)) != 0;
    }
}


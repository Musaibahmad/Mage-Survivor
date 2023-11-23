using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // Speed of the bullet
    public float damage = 10f; // Damage dealt by the bullet

    void Start()
    {
        // Set the bullet to destroy itself after a certain time to prevent memory leaks
        //Destroy(gameObject, 2f);
    }

    void Update()
    {
        // Move the bullet forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the bullet collides with an enemy
        //if (other.CompareTag("Enemy"))
        //{
        //    Debug.Log("Damage here");
        //    // Deal damage to the enemy
        //    EnemyWithPower enemy = other.GetComponent<EnemyWithPower>();

        //    if (enemy != null)
        //    {
        //        enemy.DecreasePower(damage);
        //    }

        //    // Destroy the bullet upon hitting an enemy
        //    //Destroy(gameObject);
        //}
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag=="Enemy")
        {
            EnemyWithPower enemy = collision.transform.GetComponent<EnemyWithPower>();

            if (enemy != null)
            {
                enemy.DecreasePower(damage);
            }
        }
        if (gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}

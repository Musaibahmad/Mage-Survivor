using UnityEngine;
using System.Collections.Generic;

public class AutoFire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float speed;
    public float fireInterval = 0.5f;
    private float timeSinceLastFire = 0f;
    public float detectionRadius = 10f;
    public LayerMask enemyLayer;
    public Transform enemyface;

    private Dictionary<Collider, float> lastFireTimes = new Dictionary<Collider, float>();

    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, enemyLayer);
        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                if (!lastFireTimes.ContainsKey(collider) || Time.time - lastFireTimes[collider] > fireInterval)
                {
                    enemyface.transform.LookAt(collider.transform.position);
                    AutoFiree(collider.transform.position);
                    lastFireTimes[collider] = Time.time;
                }
            }
        }
    }

    void AutoFiree(Vector3 enemyPosition)
    {
        FireBullet(enemyPosition);
    }

    void FireBullet(Vector3 targetPosition)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bullet.transform.LookAt(targetPosition);
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * speed, ForceMode.Impulse);
        Destroy(bullet, 2f);
    }

}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FollowPlayerAI : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    public float rotationSpeed = 2f;
    public float detectionRadius = 10f;
    public float fireInterval = 2f;
    private float timeSinceLastFire = 0f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float damageInterval = 1f;
    public float speed;
    private void Start()
    {
        if (!FindObjectOfType<CameraFollow>().isDead)
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius);
        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                //AutoFire();
                break;
            }
        }

        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer > 2f)
            {
                Vector3 direction = player.position - transform.position;
                direction.Normalize();
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                transform.position += transform.forward * moveSpeed * Time.deltaTime;
                FindObjectOfType<PlayerController>().isDamage = false;
            }
        }
        Collider[] PlayerDamge = Physics.OverlapSphere(transform.position, 2f);
       
        foreach (var collider in PlayerDamge)
        {
            if (collider.CompareTag("Player"))
            {
              
                playerDamage();
                break;
            }
         

        }

    }
   void playerDamage()
    {
        if (Time.time - timeSinceLastFire > fireInterval)
        {
            Debug.Log("Player Damage");
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            FindObjectOfType<PlayerHealth>().TakeDamage(5f);
            timeSinceLastFire = Time.time;
        }
           
    }
    //void AutoFire()
    //{
    //    if (Time.time - timeSinceLastFire > fireInterval)
    //    {
    //        FireBullet();
    //        timeSinceLastFire = Time.time;
    //    }
    //}

    //void FireBullet()
    //{
    //    GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    //    bullet.GetComponent<Rigidbody>().AddForce(firePoint.forward * speed, ForceMode.Impulse);
    //    Destroy(bullet, 2f);
    //}
}

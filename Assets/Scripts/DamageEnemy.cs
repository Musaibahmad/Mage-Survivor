using UnityEngine;
using System;
using System.Collections;

public class DamageEnemy : MonoBehaviour
{
    public float damageAmount = 30f;
    public float radius = 10f;
    public LayerMask enemyLayer;
    public GameObject damageEffectPrefab;
    private void Start()
    {
        StartCoroutine(DropDamage());
    }
    void Update()
    {
        //if (Input.GetButtonDown("Fire1"))
        //{
        //    DropDamage();
        //}
    }

  IEnumerator DropDamage()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius, enemyLayer);

            foreach (Collider collider in colliders)
            {
                Vector3 enemyPosition = collider.transform.position;
                GameObject damageEffect = Instantiate(damageEffectPrefab, new Vector3(enemyPosition.x, enemyPosition.y + 1f, enemyPosition.z), Quaternion.identity);
                Destroy(damageEffect, 2f);
                EnemyWithPower enemyHealth = collider.GetComponent<EnemyWithPower>();
                if (enemyHealth != null)
                {
                    enemyHealth.DecreasePower(damageAmount);
                }
            }
        yield return new WaitForSeconds(1f);
        }
    }
}

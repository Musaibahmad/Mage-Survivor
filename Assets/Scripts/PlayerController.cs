using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public Animator characterAnimator;
    public CharacterController cc;
    public float moveSpeed = 1f;
    public Transform weapon;
    public float detectionRadius;
    public Transform hand;
    public LayerMask enemyLayer;
    public bool isTurn, isDamage;
    void Start()
    {
        ETCInput.SetTurnMoveSpeed("New Joystick", moveSpeed);
        weapon.SetParent(hand);
    }

    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, enemyLayer);
        bool canRotate = (colliders.Length == 0);
        

        if (colliders.Length > 0)
        {
            isTurn = true;
            Transform nearestEnemy = FindNearestEnemy(colliders);

            Vector3 lookAtPosition = new Vector3(nearestEnemy.position.x, transform.position.y, nearestEnemy.position.z);
            transform.LookAt(lookAtPosition);
            isDamage = true;
        }
        else
        {
            isTurn = false;
            FindObjectOfType<PlayerHealth>().IncreasePower();
            isDamage = false;
            
        }
        if (isTurn)
        {
            float x = ETCInput.GetAxis("Horizontal");
            float z = ETCInput.GetAxis("Vertical");
            transform.position += new Vector3(x, 0, z) * moveSpeed * Time.deltaTime;
        }
     
        characterAnimator.SetBool("Run", !isStop());

        if (!cc.isGrounded)
        {
            cc.Move(-Vector3.up * moveSpeed * Time.deltaTime);
        }
    }

    bool isStop()
    {
        if (ETCInput.GetAxis("Horizontal") == 0 && ETCInput.GetAxis("Vertical") == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    Transform FindNearestEnemy(Collider[] colliders)
    {
        Transform nearestEnemy = null;
        float minDistance = float.MaxValue;

        foreach (var collider in colliders)
        {
            float distance = Vector3.Distance(transform.position, collider.transform.position);

            if (distance < minDistance)
            {
                minDistance = distance;
                nearestEnemy = collider.transform;
            }
        }
        return nearestEnemy;
    }
}

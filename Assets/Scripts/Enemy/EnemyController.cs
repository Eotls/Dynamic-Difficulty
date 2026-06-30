using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    EnemyMovement enemyMovement;
    EnemyHealthController enemyHealthController;
    public Transform player;
    [SerializeField]
    Rounds rounds;

    void Awake()
    {
        enemyHealthController = GetComponent<EnemyHealthController>();
        enemyMovement = GetComponent<EnemyMovement>();
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        enemyHealthController.Die += Die;
    }

    private void Update()
    {
        Chase();
    }

    public void Chase()
    {
        enemyMovement.Move(player);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        float rayDistance = 10f;
        Gizmos.DrawRay(transform.position, transform.forward * rayDistance);
    }
    public void Die()
    {
        rounds.currentEnemyCount--;
        Destroy(gameObject);
    }
    // Lambda expressions
    public void Idle() => enemyMovement.StopMove();
    
}
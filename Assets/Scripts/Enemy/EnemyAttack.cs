using System;
using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    float attackDelay;

    [SerializeField]
    float radius;

    [SerializeField]
    Vector3 offset;

    [SerializeField]
    string playerTag = "Player";

    private void Start()
    {
        StartCoroutine(Attack());
    }

    public void AttackCheck()
    {

        Collider[] colliders = Physics.OverlapSphere(transform.position + offset, radius);

        foreach (Collider col in colliders)
        {
            if (col.CompareTag(playerTag)) col.GetComponent<HealthController>().TakeDamage(50);
        }

    }
    IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackDelay);

            AttackCheck();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + offset, radius);
    }
}
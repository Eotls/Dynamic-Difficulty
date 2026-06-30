using UnityEngine;

public class EnemyDeathCheck : MonoBehaviour
{
    [SerializeField]
    EnemyHealthController health;
    void Start()
    {
        health.Die += Die;
    }
    void Die()
    {
        Destroy(gameObject);
    }
}

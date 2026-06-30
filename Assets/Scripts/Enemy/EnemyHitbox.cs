using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    [SerializeField]
    EnemyHealthController health;

    [SerializeField]
    EnemyMovement movement;

    [SerializeField]
    float multiplier;

    [SerializeField]
    bool leg;

    [SerializeField]
    bool head;

    public void Hit(float damage)
    {
        health.TakeDamage(damage * multiplier, leg, head);
    }
    public void AimedAt()
    {
        if (!head) return;
        movement.isAimedAt = true;
        movement.AimedAt();
    }
    public void Update()
    {
        if (movement.isAimedAt) return;
        movement.isAimedAt = false;
        movement.NotAimedAt();
    }
}

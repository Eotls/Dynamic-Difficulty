using System;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public DynamicDifficulty DD;
    public float health;
    public float maxHealth = 100f;
    float legPercentage = 0.5f;
    float legMaxHealth => maxHealth * DD.legHealth;
    private float legHealth;

    public event Action Die;
    public event Action Crawl;

    public event Action Headshot;

    void Awake()
    {
        health = maxHealth;
        legHealth = legMaxHealth;
    }

    public void TakeDamage(float damage, bool leg, bool head)
    {
        if (leg)
        {
            legHealth -= damage;
            if (legHealth <= 0) Crawl?.Invoke();
        }
        if (head)
        {
            Headshot?.Invoke();
        }
        health -= damage;
        if (health <= 0) Die?.Invoke();
    }
}

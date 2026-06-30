using System;
using System.Collections;
using System.ComponentModel;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public Difficulty difficulty;
    int maxHealth => 100 + difficulty.difficulty * 50;

    public float health;

    [SerializeField, Tooltip("Time until regeneration begins")]
    float healthRegenWaitTime;

    [SerializeField, Tooltip("Health increase per second while regenerating")]
    float healthRegen;

    Coroutine regen;

    float timeSinceDamage;


    private void Start()
    {
        health = maxHealth;
    }
    private void Update()
    {
        if(timeSinceDamage < healthRegenWaitTime) timeSinceDamage += Time.deltaTime;

        if (regen == null && timeSinceDamage > healthRegenWaitTime && health < maxHealth) StartHealthRegen();
    }
    void StartHealthRegen()
    {
        if (regen != null) return;
        regen = StartCoroutine(HealthRegen());
    }

    void StopRegen()
    {
        if (regen == null) return;
        StopCoroutine(regen);
        regen = null;
    }

    IEnumerator HealthRegen()
    {
        while (health < maxHealth)
        {
            health += healthRegen * Time.deltaTime;
            yield return null;
        }
        health = maxHealth;
        StopRegen();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
        timeSinceDamage = 0;
        StopRegen();
    }
}
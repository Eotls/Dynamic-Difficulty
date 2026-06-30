using System;
using UnityEngine;
[Serializable]
[CreateAssetMenu]

public class DynamicDifficulty : ScriptableObject
{
    // Crawl speed
    public float crawlSpeed;
    private float defaultCrawlSpeed = 0.5f;
    // Crawl health
    public float legHealth;
    private float legHealthDefault = 0.5f;
    // Reaction time
    public float reactionTime;
    private float reactionTimeDefault = 2f;
    // Dodge Distance
    public float dodgeDistance;
    private float dodgeDistanceDefault = 5f;
    // Dodge Speed
    public float dodgeSpeed;
    private float dodgeSpeedDefault = 0.5f;
    private void OnEnable()
    {
        ResetDD();
    }
    public void ResetDD()
    {
        crawlSpeed = defaultCrawlSpeed;
        legHealth = legHealthDefault;
        reactionTime = reactionTimeDefault;
        dodgeDistance = dodgeDistanceDefault;
        dodgeSpeed = dodgeSpeedDefault;
        reactionTime = Mathf.Clamp(reactionTime, 0.5f, 2f);
        dodgeSpeed = Mathf.Clamp(dodgeSpeed, 0.5f, 2f);
    }
    public void DDCrawl()
    {
        crawlSpeed += 0.01f;
        legHealth += 0.01f;
    }
    public void DDdodge()
    {
        reactionTime += -0.1f;
        dodgeDistance += 0.25f;
        dodgeSpeed += -0.01f;
    }
}

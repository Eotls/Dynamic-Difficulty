using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    NavMeshAgent agent;
    EnemyHealthController EnemyHealthController;
    EnemyController controller;
    [SerializeField]
    DynamicDifficulty DD;
    public bool isAimedAt;
    bool isStunned = false;
    bool isCrawling = false;
    float crawlSpeedMultiplier = 0.5f;
    bool dodgeRight;
    private Vector3 direction;
    Coroutine Stun;
    Coroutine Reaction;
    [SerializeField]
    Transform player;
    [SerializeField]
    Transform enemyMesh;
    bool isDodgeActive;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        EnemyHealthController = GetComponent<EnemyHealthController>();
        controller = GetComponent<EnemyController>();
        EnemyHealthController.Crawl += CrawlSpeed;
        agent.isStopped = false;
        EnemyHealthController.Headshot += OnHeadshot;
    }
    void CrawlSpeed()
    {
        if (isCrawling) return;
        isCrawling = true;
        agent.speed = agent.speed * DD.crawlSpeed;
        DD.DDCrawl();
    }
    public void AimedAt()
    {
        if (Reaction != null) return;
        Reaction = StartCoroutine(ReactionTime());
    }
    public void NotAimedAt()
    {
        if (Reaction == null) return;
        StopCoroutine(Reaction);
        Reaction = null;
    }
    IEnumerator ReactionTime()
    {
        yield return new WaitForSeconds(DD.reactionTime);
        if(isAimedAt)Dodge();
        Reaction = null;
    }
    void Sprint(bool headShot)
    {
        agent.speed = 10f;
        if (headShot) StunStart(true);
    }
    public void Move(Transform Target)
    {
        if (Stun != null) return;
        agent.isStopped = false;
        agent.updateRotation = true;
        agent.SetDestination(Target.position);
    }
    void StunStart(bool startStun)
    {
        if (startStun)
        {
            if (Stun != null) return;
            isStunned = true;
            Stun = StartCoroutine(Stunned());
        }
    }
    IEnumerator Stunned()
    {
        StopMove();
        yield return new WaitForSeconds(2.5f);
        isStunned = false;
        controller.Chase();
        Stun = null;
    }
    void StunStop()
    {
        if (Stun == null) return;
        StopCoroutine(Stun);
    }
    public void StopMove()
    {
        agent.isStopped = true;
        agent.velocity = Vector3.zero;
        agent.updateRotation = false;
    }
    private void OnDestroy()
    {
        EnemyHealthController.Crawl -= CrawlSpeed;
    }
    public void Dodge()
    {
        if (!isDodgeActive && !isStunned)
        {
            dodgeRight = UnityEngine.Random.value > 0.5f;
            transform.position += dodgeRight ? transform.right * DD.dodgeDistance : -transform.right * DD.dodgeDistance;
            StartCoroutine(DodgeActive());
        }
    }
    IEnumerator DodgeActive()
    {
        isDodgeActive = true;
        yield return new WaitForSeconds(DD.dodgeSpeed);
        isDodgeActive = false;
        DD.DDdodge();
    }

    void OnHeadshot()
    {
        if (isDodgeActive)
        {
            transform.position = enemyMesh.transform.position;
            StunStart(true);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * 1);
    }
}
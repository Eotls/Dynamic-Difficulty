using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject enemy;
    Coroutine enemySpawn;
    [SerializeField]
    Rounds rounds;

    void Start()
    {
        if (enemySpawn != null) return;
        enemySpawn = StartCoroutine(EnemySpawn());
    }
    IEnumerator EnemySpawn()
    {
        while (rounds.currentEnemyCount > 0 && rounds.currentEnemyCount <= 16)
        {
            yield return new WaitForSeconds(5);
            spawnEnemy();
            rounds.currentEnemyCount++;
            yield return null;
        }
    }
    void spawnEnemy()
    {
        Instantiate(enemy, transform.position, Quaternion.identity);
    }
}

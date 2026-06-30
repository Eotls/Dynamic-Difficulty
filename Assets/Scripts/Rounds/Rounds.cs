using UnityEngine;

[SerializeField]
[CreateAssetMenu]
public class Rounds : ScriptableObject
{

    public int roundCounter;
    public int enemyCount => roundCounter * 7;
    public int currentEnemyCount;
    private void Awake()
    {
        roundCounter = 1;
        if (currentEnemyCount == 0) roundCounter++;
    }

}

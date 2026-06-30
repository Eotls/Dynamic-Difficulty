using UnityEngine;

public class EnemyRotationScript : MonoBehaviour
{
    [SerializeField]
    Transform enemy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = enemy.rotation;
    }
}

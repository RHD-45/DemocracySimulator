using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] public Enemy enemy;
    [SerializeField] private int enemyRate = 3;
    [SerializeField] public float enemyMoveSpeed = 0.5f; 
    float topPoint = 2.2f;
    float bottomPoint = -2.2f;
    float leftPoint = -5.3f;
    float rightPoint = 5.3f;
    void Awake()
    {
        enemy.enemyMoveSpeed = 0.5f;
        for (int i = 0; i < enemyRate; ++i)
        {
            Instantiate(enemy, new Vector3(UnityEngine.Random.Range(leftPoint, rightPoint), UnityEngine.Random.Range(topPoint, bottomPoint), 0), transform.rotation);     
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemy()
    {
        Debug.Log(enemy.enemyMoveSpeed);
        enemy.enemyMoveSpeed += 0.05f;
        Instantiate(enemy, new Vector3(UnityEngine.Random.Range(leftPoint, rightPoint), UnityEngine.Random.Range(topPoint, bottomPoint), 0), transform.rotation);     
    }
}

using UnityEngine;
//using Unity.Mathematics;
public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    private float health = 100f;
    private float currentHp;
    [SerializeField] private float enemyMoveSpeed = 1f; 
    private PlayerClickToMove player;
    private int enemyDmg = 10;
    private int enemyCheck = 1;
    float topPoint = 2.2f;
    float bottomPoint = -2.2f;
    float leftPoint = -5.3f;
    float rightPoint = 5.3f;
    public void OnTriggerEnter2D(Collider2D collision)
     {
        if(collision.gameObject.CompareTag("Player"))
         {
            collision.gameObject.GetComponent<PlayerHP>().TakeDamage(enemyDmg); ;
         }
     } 
    void Start()
    {
        player = FindAnyObjectByType<PlayerClickToMove>();
        currentHp = health;
    }
     public void TakeDamage(float damage)
     {
         currentHp-=damage;
        if (currentHp <= 0)
         {
             Die();
         }
     }
    void MoveToPlayer()
    {
        if(player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position,player.transform.position,enemyMoveSpeed*Time.deltaTime);
            FlipEnemy();
        }
    }   
    void FlipEnemy()
    {
        if(player != null)
        {
            transform.localScale= new Vector3(player.transform.position.x<transform.position.x ? -1 : 1,1,1);
        }
    }
    void Die()
    {
             
        if (enemyCheck < 3)
        {
            enemyCheck++;
            SpawnEnemy();
        }
        Destroy(enemy);  
    }
    void SpawnEnemy()
    {
        Instantiate(enemy, new Vector3(Random.Range(leftPoint, rightPoint), Random.Range(topPoint, bottomPoint), 0), transform.rotation);
    }
    void Update()
    {
        MoveToPlayer();
    }
}
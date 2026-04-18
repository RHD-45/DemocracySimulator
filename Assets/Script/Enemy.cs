using UnityEngine;
using Unity.Mathematics;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    [SerializeField] Image healthBar;
    [SerializeField] ScoreManagement scoreManager;
    public EnemySpawner enemySpawner;
    private float health = 100f;
    private float currentHp;
    [SerializeField] public float enemyMoveSpeed = 0.5f; 
    private PlayerClickToMove player;
    private int enemyDmg = 10;
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
        enemySpawner = FindAnyObjectByType<EnemySpawner>();
        scoreManager = FindAnyObjectByType<ScoreManagement>();
    }
     public void TakeDamage(float damage)
     {
         currentHp-=damage;
         healthBar.fillAmount = currentHp / 100f;
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
        scoreManager.addScore();
        enemySpawner.SpawnEnemy();
        Destroy(gameObject);
    }
    

    void Update()
    {
        MoveToPlayer();
    }
}
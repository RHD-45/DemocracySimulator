using Unity.Mathematics;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    private float health = 100f;
    private float currentHp;
    [SerializeField] private float enemyMoveSpeed = 1f; 
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
    }
     public void TakeDamage(float damage)
     {
         currentHp-=damage;
         currentHp = math.max(0,currentHp);
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
         Destroy(gameObject); 
     }
    void Update()
    {
        MoveToPlayer();
    }
}
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame

    [SerializeField] int bombDamage = 20;
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("here");
	    if(other.gameObject.CompareTag("Enemy"))
	    {
            Destroy(other);
            Debug.Log("Enemy touched Bomb");
            animator.SetBool("Explode",true);
            
	    }
        else if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHP>().TakeDamage(bombDamage);
            Debug.Log("Player touched Bomb");
            animator.SetBool("Explode",true);
        }
        
    }

    public void OnDeathAnimationFinished()
    {
        Destroy(gameObject);
    }
}

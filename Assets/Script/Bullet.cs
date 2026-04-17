using UnityEngine;
using UnityEngine.InputSystem;
using Unity.VisualScripting;
public class Bullet : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    private Rigidbody2D rb;
    //private Rigidbody2D Enemy;
    private float force = 10f;
    [SerializeField] private float timeDestroy = 6.5f;
    [SerializeField] private float damage = 10f;
    [SerializeField] private float moveSpeed = 25f;
    void Start()
    {
        
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
        
    }

    // Update is called once per frame
    void MoveBullet() {
        transform.Translate(Vector2.right*moveSpeed*Time.deltaTime);
    }
    void Update()
    {
        Destroy(gameObject, timeDestroy);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (collision.CompareTag("Enemy"))
        {
            if(enemy != null) {
                enemy.TakeDamage(damage);
                Destroy(gameObject);
            }
        }

    }
}

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerClickToMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2.5f;
    private Vector3 targetPosition;
    private Rigidbody2D rb;
    Vector2 mousePos;
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        targetPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        
    }
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            targetPosition.z = transform.position.z;
            Debug.Log("here");
        }
        mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }
    void FixedUpdate()
    {
        //Vector2 direction = mousePos - rb.position; //
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        //rb.rotation = angle;
        Vector2 newPosition = Vector2.MoveTowards(rb.position, targetPosition, moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(newPosition);
    }
}
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [Header("HP Settings")]
    [SerializeField] private int maxHP = 100;
    private int currentHP;

    void Start()
    {
        currentHP = maxHP;
        Debug.Log($"HP hiện tại: {currentHP}");
    }

    public void TakeDamage(int dmg)
    {
        currentHP -= dmg;
        Debug.Log($"Bị đánh! HP còn lại: {currentHP}");

        if (currentHP <= 0)
        {
            currentHP = 0;
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player đã chết!");
        // game overrrrrrrr
        gameObject.SetActive(false);
    }

    public int GetCurrentHP() => currentHP;
}
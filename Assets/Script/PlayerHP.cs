using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [Header("HP Settings")]
    [SerializeField] Image healthBar;
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
        healthBar.fillAmount = currentHP / 100f;

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
        Destroy(transform.parent.gameObject);
    }

    public int GetCurrentHP() => currentHP;
}
// PlayerCombat.cs
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    public Transform shotPoint;
    public GameObject bullet;
    public float bulletForce;

    public float timeBetweenShots;
    public float shotCounter;
    void Update()
    {
        if (Mouse.current.rightButton.isPressed)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                Shoot();
                shotCounter = timeBetweenShots;
            }
        }
    }
    void Shoot()
    {
        GameObject bulletInstance = Instantiate(bullet, shotPoint.position, shotPoint.rotation);
        Rigidbody2D rb = bulletInstance.GetComponent<Rigidbody2D>();
        rb.AddForce(shotPoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
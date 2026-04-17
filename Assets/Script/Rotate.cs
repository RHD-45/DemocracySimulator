using UnityEngine;
using UnityEngine.InputSystem;

public class Rotate : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletTransform;
    [SerializeField] private Transform firePoint; // firepoint cua player, de xac dinh huong bay cua dan
    private float fireRate = 0.5f; // thoi gian giua 2 lan ban
    private float nextFireTime = 0f; // thoi gian tiep theo co the ban
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        Vector3 rotation = mousePos - transform.position;
        float RotZ =  Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, RotZ);
        if (Mouse.current.rightButton.wasPressedThisFrame && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;


        }
    }
    void Shoot()
    {
        Instantiate(bullet, firePoint.position, transform.rotation);
    }
}

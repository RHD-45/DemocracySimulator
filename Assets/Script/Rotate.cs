using UnityEngine;
using UnityEngine.InputSystem;

public class Rotate : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletTransform;
    [SerializeField] private Transform firePoint; // firepoint cua player, de xac dinh huong bay cua dan
    public bool canFire;
    private float Timer = 0f;
    [SerializeField] private float timeBetweenFire = 2.5f;
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
        if(!canFire)
        {
            Timer += Time.deltaTime;
            if(Timer >= timeBetweenFire)
            {
                canFire = true;
                Timer = 0;
            }
        }
        if (Mouse.current.rightButton.isPressed && canFire)
        {
            canFire = false;
            Instantiate(bullet, firePoint.position, transform.rotation);
            
        }
    }
}

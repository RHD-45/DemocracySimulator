using UnityEngine;
using UnityEngine.InputSystem;

public class Rotate : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float Timer;
    public float timeBetweenFire;
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
        transform.rotation = Quaternion.Euler(0f, 0f, RotZ - 90);
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
            Instantiate(bullet, bulletTransform.position, transform.rotation);
            
        }
    }
}

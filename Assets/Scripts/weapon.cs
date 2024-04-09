using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public int plus = 90;

    public GameObject projectile;
    public Transform shotPoint;
    public float timeBetweenShots;

    public VirtualJoystick joystick;

    [HideInInspector]
    public bool canShoot;

    private float shotTime;

    Animator camAnim;

    private void Start()
    {
        camAnim = Camera.main.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (joystick.InputDir != Vector3.zero)
            angle = Mathf.Atan2(joystick.InputDir.y, joystick.InputDir.x) * Mathf.Rad2Deg + plus;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;

        if (canShoot == false)//&&Input.GetMouseButton(0)
        {
            if (Time.time >= shotTime)
            {
                Instantiate(projectile, shotPoint.position, transform.rotation);
                //camAnim.SetTrigger("shake");
                shotTime = Time.time + timeBetweenShots;
            }
        }
    }
}

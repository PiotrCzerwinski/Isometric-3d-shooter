using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    [SerializeField]
    public float roundsPerMinute = 120;
    public float coolDownTime = 0.1f;

    public float bulletForce = 20f;

    private void Start()
    {
        transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
    }
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Fire();
        }
        else if (Time.time >= coolDownTime) {
            coolDownTime = Time.time;
        }
    }

    void Fire()
    {
        float timeBetweenShots = 60f / roundsPerMinute;
        while (Time.time >= coolDownTime) {

            coolDownTime += timeBetweenShots;
            FireBullet();
        }

        /*GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, transform.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(bulletSpawn.forward * bulletForce, ForceMode.Impulse);
        Destroy(bullet, 5.0f);*/

    }

    void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, transform.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(bulletSpawn.forward * bulletForce, ForceMode.Impulse);
        Destroy(bullet, 5.0f);
    }
}

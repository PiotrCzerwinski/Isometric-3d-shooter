using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    private Transform player;
    [SerializeField]
    public float roundsPerMinute = 120;
    public float coolDownTime = 0.1f;
    [SerializeField]
    public float bulletForce = 10f;

    private void Start()
    {
        player = GetComponent<Transform>();
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
    {   Vector3 bulletRotation = new Vector3(player.rotation.x, player.rotation.y +90, player.rotation.z);
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.Euler(bulletRotation));
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(bulletSpawn.forward * bulletForce, ForceMode.Impulse);
        Destroy(bullet, 5.0f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    private void Start()
    {
        transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(bulletSpawn.forward * bulletForce, ForceMode.Impulse);
        Destroy(bullet, 5.0f);

    }

   /* private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameObject gameObject = collision.gameObject;
            gameObject.GetComponent<Enemy>().takeDamage();
        }
    }*/
}

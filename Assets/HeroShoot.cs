using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroShoot : MonoBehaviour
{

    private Rigidbody2D rb2d;
    public Transform firePoint;
    public GameObject bulletPrefab;
    private float bulletSpeed = 40f;
    private float cooldown = 0.2f;
    private float nextFire = 0f;

    public static int eggCount = 0;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ProcessBulletSpawn();
    }

    private void ProcessBulletSpawn()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D re = bullet.GetComponent<Rigidbody2D>();
            re.velocity = firePoint.up * bulletSpeed;
            eggCount++;
         
            nextFire = Time.time + cooldown;
        }
    }
}
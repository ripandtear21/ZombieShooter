using System.Collections.Generic;
using UnityEngine;

namespace Shooting
{
    public class RifleShootingScript : MonoBehaviour
    {
        public Transform firePoint;
        public GameObject bulletPrefab;
        public float bulletSpeed = 20f;
        public float fireRate = 0.2f;
        public int poolSize = 20;
        public int maxAmmo = 10;

        private List<GameObject> bulletPool;
        private AmmoManager ammoManager;
        private float nextFireTime = 0f;
        private int poolIndex = 0;

        void Start()
        { 
            bulletPool = new List<GameObject>();
            for (int i = 0; i < poolSize; i++)
            {
                GameObject bullet = Instantiate(bulletPrefab);
                bullet.SetActive(false);
                bulletPool.Add(bullet);
            }

            ammoManager = new AmmoManager(maxAmmo);
        }

        void Update()
        {
            if (Time.time > nextFireTime && Input.GetButtonDown("Fire1") && ammoManager.Fire())
            {
                Shoot();
                nextFireTime = Time.time + fireRate;
            }

            if (Input.GetKey(KeyCode.R) && ammoManager.GetCurrentAmmo() < maxAmmo)
            {
                ammoManager.Reload();
            }
        }

        void Shoot()
        {
            GameObject bullet = bulletPool[poolIndex];
            poolIndex++;
            if (poolIndex >= poolSize)
            {
                poolIndex = 0;
            }

            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
            bullet.SetActive(true);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = firePoint.right * bulletSpeed;
        }
    }
}

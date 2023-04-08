using System.Collections.Generic;
using Opsive.UltimateCharacterController.Items.Actions;
using UnityEngine;

namespace Shooting
{
    public class RifleShootingScript : MonoBehaviour
    {
        [SerializeField] private Transform firePoint;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private float bulletSpeed = 20f;
        [SerializeField] private float fireRate = 0.2f;
        [SerializeField] private int poolSize = 20;
        [SerializeField] private int maxAmmo = 10;
        [SerializeField] private GameObject muzzleFlashPrefab;

        private List<GameObject> bulletPool;
        private AmmoManager ammoManager;
        private float nextFireTime = 0f;
        private int poolIndex = 0;

        void Start()
        { 
            bulletPool = new List<GameObject>();
            for (int i = 0; i < poolSize; i++)
            {
                GameObject bullet = Instantiate(bulletPrefab, transform, true);
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
                ResetBullets();
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
            
            GameObject muzzleFlash = Instantiate(muzzleFlashPrefab, firePoint.position, firePoint.rotation);
            Destroy(muzzleFlash, 0.1f);
            
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
            bullet.SetActive(true);

            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.velocity = firePoint.forward * bulletSpeed;
            
            bullet.GetComponent<Collider>().enabled = true;
            bullet.GetComponent<BulletScript>().OnBulletHit.AddListener(() => { bullet.SetActive(false); });
        }

        void ResetBullets()
        {
            foreach (GameObject bullet in bulletPool)
            {
                if (bullet.activeSelf)
                {
                    bullet.SetActive(false);
                }
            }
            poolIndex = 0;
        }
    }
}

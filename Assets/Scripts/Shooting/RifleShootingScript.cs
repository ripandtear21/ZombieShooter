using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Shooting
{
    public class RifleShootingScript : MonoBehaviour
    {
        [SerializeField] private Transform firePoint;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private GameObject muzzleFlashPrefab;
        [SerializeField] private float bulletSpeed = 20f;
        [SerializeField] private float fireRate = 0.2f;
        [SerializeField] private int poolSize = 20;
        [SerializeField] private int maxAmmo = 10;
        [SerializeField] private int ammmoQuantity = 150;
        [SerializeField] private Animator playerAnimator;
        [SerializeField] private TextMeshProUGUI ammoText;
        [SerializeField] private TextMeshProUGUI reloadText;
        public AudioSource audioSource;
        public AudioClip shootSound;
        public AudioClip reloadSound;
        
        private List<GameObject> bulletPool;
        private AmmoManager ammoManager;
        private float nextFireTime = 0f;
        private int poolIndex = 0;
        private bool isReloading = false;
        private float reloadTime = 2.3f;
        private int currentAmmo;

        void Start()
        { 
            reloadText.text = "Reloading...";
            reloadText.enabled = false;
            bulletPool = new List<GameObject>();
            for (int i = 0; i < poolSize; i++)
            {
                GameObject bullet = Instantiate(bulletPrefab);
                bullet.SetActive(false);
                bulletPool.Add(bullet);
            }
            currentAmmo = maxAmmo;
            ammoText.text = currentAmmo.ToString() + "/" + ammmoQuantity.ToString();
            ammoManager = new AmmoManager(maxAmmo);
            AmmoManager.AddAmmo(ammmoQuantity);
        }

        void Update()
        {
            if (Time.time > nextFireTime && Input.GetButtonDown("Fire1") && ammoManager.Fire() && !isReloading)
            {
                Shoot();
                nextFireTime = Time.time + fireRate;
            }

            if (Input.GetKey(KeyCode.R) && ammoManager.GetCurrentAmmo() < maxAmmo && !isReloading)
            {
                isReloading = true;
                StartCoroutine(ReloadCoroutine());
            }
        }

        void Shoot()
        {
            if (muzzleFlashPrefab)
            {
                Instantiate(muzzleFlashPrefab, firePoint.position, firePoint.rotation);
                //Destroy(muzzleFlashPrefab, 0.1f);
            }
            GameObject bullet = bulletPool[poolIndex];
            poolIndex++;
            currentAmmo--;
            if (poolIndex >= poolSize)
            {
                poolIndex = 0;
            }
            if (audioSource && shootSound)
            {
                audioSource.PlayOneShot(shootSound);
            }

            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
            bullet.SetActive(true);

            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.velocity = firePoint.forward * bulletSpeed;
            
            ammoText.text = currentAmmo.ToString() + "/" + ammmoQuantity.ToString();
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
        IEnumerator ReloadCoroutine()
        {
            if (audioSource && reloadSound)
            {
                audioSource.clip = reloadSound;
                audioSource.Play();
            }
            
            reloadText.enabled = true;
            playerAnimator.SetBool("isReloading", true);
            yield return new WaitForSeconds(reloadTime);
            playerAnimator.SetBool("isReloading", false);
            Reload();
            isReloading = false;
        }
        void Reload()
        {
            reloadText.enabled = false;
            ammoManager.Reload();
            AmmoManager.ReduceAmmo(poolIndex);
            ammmoQuantity = AmmoManager.TotalAmmo;
            currentAmmo = maxAmmo;
            ammoText.text = maxAmmo.ToString() + "/" + ammmoQuantity.ToString();
            ResetBullets();
        }
    }
}

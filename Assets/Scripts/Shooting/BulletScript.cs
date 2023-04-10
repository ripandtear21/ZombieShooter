using EnemyScripts;
using UnityEngine;
using UnityEngine.Events;

namespace Shooting
{
    public class BulletScript : MonoBehaviour
    {
        public UnityEvent OnBulletHit;
        [SerializeField] private int damagePerShot = 30;
        [SerializeField] private GameObject particleEffect;

        void OnCollisionEnter(Collision collision)
        {
            OnBulletHit.Invoke();
            if (collision.gameObject.CompareTag("Zombie"))
            {
                Instantiate(particleEffect, transform.position, Quaternion.identity);
                ZombieScript zombie = collision.gameObject.GetComponent<ZombieScript>();
                if (zombie != null)
                {
                    zombie.TakeDamage(damagePerShot);
                }
            }
        }
    
    }
}

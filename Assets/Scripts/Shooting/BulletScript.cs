using EnemyScripts;
using UnityEngine;
using UnityEngine.Events;

namespace Shooting
{
    public class BulletScript : MonoBehaviour
    {
        public UnityEvent OnBulletHit;
        [SerializeField] private int damagePerShot = 30;

        void OnCollisionEnter(Collision collision)
        {
            OnBulletHit.Invoke();
            if (collision.gameObject.CompareTag("Zombie"))
            {
                ZombieScript zombie = collision.gameObject.GetComponent<ZombieScript>();
                if (zombie != null)
                {
                    zombie.TakeDamage(damagePerShot);
                }
            }
        }
    
    }
}

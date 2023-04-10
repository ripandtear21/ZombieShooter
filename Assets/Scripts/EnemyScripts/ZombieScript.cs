using Managers;
using UnityEngine;
using UnityEngine.AI;

namespace EnemyScripts
{
    public class ZombieScript : MonoBehaviour
    {
        [SerializeField] private int maxHealth = 100; 
        [SerializeField] private int currentHealth;
        [SerializeField] private Animator zombieAnimator;

        void Start()
        {
            currentHealth = maxHealth;
        }

        public void TakeDamage(int damage)
        {
            currentHealth -= damage; 
            if (currentHealth <= 0)
            {
                Die();
            }
        }

        void Die()
        {
            EventManager.ZombieDeath();
            zombieAnimator.enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponent<RagdollController>().SetRigidBodiesKinematic(false);
            gameObject.GetComponent<EnemyNavMeshController>().enabled = false;
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            //Destroy(gameObject); 
        }
    }
}

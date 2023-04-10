using Managers;
using UnityEngine;

namespace EnemyScripts
{
    public class EnemyAttackScript : MonoBehaviour
    {
        [SerializeField] private float attackDistance = 1.5f;
        [SerializeField] private float attackDamage = 50f; 
        [SerializeField] private float attackRate = 1f; 

        private Animator anim; 
        private Transform player; 
        private bool playerInRange; 
        private float nextAttackTime; 

        void Awake() {
            anim = GetComponent<Animator>(); 
            player = GameObject.FindGameObjectWithTag("Player").transform; 
        }

        void Update() {
        
            float distance = Vector3.Distance(transform.position, player.position);
            if (distance < attackDistance) {
                playerInRange = true;
                if (Time.time > nextAttackTime) {
                    Invoke("Attack", 0.5f);
                    anim.SetTrigger("attack");
                    nextAttackTime = Time.time + attackRate;
                }
            }
            else {
                playerInRange = false;
            }
        }
        void Attack() {
            EventManager.ZombieDamage(attackDamage);
        }
    }
}

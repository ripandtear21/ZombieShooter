using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    public int maxHealth = 100; 
    public int currentHealth;
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
        zombieAnimator.enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<RagdollController>().SetRigidBodiesKinematic(false);
        //Destroy(gameObject); 
    }
}

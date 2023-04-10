using System;
using UnityEngine;

namespace Managers
{
    public class EventManager : MonoBehaviour
    {
        public static Action<float> OnZombieDamage;
    
        public static void ZombieDamage(float damage)
        {
            OnZombieDamage?.Invoke(damage);
        }
        public static Action OnZombieDeath;
        
        public static void ZombieDeath()
        {
            OnZombieDeath?.Invoke();
        }
        public static Action OnPlayerDeath;
        
        public static void PlayerDeath()
        {
            OnPlayerDeath?.Invoke();
        }
        
    }
}

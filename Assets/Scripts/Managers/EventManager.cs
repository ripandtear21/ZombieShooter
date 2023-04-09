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
    }
}

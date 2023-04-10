using System;
using Managers;
using TMPro;
using UnityEngine;

namespace UI
{
    public class KillCounterScript : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI counterText; 
        private int killCount;

        private void OnEnable()
        {
            EventManager.OnZombieDeath += AddKill;
        }

        private void OnDisable()
        {
            EventManager.OnZombieDeath -= AddKill;
        }

        private void Start()
        {
            killCount = 0;
            counterText.text = killCount.ToString();
        }
    
    
        private void AddKill()
        {
            killCount++;
            counterText.text = killCount.ToString();
        }
    }
}

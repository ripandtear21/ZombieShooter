using System;
using Managers;
using UnityEngine;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        public GameObject deathPanel;
        public GameObject titlePanel;
    
        private void OnEnable()
        {
            EventManager.OnPlayerDeath += ShowDeathUI;
        }

        private void OnDisable()
        {
            EventManager.OnPlayerDeath -= ShowDeathUI;
        }

        void Start()
        {
            deathPanel.SetActive(false);
            titlePanel.SetActive(true);
            Time.timeScale = 0;
        }
        public void GameStart()
        {
            titlePanel.SetActive(false);
            Time.timeScale = 1;
        }

        public void ShowDeathUI()
        {
            deathPanel.SetActive(true);
            Time.timeScale = 0;
        }

        public void RestartGame()
        {
            Time.timeScale = 1;
            Application.LoadLevel(Application.loadedLevel);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}

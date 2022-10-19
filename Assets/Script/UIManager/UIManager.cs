using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using General;

namespace Player
{
    public class UIManager : MonoBehaviour
    {
        public GameObject pauseMenuUI;
        public GameObject deathMenuUI;
        [SerializeField] bool gameIsPaused = true;
        void Update()
        {
            // if (HealthManager.IsDead())
            // {
            //     Invoke("DeathMenu", 1.25f);
            // }
            // else if (Input.GetKeyDown("escape"))
            // {
            //     if (gameIsPaused)
            //     {
            //         Resume();
            //     }
            //     else
            //     {
            //         Pause();
            //     }
            // }
        }

        void Pause()
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            gameIsPaused = true;
        }

        void DeathMenu()
        {
            deathMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }

        public void Resume()
        {
            pauseMenuUI.SetActive(false);
            deathMenuUI.SetActive(false);
            Time.timeScale = 1f;
            gameIsPaused = false;
        }

        public void LoadMenu()
        {
            Debug.Log("Loading Main Menu...");
            //Do this later since I don't have main menu yet.
        }

        public void Quit()
        {
            Debug.Log("Quitting Game (Only works on prod)");
            Application.Quit();
        }
    }

}

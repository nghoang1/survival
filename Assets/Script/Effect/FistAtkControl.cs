using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ControlledCamera;

namespace Player
{
    public class FistAtkControl : MonoBehaviour
    {
        public GameObject fistUp;
        public GameObject fistDown;
        public GameObject fistForward;
        public CameraControl cameraControl;

        Movement playerMovement;

        void Start()
        {
            playerMovement = GetComponent<Movement>();
        }

        void HideAllFist()
        {
            fistDown.SetActive(false);
            fistUp.SetActive(false);
            fistForward.SetActive(false);
            cameraControl.StopShake();
            playerMovement.AllowRotation(true);
        }

        void ShowEffect(string fistType)
        {
            HideAllFist();
            if (fistType == "")
            {
                return;
            }

            switch (fistType)
            {
                case "up":
                    fistUp.SetActive(true);
                    break;
                case "down":
                    fistDown.SetActive(true);
                    break;
                case "forward":
                    fistForward.SetActive(true);
                    break;
            }
            cameraControl.Shake();
            playerMovement.AllowRotation(false);
        }
    }
}

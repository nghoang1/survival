using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using General;

namespace Player
{
    public class Dodge : MonoBehaviour
    {
        public float inputTime;

        Animator anim;
        RayCastCollision rayCastCollision;
        Movement movement;
        int inputCount = 0;
        string lastDirection = "";

        // Start is called before the first frame update
        void Start()
        {
            anim = GetComponent<Animator>();
            rayCastCollision = GetComponent<RayCastCollision>();
            movement = GetComponent<Movement>();
        }

        // Update is called once per frame
        void Update()
        {
            string direction = "";
            if (Input.GetKeyUp(KeyCode.C))
            {
                direction = "Left";
            }
            else if (Input.GetKeyUp(KeyCode.C))
            {
                direction = "Right";
            }
            else
            {
                return;
            }
            if (lastDirection == direction || lastDirection == "")
            {
                inputCount++;
                lastDirection = direction;
                if (inputCount == 1)
                {
                    StartCoroutine(Timeout());
                }
            }
            else
            {
                inputCount = 0;
            }
            // Should be 2 here, double press arrow key on controller to dodge
            // but I have problem determine whether user wants to simply move or dodge
            // It can be resolve if user using controller (movement stick vs arrow keys)
            // Make it Q and E to dodge and only need to press once on PC for now
            if (inputCount == 1)
            {
                rayCastCollision.Enable(false);
                // movement.Rotate("Right");
                movement.AllowRotation(false);
                if (lastDirection == "Left")
                {
                    anim.SetInteger("Dodge", 1);
                }
                else
                {
                    anim.SetInteger("Dodge", 1);
                }
                ResetState();
                return;
            }
        }

        void DoneDodge()
        {
            rayCastCollision.Enable(true);
            movement.AllowRotation(true);
        }

        void ResetState()
        {
            inputCount = 0;
            lastDirection = "";
        }

        IEnumerator Timeout()
        {
            yield return new WaitForSeconds(inputTime);
            ResetState();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using General;

namespace Player
{
    public class Movement : MonoBehaviour
    {
        Animator anim;
        Attack attack;
        bool shouldRotate = true;
        HealthManager healthManager;

        // Start is called before the first frame update
        void Start()
        {
            anim = GetComponent<Animator>();
            attack = GetComponent<Attack>();
            healthManager = GetComponent<HealthManager>();
        }

        // Update is called once per frame
        void Update()
        {
            if (healthManager.IsDead())
            {
                return;
            }

            float x = transform.position.x;
            float h = Input.GetAxis("Horizontal");
            anim.SetFloat("Movement", h);

            // in case x axis changes
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
            if (h != 0 && shouldRotate == true)
            {
                Rotate(h < 0 ? "Left" : "Right");
            }
        }

        public void Rotate(string direction)
        {
            switch (direction)
            {
                case "Left":
                    transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 180, transform.rotation.z));
                    break;
                case "Right":
                    transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 0, transform.rotation.z));
                    break;
            }
        }

        public void AllowRotation(bool enable)
        {
            shouldRotate = enable;
        }

        public void SetHit()
        {
            if (attack.IsAttacking() == true)
            {
                return;
            }
            anim.SetInteger("Hit", Random.Range(1, 6));
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Attack : MonoBehaviour
    {
        public GameObject gunL;
        public GameObject gunR;
        Animator anim;
        int atk = 0;
        bool allowAtk = true;
        bool isAttacking = false;

        // Start is called before the first frame update
        void Start()
        {
            anim = GetComponent<Animator>();
            gunL.SetActive(false);
            gunR.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.Z) && allowAtk)
            {
                atk++;
                isAttacking = true;
                atk = atk > 3 ? 1 : atk;
                anim.SetInteger("Attack", atk);
                allowAtk = false;
            }
        }

        public bool IsAttacking()
        {
            return isAttacking;
        }

        public void Done()
        {
            allowAtk = true;
            isAttacking = false;
            anim.SetInteger("Attack", 0);
        }
    }
}

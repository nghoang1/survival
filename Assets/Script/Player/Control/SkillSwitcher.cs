using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{

    public class SkillSwitcher : MonoBehaviour
    {
        public Animator skillPanelAnim;
        Animator anim;
        Attack attack;
        int attackType = 0;

        // Start is called before the first frame update
        void Start()
        {
            anim = GetComponent<Animator>();
            attack = GetComponent<Attack>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                skillPanelAnim.SetTrigger("Rotate");
                attackType = attackType + 1 > 2 ? 0 : attackType + 1;
                anim.SetInteger("AttackType", attackType);
                if (attackType == 1)
                {
                    // Gun
                    attack.gunL.SetActive(true);
                    attack.gunR.SetActive(true);
                }
                else
                {
                    attack.gunL.SetActive(false);
                    attack.gunR.SetActive(false);
                }
                // Reset combo chain
                attack.Done();
                return;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                skillPanelAnim.SetTrigger("Reverse");
                attackType = attackType - 1 < 0 ? 2 : attackType - 1;
                anim.SetInteger("AttackType", attackType);
                if (attackType == 1)
                {
                    // Gun
                    attack.gunL.SetActive(true);
                    attack.gunR.SetActive(true);
                }
                else
                {
                    attack.gunL.SetActive(false);
                    attack.gunR.SetActive(false);
                }
                // Reset combo chain
                attack.Done();
                return;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace General
{
    public class HealthManager : MonoBehaviour
    {
        public float maxHealth = 100;
        public Slider healthBar;
        Animator anim;

        void Start()
        {
            anim = GetComponent<Animator>();
            healthBar.maxValue = maxHealth;
            healthBar.value = maxHealth;
        }

        void Die()
        {
            anim.SetBool("isDead", true);
        }

        public bool IsDead()
        {
            return healthBar.value <= 0;
        }

        public void TakeDamage(float damageTake)
        {
            healthBar.value -= damageTake;
            if (IsDead())
            {
                Die();
            }
        }
    }
}

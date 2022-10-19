using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyControl : MonoBehaviour
    {
        public Transform player;
        public float detectRange;
        public float stopRange;
        public int maxAtk;

        Animator anim;
        Rigidbody rb;

        void Start()
        {
            anim = GetComponent<Animator>();
            rb = GetComponent<Rigidbody>();
        }

        void Update()
        {
            bool inStopRange = Vector3.Distance(player.position, transform.position) < stopRange;
            if (inStopRange == true)
            {
                anim.SetBool("Chase", false);
                anim.SetInteger("Attack", Random.Range(1, maxAtk + 1));
                return;
            }

            bool inDetectRange = Vector3.Distance(player.position, transform.position) < detectRange;
            if (inDetectRange == true)
            {
                transform.rotation = Quaternion.LookRotation(player.position - transform.position, transform.up);
                anim.SetBool("Chase", true);
            }
            else
            {
                anim.SetBool("Chase", false);
            }
        }

        public void KnockBack(int style)
        {
            anim.SetInteger("KnockBack", style);
        }

        public void SendFlying()
        {

        }

        void OnDrawGizmosSelected()
        {
            Vector3 start = transform.position;
            Vector3 end = transform.position;

            start.y = transform.position.y + detectRange;
            end.y = transform.position.y - detectRange;
            DebugExtension.DrawCapsule(start, end, Color.green, detectRange);

            start.y = transform.position.y + stopRange;
            end.y = transform.position.y - stopRange;
            DebugExtension.DrawCapsule(start, end, Color.red, stopRange);
        }
    }
}

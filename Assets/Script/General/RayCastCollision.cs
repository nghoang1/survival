using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace General
{
    public class RayCastCollision : MonoBehaviour
    {
        public LayerMask collideWith;

        CapsuleCollider capsuleCollider;
        Animator anim;
        Vector3 center;
        bool shouldCheckCollision = true;

        // Start is called before the first frame update
        void Start()
        {
            capsuleCollider = GetComponent<CapsuleCollider>();
            anim = GetComponent<Animator>();
            center = transform.TransformPoint(capsuleCollider.center);
        }

        void FixedUpdate()
        {
            if (shouldCheckCollision && RayCast(transform.forward))
            {
                anim.applyRootMotion = false;
            }
            else
            {
                anim.applyRootMotion = true;
            }
        }

        bool RayCast(Vector3 direction)
        {
            center = transform.TransformPoint(capsuleCollider.center);
            Ray ray = new Ray(center, direction);
            return Physics.Raycast(ray, capsuleCollider.radius, collideWith, QueryTriggerInteraction.Ignore);
        }

        public void Enable(bool enabled)
        {
            shouldCheckCollision = enabled;
        }

        void OnDrawGizmosSelected()
        {
            // Debug.DrawLine(center, center + transform.forward * capsuleCollider.radius, Color.blue);
        }
    }
}

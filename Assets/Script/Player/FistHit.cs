using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistHit : MonoBehaviour
{
    public FistCollider fistCollider;

    void Hit(string atkName)
    {
        fistCollider.DealDamage(atkName);
    }
}

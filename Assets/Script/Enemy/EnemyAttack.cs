using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using General;

public class EnemyAttack : MonoBehaviour
{
    public float damage;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            player = null;
        }
    }

    void Hit()
    {
        if (player != null)
        {
            Movement playerMovement = player.GetComponent<Movement>();
            playerMovement.SetHit();
            
            HealthManager healthManager = player.GetComponent<HealthManager>();
            healthManager.TakeDamage(damage);
        }
    }
}

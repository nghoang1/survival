using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using General;
using Enemy;

public class FistCollider : MonoBehaviour
{
    public float fistDamage;
    [Range(0, 100)]
    public int knockChance;
    public CinemachineVirtualCamera vcam;
    public float fovZoom;
    public float zoomDuration;
    [Range(0, 1)]
    public float timeSlowAmount; // 1 -> no slow motion

    List<GameObject> enemiesInRange;
    float oldFov;

    // Start is called before the first frame update
    void Start()
    {
        oldFov = vcam.m_Lens.FieldOfView;
        enemiesInRange = new List<GameObject>();
    }

    public void DealDamage(string atkName)
    {
        bool shouldKnockBack = Random.Range(0, 100) <= knockChance;
        enemiesInRange.ForEach(enemy =>
        {
            HealthManager healthManager = enemy.GetComponent<HealthManager>();
            EnemyControl enemyControl = enemy.GetComponent<EnemyControl>();
            if (healthManager != null)
            {
                StopCoroutine(ZoomCoroutine());
                if (shouldKnockBack == true)
                {
                    int knockBackStyle = 1;
                    switch(atkName)
                    {
                        case "FistForward":
                            knockBackStyle = 1;
                            break;
                        case "FistDown":
                            knockBackStyle = 2;
                            break;
                        case "FistUp":
                            knockBackStyle = 3;
                            break;
                    }
                    enemyControl.KnockBack(knockBackStyle);
                    StartCoroutine(ZoomCoroutine());
                }

                healthManager.TakeDamage(fistDamage);
            }
        });
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemiesInRange.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemiesInRange.Remove(other.gameObject);
        }
    }

    IEnumerator ZoomCoroutine()
    {
        vcam.m_Lens.FieldOfView = fovZoom;
        Time.timeScale = timeSlowAmount;
        yield return new WaitForSeconds(zoomDuration);
        vcam.m_Lens.FieldOfView = oldFov;
        Time.timeScale = 1;
    }
}

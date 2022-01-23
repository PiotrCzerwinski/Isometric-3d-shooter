using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasCloud : MonoBehaviour
{
    private float radius;
    private int damage = 10;
    private bool coolingDown = false;
    private float coolDownTime = 1f;
    private float nextDamageTick;
    private GameObject target;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        radius = GetComponent<SphereCollider>().radius;
    }
    private void Update()
    {
        radius = GetComponent<SphereCollider>().radius;
    }
    public void dealDamage()
    {
        target.GetComponent<HealthSystem>().currentHealth -= damage;
        target.GetComponent<HealthSystem>().lastTimeHit = Time.time;
        //Debug.Log("Dealing damage");

    }
    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player") && !coolingDown){
            
            dealDamage();
            nextDamageTick = coolDownTime;
            coolingDown = true;

        } else {
            nextDamageTick -= Time.deltaTime;
            if (nextDamageTick <= 0)
                coolingDown = false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}

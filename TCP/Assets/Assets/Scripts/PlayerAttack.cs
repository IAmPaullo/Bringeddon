using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] float fireRate;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform meshObj;
    [SerializeField] int damage;
    [SerializeField] int maxHealth;
    int health;
    float nextFireTime;
    void Start()
    {
        nextFireTime = Time.time;
        health = maxHealth;
    }

    void Update()
    {
    }

    public void ReceiveDamage(int value)
    {
        Debug.Log("Hit");
        health -= value;
        if(health<= 0)
        {
            health = 0;
            Debug.Log("Dead");
            GetComponent<PlayerInput>().enabled = false;
        }
    }

    void OnFire()
    {
        if (nextFireTime <= Time.time)
        {
            nextFireTime = Time.time + 1 / fireRate;
            Transform projectile = Instantiate(bulletPrefab, transform.position, Quaternion.identity).transform;
            projectile.forward = meshObj.forward;
            projectile.GetComponent<Projectile>().SetDamage(damage);
        }        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Attack"))
        {
            other.enabled = false;
            ReceiveDamage(other.GetComponentInParent<Enemy>().GetDamage());   
        }
    }
}

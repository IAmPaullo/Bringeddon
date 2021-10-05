using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] float fireRate;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform gun;
    [SerializeField] Transform meshObj;
    [SerializeField] int damage;
    [SerializeField] int maxHealth;
    Animator anim;
    int health;
    float nextFireTime;
    void Start()
    {
        anim = meshObj.GetComponent<Animator>();
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
        AudioManager.Play("AnaDano");
        if (health<= 0)
        {
            health = 0;
            anim.SetTrigger("Death");
            GetComponent<PlayerInput>().enabled = false;
        }
    }

    void OnFire()
    {
        if (nextFireTime <= Time.time)
        {
            nextFireTime = Time.time + 1 / fireRate;
            Transform projectile = Instantiate(bulletPrefab, gun.position, Quaternion.identity).transform;
            projectile.forward = meshObj.forward;
            projectile.GetComponent<Projectile>().SetDamage(damage);
            anim.SetTrigger("Shoot");
            AudioManager.Play("AnaTiro");
        }        
    }

    void OnChargeFire()
    {
        Debug.Log("Charge");
        if (nextFireTime <= Time.time)
        {
            nextFireTime = Time.time + 1 / (fireRate / 2);
            Transform projectile = Instantiate(bulletPrefab, gun.position, Quaternion.identity).transform;
            projectile.forward = (meshObj.forward).normalized;
            projectile.GetComponent<Projectile>().SetDamage(damage);

            projectile = Instantiate(bulletPrefab, gun.position, Quaternion.identity).transform;
            projectile.forward = (meshObj.forward + meshObj.right).normalized;
            projectile.GetComponent<Projectile>().SetDamage(damage);

            projectile = Instantiate(bulletPrefab, gun.position, Quaternion.identity).transform;
            projectile.forward = (meshObj.forward - meshObj.right).normalized;
            projectile.GetComponent<Projectile>().SetDamage(damage);
            anim.SetTrigger("Shoot");
            AudioManager.Play("AnaTiro");
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

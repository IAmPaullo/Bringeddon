using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Beam Config")]
    [SerializeField] float range, lockTime, chargeTime, cooldown;
    [SerializeField] int health, damage;
    [SerializeField] Status status;
    [SerializeField] Transform beam;
    [SerializeField] Transform firePoint;
    Vector3 target;

    [Header("Beam Config")]
    [SerializeField] GameObject enemyPref;
    Transform player;
    float nextLockTime, nextChargeTime, nextCooldown;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        status = Status.Idle;
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Vector3.Distance(transform.position, player.position));
        switch (status)
        {
            case Status.Idle:
                anim.SetBool("Lock", false);
                beam.gameObject.SetActive(false);
                if (Vector3.Distance(transform.position, player.position) < range)
                {
                    status = Status.Locking;
                    nextLockTime = Time.time + lockTime;
                }
                break;
            case Status.Locking:
                anim.SetBool("Lock", true);
                Vector3 look = (target - transform.position).normalized;
                transform.LookAt(new Vector3(look.x,transform.position.y, look.z)+transform.position);
                target = player.position;
                if (Vector3.Distance(transform.position, player.position) > range)
                {
                    status = Status.Idle;
                }
                if (Time.time >= nextLockTime)
                {
                    nextChargeTime = Time.time + chargeTime;
                    status = Status.Charging;
                    beam.gameObject.SetActive(true);
                }
                break;
            case Status.Charging:
                anim.SetBool("Shoot",true);
                if(Time.time >= nextChargeTime)
                {
                    status = Status.Fire;
                }
                break;
            case Status.Fire:
                nextCooldown = Time.time + cooldown;
                RaycastHit hit;
                Vector3 dir = (target - firePoint.position).normalized;
                if (Physics.Raycast(firePoint.position, dir, out hit))
                {
                    beam.position = hit.point;
                    if (hit.transform.gameObject == player.gameObject)
                    {
                        player.GetComponent<PlayerAttack>().ReceiveDamage(damage);
                    }
                    else if(hit.collider.CompareTag("Ground"))
                    {
                        Instantiate(enemyPref, beam.position, Quaternion.identity);
                    }
                }
                status = Status.Cooldown;
                anim.SetBool("Shoot", false);
                break;
            case Status.Cooldown:                
                if (Time.time >= nextCooldown)
                {
                    beam.gameObject.SetActive(false);
                    beam.position = firePoint.position;
                    anim.SetTrigger("Reset");
                    status = Status.Idle;
                }
                break;
            case Status.Dead:

                break;
        }
    }
    public void ReceiveDamage(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            status = Status.Dead;
            anim.SetTrigger("Death");
        }
    }
    enum Status
    {
        Idle, Locking, Charging, Fire, Cooldown, Dead
    }
}

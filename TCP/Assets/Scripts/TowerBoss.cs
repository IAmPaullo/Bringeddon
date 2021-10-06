using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBoss : MonoBehaviour
{
    [Header("Beam Config")]
    [SerializeField] float range, lockTime, chargeTime, cooldown;
    [SerializeField] int damage;
    [SerializeField] Status status;
    [SerializeField] Transform beam;
    [SerializeField] Transform firePoint;
    Vector3 target;

    [Header("Beam Config")]
    [SerializeField] GameObject enemyPref;
    Transform player;
    float nextLockTime, nextChargeTime, nextCooldown;
    [SerializeField] Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        status = Status.Idle;
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        switch (status)
        {
            case Status.Idle:
                beam.gameObject.SetActive(false);
                if (Vector3.Distance(transform.position, player.position) < range)
                {
                    status = Status.Locking;
                    nextLockTime = Time.time + lockTime;
                }
                break;
            case Status.Locking:
                Vector3 look = (target - transform.position).normalized;
                transform.LookAt(look + transform.position);
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
                if (Time.time >= nextChargeTime)
                {
                    status = Status.Fire;
                }
                break;
            case Status.Fire:
                if (anim != null)
                    anim.SetTrigger("Angry");
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
                    else if (hit.collider.CompareTag("Ground"))
                    {
                        Instantiate(enemyPref, beam.position, Quaternion.identity);
                    }
                }
                status = Status.Cooldown;
                break;
            case Status.Cooldown:
                if (Time.time >= nextCooldown)
                {
                    beam.gameObject.SetActive(false);
                    beam.position = firePoint.position;
                    status = Status.Idle;
                }
                break;
            case Status.Dead:

                break;
        }
    }
    public void Death()
    {
        status = Status.Dead;
    }
    enum Status
    {
        Idle, Locking, Charging, Fire, Cooldown, Dead
    }
}

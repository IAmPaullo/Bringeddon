using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] float range, lockTime, chargeTime, cooldown;
    [SerializeField] int damage;
    [SerializeField] Status status;
    [SerializeField] Transform beam;
    [SerializeField] Transform firePoint;
    Transform player;
    Vector3 target;
    float nextLockTime, nextChargeTime, nextCooldown;
    // Start is called before the first frame update
    void Start()
    {
        status = Status.Idle;
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
            Debug.Log(Vector3.Distance(transform.position, player.position));
        switch (status)
        {
            case Status.Idle:                
                if (Vector3.Distance(transform.position, player.position) < range)
                {
                    status = Status.Locking;
                    nextLockTime = Time.time + lockTime;
                }
                break;
            case Status.Locking:
                target = player.position;
                if (Vector3.Distance(transform.position, player.position) > range)
                {
                    status = Status.Idle;
                }
                if (Time.time >= nextLockTime)
                {
                    nextChargeTime = Time.time + chargeTime;
                    status = Status.Charging;
                }
                break;
            case Status.Charging:
                if(Time.time >= nextChargeTime)
                {
                    status = Status.Fire;
                }
                break;
            case Status.Fire:
                Debug.Log("FIRE!!");
                beam.position = target;
                nextCooldown = Time.time + cooldown;
                RaycastHit hit;
                Vector3 dir = (target - transform.position).normalized;
                if (Physics.Raycast(transform.position,dir,out hit))
                {
                    if (hit.transform.gameObject == player.gameObject)
                        player.GetComponent<PlayerAttack>().ReceiveDamage(damage);
                }
                status = Status.Cooldown;
                break;
            case Status.Cooldown:
                beam.position = firePoint.position;
                if (Time.time >= nextCooldown)
                {
                    status = Status.Idle;
                }
                break;
        }
    }

    enum Status
    {
        Idle, Locking, Charging, Fire, Cooldown
    }
}

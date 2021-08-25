using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent navMesh;
    Vector3 target;
    [SerializeField]Status status;
    [SerializeField] float walkDelay;
    [SerializeField] float perception;
    [SerializeField] float attackRange;
    [SerializeField] float attackSpeed;
    [SerializeField] float attackDuration;
    [SerializeField] float walkDistance;
    Vector3 startPos;
    Transform player;
    float nextAttackTime;
    float nextWalkTime;
    float endAttackTime;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        status = Status.Idle;
        navMesh = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        switch (status)
        {
            case Status.Idle:
                CheckPerception(); 
                if (Time.time >= nextWalkTime)
                {
                    status = Status.Walk;
                    float x = Random.Range(-walkDistance, walkDistance);
                    float y = Random.Range(-walkDistance, walkDistance);
                    target = new Vector3(x, 0, y) + startPos;
                }
                break;
            case Status.Walk:
                CheckPerception();
                if (Vector3.Distance(transform.position, target) < 0.2f)
                {
                    status = Status.Idle;
                    nextWalkTime = Time.time + walkDelay;
                }
                break;
            case Status.Follow:
                target = player.position;
                if (Vector3.Distance(transform.position, player.position) > perception)
                {
                    status = Status.Idle;
                    target = transform.position;
                }
                else if (Vector3.Distance(transform.position, player.position) < attackRange)
                {
                    status = Status.ToAttack;
                    nextAttackTime = Time.time + attackSpeed;
                }
                break;
            case Status.ToAttack:
                if (Time.time >= nextAttackTime)
                {
                    nextAttackTime = Time.time + attackSpeed;
                    status = Status.Attacking;
                    endAttackTime = Time.time + attackDuration;
                }
                break;
            case Status.Attacking:
                if (Time.time >= endAttackTime)
                {
                    status = Status.Idle;
                }
                break;
        }
        navMesh.destination = target;
    }
    void CheckPerception()
    {
        if (Vector3.Distance(transform.position,player.position) < perception)
        {
            status = Status.Follow;
            target = player.position;
        }
    }
    enum Status
    {
        Idle, Walk, Follow, ToAttack, Attacking
    }
}

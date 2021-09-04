using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float walkDelay;
    [SerializeField] float walkDistance;
    Vector3 target;
    NavMeshAgent navMesh;
    Vector3 startPos;
    Transform player;

    [Header("Attack")]
    [SerializeField] int maxHealth;
    [SerializeField] int damage;
    [SerializeField] float attackRange;
    [SerializeField] float attackSpeed;
    [SerializeField] float attackDuration;
    [SerializeField] float attackCooldown;
    [SerializeField] float perception;
    [SerializeField] Collider attackCollider;
    int health;
    [Header("Debug")]
    [SerializeField] Status status;
    float nextAttackTime;
    float nextWalkTime;
    float endAttackTime;
    float endAttackCooldown;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        startPos = transform.position;
        status = Status.Idle;
        navMesh = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
        attackCollider.enabled = false;
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
                target = player.position + (transform.position - player.position).normalized;
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
                    attackCollider.enabled = true;
                }
                break;
            case Status.Attacking:
                if (Time.time >= endAttackTime)
                {
                    status = Status.Waiting;
                    endAttackCooldown = Time.time + attackCooldown;
                }
                break;
            case Status.Waiting:
                attackCollider.enabled = false;
                if (Time.time >= endAttackCooldown)
                {
                    status = Status.Idle;
                }
                break;
            case Status.Dead:
                target = transform.position;
                gameObject.layer = 10;
                attackCollider.enabled = false;
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
        Idle, Walk, Follow, ToAttack, Attacking,
        Waiting, Dead
    }

    public int GetDamage()
    {
        return damage;
    }
    public void ReceiveDamage(int value)
    {
        Debug.Log("Hit");
        health -= value;
        if (health <= 0)
        {
            health = 0;
            Debug.Log("Dead");
            status = Status.Dead;
        }
    }
}

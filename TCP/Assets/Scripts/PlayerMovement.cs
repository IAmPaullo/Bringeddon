using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Walk Config")]
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;
    [Header("Dash Config")]
    [SerializeField] float dashSpeed;
    [SerializeField] float dashCooldown;
    [SerializeField] float dashDist;
    [Header("Extra Config")]
    [SerializeField] Transform meshObj;
    //componentes
    Rigidbody rb;
    //aux
    Vector3 velocity;
    Vector3 rotation;
    Vector3 aim;
    [SerializeField] Vector3 dashPos;
    float nextDashTime;
    Animator anim;


    [SerializeField] State state;
    

    void Start()
    {
        anim = meshObj.GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        state = State.Idle;
        nextDashTime = Time.time;
    }

    void FixedUpdate()
    {
        Rotation();
        switch (state)
        {
            case State.Idle:
                rb.velocity = new Vector3(0,rb.velocity.y,0);
                anim.SetBool("Walk",false);
                break;
            case State.Walk:
                rb.velocity = velocity * moveSpeed * Time.deltaTime;
                anim.SetBool("Walk",true);
                break;
            case State.Dash:
                if (Vector3.Distance(transform.position, dashPos) < 0.25f)
                {
                    state = State.Idle;
                    break;
                }
                rb.velocity = (dashPos - transform.position).normalized * dashSpeed * Time.deltaTime;
                break;
        }
    }

    void Rotation()
    {
        if (aim == Vector3.zero && velocity != Vector3.zero)
            rotation = velocity;
        else
            rotation = aim;
        if (rotation != Vector3.zero)
        {
            Quaternion dirQ = Quaternion.LookRotation(rotation);
            Quaternion slerp = Quaternion.Slerp(meshObj.rotation, dirQ, rotation.magnitude * rotationSpeed * Time.deltaTime);
            meshObj.GetComponent<Rigidbody>().MoveRotation(slerp);
        }
    }

    public void OnMove(InputValue input)
    {
        Vector2 inputVec = input.Get<Vector2>();
        velocity = new Vector3(inputVec.x, 0, inputVec.y);
        if (state == State.Idle && inputVec != Vector2.zero)
            state = State.Walk;
        else if(inputVec == Vector2.zero && state == State.Walk)
            state = State.Idle;
    }

    public void OnAim(InputValue input)
    {
        Vector2 inputVec = input.Get<Vector2>();
        aim = new Vector3(inputVec.x, 0, inputVec.y);
    }

    public void OnDash()
    {
        if (nextDashTime <= Time.time)
        {
            nextDashTime = Time.time + dashCooldown;
            RaycastHit hit;
            Vector3 dir = velocity;
            if (dir == Vector3.zero)
                dir = meshObj.forward;
            if (Physics.Raycast(transform.position, dir, out hit, dashDist))
            {
                dashPos = hit.point - dir;
            }
            else
                dashPos = dir * dashDist + transform.position;
            AudioManager.Play("AnaDash");
            state = State.Dash;
        }
    }
    
    enum State
    {
        Idle, Walk, Dash
    }
}

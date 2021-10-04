using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed;
    [SerializeField] float maxDist;
    int damage;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = transform.forward * speed * Time.deltaTime;
        maxDist -= rb.velocity.magnitude * Time.deltaTime;
        if (maxDist <= 0)
            Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            collision.transform.GetComponent<Enemy>().ReceiveDamage(damage);
        } 
        else if (collision.transform.CompareTag("Tower"))
        {
            collision.transform.GetComponent<Tower>().ReceiveDamage(damage);
        }
        Destroy(gameObject);
    }

    public void SetDamage(int _dmg)
    {
        damage = _dmg;
    }
}

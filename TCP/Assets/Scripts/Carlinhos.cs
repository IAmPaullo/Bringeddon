using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carlinhos : MonoBehaviour
{
    [SerializeField] TowerBoss[] towers;
    [SerializeField] int health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReceiveDamage(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            foreach(TowerBoss t in towers)
            {
                t.Death();
            }
        }
    }

    public void Angry()
    {
        AudioManager.Play("CarlinhosRisada");
    }
}

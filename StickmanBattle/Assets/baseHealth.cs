using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 100;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Debug.Log("Victory");
        }
    }
}

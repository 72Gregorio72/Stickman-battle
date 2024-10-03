using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    public float startAttackRange;
    Boolean attacked = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position + new Vector3(2f, 0, 0), startAttackRange);
        
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy") && !attacked)
            {
                Debug.Log("Attack");
                attacked = true;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position + new Vector3(2f, 0, 0), startAttackRange);
    }
}

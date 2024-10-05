using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    public float startAttackRange;
    public Boolean attacked = false;

    public String target;
    public int damage;
    public int direction;

    public float AttackDistance;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position + new Vector3(AttackDistance * direction, 0, 0), startAttackRange);
        
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag(target) && !attacked)
            {
                hitCollider.GetComponent<UnitHealth>().TakeDamage(damage);
                attacked = true;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position + new Vector3(AttackDistance * direction, 0, 0), startAttackRange);
    }
}

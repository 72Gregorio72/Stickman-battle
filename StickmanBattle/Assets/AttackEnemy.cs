using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    public float AttackRangeX;
    public float AttackRangeY;
    public Boolean attacked = false;

    public String target;
    public int damage;
    public int direction;

    public float offsetX;
    public float offsetY;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(transform.position + new Vector3(offsetX * direction, offsetY, 0), new Vector2(AttackRangeX, AttackRangeY), 0);
        
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag(target) && !attacked)
            {
                var unitHealth = hitCollider.GetComponent<UnitHealth>();
                if (unitHealth != null)
                {
                    unitHealth.TakeDamage(damage);
                } else {
                    var baseHealth = hitCollider.GetComponent<baseHealth>();
                    if (baseHealth != null)
                    {
                        baseHealth.TakeDamage(damage);
                    }
                }
                attacked = true;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position + new Vector3(offsetX * direction, offsetY, 0), new Vector3(AttackRangeX, AttackRangeY, 1));
    }
}

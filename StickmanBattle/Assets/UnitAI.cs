using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAI : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject attackPrefab;
    public float speed;
    public float attackSpeed;
    public float attackRange;
    private float timer = 0;

    public String target;

    public int direction;
    public float offset;
    public int id;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed * direction, 0);
        
        //Range
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position + new Vector3(offset, 0, 0), attackRange);

        timer += Time.deltaTime;
        if(timer >= 0.1){
            attackPrefab.SetActive(false);
        }

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag(target))
            {
                rb.velocity = new Vector2(0, 0);
                
                
                if(timer >= attackSpeed){
                    attackPrefab.SetActive(true);
                    timer = 0;
                    attackPrefab.GetComponent<AttackEnemy>().attacked = false;
                }
                
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + new Vector3(offset, 0, 0), attackRange);
    }
}

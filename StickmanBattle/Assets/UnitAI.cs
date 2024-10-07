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
    public float attackRangeX;
    public float attackRangeY;
    private float timer = 0;
    int animationTimer = 0;
    public String target;

    public int direction;
    public float offsetX;
    public float offsetY;
    public int id;

    private Animator anim;

    //public float animationTime;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed * direction, 0);
        
        //Range
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(transform.position + new Vector3(offsetX, offsetY, 0), new Vector2(attackRangeX, attackRangeY), 0);

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
                    anim.SetTrigger("Attacking");
                    timer = 0;
                }
            }
        }
    }

    public void OnAttackAnimationEnd()
    {
        attackPrefab.SetActive(true);
        attackPrefab.GetComponent<AttackEnemy>().attacked = false;
        anim.SetTrigger("FinishedAttack");
        timer=0;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + new Vector3(offsetX, offsetY, 0), new Vector3(attackRangeX, attackRangeY, 0));
    }
}

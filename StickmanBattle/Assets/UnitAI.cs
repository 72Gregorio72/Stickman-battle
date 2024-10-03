using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAI : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject attackPrefab;
    public int hp;
    public float speed;
    public int attack;
    public int attackSpeed;
    public int attackRange;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed, 0);
        //Range
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position + new Vector3(0, 0, 0), attackRange);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy"))
            {
                rb.velocity = new Vector2(0, 0);
                if(timer >= 0.5f){
                    attackPrefab.SetActive(false);
                }
                timer += Time.deltaTime;
                
                if(timer >= 1){
                    attackPrefab.SetActive(true);
                    timer = 0;
                }
                
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + new Vector3(0, 0, 0), attackRange);
    }
}

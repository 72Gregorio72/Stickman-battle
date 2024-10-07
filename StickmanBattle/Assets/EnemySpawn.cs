using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public List<GameObject> unitPrefab;
    private baseHealth bh;

    bool spawnedBoss = false;
    // Start is called before the first frame update
    void Start()
    {
        bh = GetComponentInParent<baseHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(bh.health < 50 && !spawnedBoss){
            SpawnUnit(0);
            spawnedBoss = true;
        }
    }

    public void SpawnUnit(int i)
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + Random.Range(-0.3f, 0.3f), transform.position.z);

        GameObject unit = Instantiate(unitPrefab[i], spawnPosition, Quaternion.identity);
    }
}

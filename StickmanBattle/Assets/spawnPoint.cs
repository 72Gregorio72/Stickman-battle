using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPoint : MonoBehaviour
{
    public List<GameObject> unitPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + Random.Range(-0.3f, 0.3f), transform.position.z);
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            Instantiate(unitPrefab[0], spawnPosition, Quaternion.identity);
        } else if (Input.GetKeyDown(KeyCode.Alpha2)){
            Instantiate(unitPrefab[1], spawnPosition, Quaternion.identity);
        } else if (Input.GetKeyDown(KeyCode.Alpha3)){
            Instantiate(unitPrefab[2], spawnPosition, Quaternion.identity);
        } else if (Input.GetKeyDown(KeyCode.Alpha4)){
            Instantiate(unitPrefab[3], spawnPosition, Quaternion.identity);
        } else if (Input.GetKeyDown(KeyCode.Alpha5)){
            Instantiate(unitPrefab[4], spawnPosition, Quaternion.identity);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{   
    public GameObject[] enemies;
    public Vector3 spawnValues;

    public float spawnWait;
    public int startWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public bool stop;
    int randEnemy;
    void Start()
    {
        StartCoroutine(waitSpawner());
    }

    void Update()
    {
        
    }
    IEnumerator waitSpawner() {
        yield return new WaitForSeconds(startWait);
        while (!stop)
        {
            randEnemy = Random.Range(0, enemies.Length);
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 1, Random.Range(-spawnValues.z, spawnValues.z));
            Instantiate(enemies[randEnemy],spawnPosition + transform.TransformPoint(0, 0, 0),gameObject.transform.rotation);
            spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
            yield return new WaitForSeconds(spawnWait);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public float spawnTimer;
    public float currentTime;
    public GameObject enemy;
    public static GameObject enemyInstance;

    void Start()
    {
        currentTime = spawnTimer;
    }


    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;

        if(currentTime <= 0)
        {
            SpawnEnemies();
            currentTime = spawnTimer;
        }
    }

    void SpawnEnemies()
    {
        enemyInstance = Instantiate(enemy, this.transform.position, this.transform.rotation);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public float spawnTimer; //Declares spawnTimer as a float
    public float currentTime; //Declares currentTime as a float
    public GameObject enemy; //Declares enemy as a GameObject
    public static GameObject enemyInstance; //Declares enemyInstance as a public static GameObject

    void Start()
    {
        currentTime = spawnTimer; //Sets currentTime to be equal to spawnTimer at first
    }


    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime; //Subtracts from currentTime overtime

        if(currentTime <= 0) //Conditional statement to check if currentTime is less than or equal to 0
        {
            SpawnEnemies(); //Call Enemy Spawn method
            currentTime += spawnTimer; //Adds spawnTimer to currentTime
        }
    }

    void SpawnEnemies() 
    {
        enemyInstance = Instantiate(enemy, this.transform.position, this.transform.rotation); //Declares enemyInstance as an instance of the enemy GameObject
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    GameObject player; //Declares player as a GameObject
    private float moveSpeed; //Declares moveSpeed as a float
    private int damage; //Declares damage as an int
    public int enemyHP; //Declares enemyHP as an int

    private float attackTime; //Declares attackTime as a float
    private float currentTime; //Declares currentTime as a float

    private Animator zAnimator; //Declares zAnimator as an Animator

    public AudioClip attackMP3;
    public AudioClip deathMP3;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); //Looks for a GameObject tagged as a player and declares it as the value for player
        moveSpeed = (2f + (playerLevel.playerLvl * 2)); //Sets the moveSpeed as one and has it increase each time the player levels up
        enemyHP = (10 + (playerLevel.playerLvl * 2)); //Sets the HP as 10 and has it increase each time the player levels up
        damage = (2 + (playerLevel.playerLvl * 2)); //Sets the damage as 2 and has it increase each time the player levels up

        attackTime = (4.0f - (float)playerLevel.playerLvl / 2f); //Sets the attackTime as 4 and has it decrease each time the player levels up
        currentTime = attackTime; //Sets currentTime to equal attackTime

        zAnimator = this.gameObject.GetComponent<Animator>(); //Gets the Animator component within the current GameObject and sets it as the value for zAnimator
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(this.gameObject.transform.position, player.transform.position) >= 1 && Vector2.Distance(this.gameObject.transform.position, player.transform.position) <= 1000) //Conditional statement to check if the player is within a certain distance from the enemy
        {
            LookAt2D(this.transform, player.transform.position); // Calls a LookAt Method to get the enemy to look at the player
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, moveSpeed * Time.deltaTime); //Has the GameObject move towards the player 
            zAnimator.Play("Enemy",0,0.0f); //Has zAnimator play a specific animation
        }

        else if (Vector2.Distance(this.gameObject.transform.position, player.transform.position) > 0 && Vector2.Distance(this.gameObject.transform.position, player.transform.position) < 1) //Conditional statement to check if the player is close enough to the enemy
        {
            currentTime -= Time.deltaTime; //currentTime subtracts over time

            if (currentTime <= 0) //Conditional statement to check if currentTime is less than or equal to 0
            {
                Attack(); //Calls Attack method
                this.gameObject.GetComponent<AudioSource>().clip = attackMP3;
                this.gameObject.GetComponent<AudioSource>().Play();
                currentTime += attackTime; //Adds attackTime to currentTime, resetting it.
            }
        }

        if (enemyHP <= 0) //Conditional statement to check if enemyHP is less than or equal to 0
        {
           EnemyDeath(); //Calls Death method
        }
    }

    void Attack()
    {
        playerHealth.currHealth -= damage; //Subtracts damage from player's health
    }

    void EnemyDeath()
    {
        this.gameObject.GetComponent<AudioSource>().clip = deathMP3;
        this.gameObject.GetComponent<AudioSource>().Play();
        Destroy(this.gameObject); //Destroys the current instance of the GameObject
        playerLevel.GiveXP(250 + (250 * playerLevel.playerLvl)); //Calls the GiveXP method within the playerLevel script, uses a simple equation to take 250 and add 250 multiplied by the player's level and pass it to the GiveXP function, increasing the XP that the player receives each time the player levels up
    }

    public static void LookAt2D(Transform transform, Vector2 target)
    {
        Vector2 current = transform.position; 
        var direction = target - current;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); //All the lines of code from 70 to 73 are responsible for turning the GameObject so that it is facing a target GameObject
    }
}
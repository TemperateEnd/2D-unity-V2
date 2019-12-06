using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletCollision : MonoBehaviour
{
    public AudioClip damageClip;
    // Update is called once per frame
    void OnCollisionEnter(Collision col) //Method to detect collision with other objects
    {
        if (col.gameObject.tag == "Enemy") //Conditional statement to check if the object is tagged as an enemy
        {
            col.gameObject.GetComponent<EnemyScript>();
            col.gameObject.GetComponent<AudioSource>().clip = damageClip;
            col.gameObject.GetComponent<AudioSource>().Play();
            col.gameObject.GetComponent<EnemyScript>().enemyHP -= playerAttack.attackDamage; //Gets EnemyScript component from the Object and subtracts the attackDamage from the enemyHP variable
        }
    }
}
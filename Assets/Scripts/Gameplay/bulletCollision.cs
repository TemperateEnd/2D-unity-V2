using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletCollision : MonoBehaviour
{
    // Update is called once per frame
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<EnemyScript>();
            col.gameObject.GetComponent<EnemyScript>().enemyHP -= playerAttack.attackDamage;
        }
    }
}

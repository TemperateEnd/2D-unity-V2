using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    GameObject player;
    public float moveSpeed;
    public int damage;
    public int enemyHP;

    public float attackTime;
    public float currentTime;

    private Animator zAnimator;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        moveSpeed = (1f + (playerLevel.playerLvl * 2));
        enemyHP = (10 + (playerLevel.playerLvl * 2));
        damage = (2 + (playerLevel.playerLvl * 2));

        attackTime = (5.0f / (float)playerLevel.playerLvl / 2f);
        currentTime = attackTime;

        zAnimator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(this.gameObject.transform.position, player.transform.position) >= 1 && Vector2.Distance(this.gameObject.transform.position, player.transform.position) <= 20)
        {
            LookAt2D(this.transform, player.transform.position);
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, moveSpeed * Time.deltaTime);
            zAnimator.Play("Enemy",0,0.0f);
        }

        else if (Vector2.Distance(this.gameObject.transform.position, player.transform.position) > 0 && Vector2.Distance(this.gameObject.transform.position, player.transform.position) < 1)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0)
            {
                Attack();
                currentTime += attackTime;
            }
        }

        if (enemyHP <= 0)
        {
           EnemyDeath();
        }
    }

    void Attack()
    {
        playerHealth.currHealth -= damage;
    }

    void EnemyDeath()
    {
        Destroy(this.gameObject);
        playerLevel.GiveXP(250);
    }

    public static void LookAt2D(Transform transform, Vector2 target)
    {
        Vector2 current = transform.position;
        var direction = target - current;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
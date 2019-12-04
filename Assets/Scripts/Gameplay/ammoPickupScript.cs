using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoPickupScript : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            playerAttack.ammoMags++;
            Destroy(this.gameObject);
        }
    }
}

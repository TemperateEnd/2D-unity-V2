using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private float speed; //Sets speed as a private float variable
    public Transform player; //Sets the player object as a public Transform so that I can drag the player GameObject into the slot on the Inspector, allowing this script to affect the transform positions of the gameobject

    // Start is called before the first frame update
    void Start()
    {
        player = this.transform; //Sets the player's Transform as the transform of the object this script is attached to
    }

    // Update is called once per frame
    void Update()
    { 
        speed = 0.25f + (0.1f * playerLevel.playerLvl); //Sets speed as 0.25, with an extra increase of 0.1 for each time the player levels up
        float horizontal = Input.GetAxis("Horizontal"); //Declares horizontal as a float and stores the horizontal axis that the player is on within it
        float vertical = Input.GetAxis("Vertical"); //Declares vertical as a float and stores the vertical axis that the player is on within it

        Vector2 movement =  new Vector2 (horizontal * speed, vertical * speed); //Declares movement as a Vector2 variable and sets it as horizontal * the speed and vertical * the speed as the x and y axis respectively

       player.Translate(movement); //Takes the movement variable and uses it to translate the player
    }
}
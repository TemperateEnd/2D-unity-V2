using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerLevel : MonoBehaviour
{
    public static int playerLvl; //Declares playerLvl as a public static int so that it can be used in other scripts
    public int xpMod; //Sets xpMod as a public int variable
    public int xpRequired; //Sets xpRequired as a public int variable
    public static int xpCurrent; //Sets xpCurrent as a public static variable so that it can be used in a public static function that can be used in other scripts

    public Slider xpSlider; //Sets xpSlider as a public Slider component
    public Text xpText; //Sets xpText as a public Text component
    public Text levelText; //Sets levelText as a public Text component

    // Start is called before the first frame update
    void Start()
    {
        xpMod = 2; //Sets the xpMod variable as 2 by default
        playerLvl = 0; //Sets the playerLevel variable as 0 by default
    }

    // Update is called once per frame
    void Update()
    {
        xpSlider.maxValue = xpRequired; //Sets the xpSlider's maxValue to update with and equate to xpRequired 
        xpSlider.value = xpCurrent; //Sets the xpSlider's value to update with and equate to xpCurrent
        xpText.text = xpCurrent + " / " + xpRequired; //Sets xpText's Text value to display xpCurrent to the player and compare it to xpRequired
        levelText.text = "Level " + playerLvl; //Sets levelText's Text value to display the playerLvl value to the player

        if(xpCurrent >= xpRequired) //Conditional statement to check if xpCurrent is greater than or equal to xpRequired
        {
            LevelUp(); //Calls the LevelUp function
        }

        //if(Input.GetKeyDown(KeyCode.L)) //Dummy function to test Levelling functionality
        //{
            //GiveXP(500);
        //}
    }

    public static void GiveXP(int XPToGive) //Public static function to give XP; Can be used in other scripts
    {
        xpCurrent += XPToGive; //Adds XPToGive to the xpCurrent
    }

    void LevelUp() //Function to level player up
    {
        playerLvl++; //Increments playerLvl
        xpCurrent -= xpRequired; //Subtracts the xpRequired value from xpCurrent
        xpRequired *= xpMod; //Multiplies xpRequired by xpMod
        playerAttack.ammoMags += 1; //Adds an extra ammo magazine to the ammoMags value in playerAttack.cs
        playerHealth.maxHealth++; //Increases the player's max health by 1
        playerHealth.currHealth = playerHealth.maxHealth; //Replenishes hp each time the player levels up
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{
    public static int currHealth; //Sets currHealth as a public static int variable so that it can be used in other scripts
    public static int maxHealth; //Sets maxHealth as a public static int variable so that it can be used in other scripts
    public Slider hpSlider; //Sets hpSlider as a public Slider so that I can drag and drop the Slider object into the slot in the Inspector
    public Text hpText; //Sets hpText as a public Text so that I can drag and drop the Text object into the slot in the Inspector

    void Start()
    {
        maxHealth = 10; //Sets maxHealth as 10
        currHealth = maxHealth; //Sets the default value of currHealth as maxHealth by default
    }

    // Update is called once per frame
    void Update()
    {
        hpSlider.maxValue = maxHealth; //Has the hpSlider's maxValue update with and equate to the value of maxHealth
        hpSlider.value = currHealth; //has the hpSlider's value update with and equate to the value of currHealth

        hpText.text = currHealth + " / " + maxHealth; //Sets the hpText Text value to show the player's health in comparison to the player's max health value, updating if currHealth decreases

        //if(Input.GetKeyDown(KeyCode.F))
        //{
            //currHealth -= 2;
        //}

        if(currHealth <= 0) //Conditional to check if the player's health is less than or equal to 0
        {
            SceneManager.LoadScene("gameOverScene"); //Loads the gameOver scene
        }
    }
}
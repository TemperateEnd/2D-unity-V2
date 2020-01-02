using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{
    public static int currHealth;
    private int maxHealth;
    public Slider hpSlider;
    public Text hpText;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 10;
        currHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        hpSlider.maxValue = maxHealth;
        hpSlider.value = currHealth;

        hpText.text = currHealth + " / " + maxHealth;

        if(Input.GetKeyDown(KeyCode.F))
        {
            currHealth -= 2;
        }

        if(currHealth <= 0)
        {
            SceneManager.LoadScene("gameOverScene");
        }
    }
}
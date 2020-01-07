using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameOverScene : MonoBehaviour
{
    public Text gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        gameOverText.text = "You have reached Level " + playerLevel.playerLvl + "!";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey)
        {
            playerLevel.playerLvl = 0;
            playerLevel.xpCurrent = 0;
            SceneManager.LoadScene("mainMenu");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorialScript : MonoBehaviour
{
    public Canvas tutorialUI;
    public Text tutorialText;
    private string tutorialString;
    public Button closeBtn;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        tutorialUI.enabled = true;
        closeBtn.onClick.AddListener(CloseBtn_OnClick);
        tutorialString = "Welcome to Necrophobia! Use WASD to move; R to reload (Don't do this every time you fire); and LMB to shoot. You gain XP for each kill; and you level up everytime you reach a certain amount of XP. But the zombies level up too!";
        tutorialText.text = tutorialString;
    }

    void CloseBtn_OnClick()
    {
        tutorialUI.enabled = false;
        Time.timeScale = 1;
    }
}
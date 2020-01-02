using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenuScript : MonoBehaviour
{
    public string[] easterEggStrings;
    public Text easterEggText;

    public Button lvlSelection;
    public Button credits;
    public Button exit;

    void Start()
    {
        System.Random randStr = new System.Random();
        int randMess = randStr.Next(easterEggStrings.Length);
        string message = easterEggStrings[randMess];
        easterEggText.text = message;

        lvlSelection.onClick.AddListener(LevelSelectionClick);
        credits.onClick.AddListener(CreditsClick);
        exit.onClick.AddListener(ExitClick);
    }

    void LevelSelectionClick()
    {
        SceneManager.LoadScene("gameScene");
    }

    void CreditsClick()
    {
        SceneManager.LoadScene("credits");
    }

    void ExitClick()
    {
        Application.Quit();
    }
}
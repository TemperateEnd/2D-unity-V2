using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelSelectionMenuScript : MonoBehaviour
{
    public Image tutorial;
    public Image office;
    public Image forest;
    public Image jungle;

    // Start is called before the first frame update
    void Start()
    {
        tutorial.GetComponent<Button>().onClick.AddListener(TutorialImageOnClick);
        office.GetComponent<Button>().onClick.AddListener(OfficeImageOnClick);
        forest.GetComponent<Button>().onClick.AddListener(ForestImageOnClick);
        jungle.GetComponent<Button>().onClick.AddListener(JungleImageOnClick);
    }

    void TutorialImageOnClick()
    {
        SceneManager.LoadScene("tutorialLevel");
    }

    void OfficeImageOnClick()
    {
        SceneManager.LoadScene("officeLevel");
    }

    void ForestImageOnClick()
    {
        SceneManager.LoadScene("forestLevel");
    }

    void JungleImageOnClick()
    {
        SceneManager.LoadScene("jungleLevel");
    }
}
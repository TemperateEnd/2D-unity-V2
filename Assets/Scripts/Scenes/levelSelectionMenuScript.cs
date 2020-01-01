using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    // Update is called once per frame
    void Update()
    {
        
    }

    void TutorialImageOnClick()
    {

    }

    void OfficeImageOnClick()
    {

    }

    void ForestImageOnClick()
    {

    }

    void JungleImageOnClick()
    {

    }
}
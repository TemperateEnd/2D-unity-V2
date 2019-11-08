using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorialScript : MonoBehaviour
{
    public Canvas tutorialUI;
    public Text tutorialText;
    public string tutorialString;
    public Button closeBtn;

    // Start is called before the first frame update
    void Start()
    {
        tutorialUI.enabled = false;
        closeBtn.onClick.AddListener(CloseBtn_OnClick);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Time.timeScale = 0;
        tutorialUI.enabled = true;
        tutorialText.text = tutorialString;
    }

    void CloseBtn_OnClick()
    {
        tutorialUI.enabled = false;
        Time.timeScale = 1;
        //this.gameObject.SetActive(false);
    }
}

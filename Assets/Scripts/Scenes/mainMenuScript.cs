using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;

public class mainMenuScript : MonoBehaviour
{
    //Animator mainMenuAnimator;

    //void Start()
    //{
        //mainMenuAnimator = GetComponentInChildren<Animator>();
    //}

    // Update is called once per frame
    void Update()
    {
        //mainMenuAnimator.Play("startTitleAnim",0,0);

        if(Input.anyKey)
        {
            SceneManager.LoadScene("gameScene");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;

public class mainMenuScript : MonoBehaviour
{
    //public Text inputText;
    //public float textAlphaValue;

    //void Start()
    //{
        //textAlphaValue = 255;
    //}
    // Update is called once per frame
    void Update()
    {
        //textAlphaValue -= Time.deltaTime * 2;
        
        //if(textAlphaValue == 0)
        //{
            //textAlphaValue += 255;
        //}
        
        if(Input.anyKey)
        {
            SceneManager.LoadScene("gameScene");
        }
    }
}

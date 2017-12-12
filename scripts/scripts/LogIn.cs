using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Security.Cryptography;
using System.Text;

public class LogIn : MonoBehaviour {

    private InputField userName;
    private InputField password;

    Text textLabel;

    private GameState m_gamestate = new GameState();

    public void OnButtonClick()
    {

        userName = GameObject.Find("UserName").GetComponent<InputField>();
        password = GameObject.Find("Password").GetComponent<InputField>();

        textLabel = GameObject.Find("Text").GetComponent<Text>();


        if (m_gamestate.LoadUserData(userName.text, password.text) == true)
        {
            textLabel.text = "LogIn successfull";

            //load main menu
            m_gamestate.LoadScene(1,false);
        }
        else
        {
            textLabel.text = "LogIn failed";
            userName.text = "";
            password.text = "";
        }
        

        
    }
}

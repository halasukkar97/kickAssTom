using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewUser : MonoBehaviour {

    private InputField userName;
    private InputField password;

    Text textLabel;

    private GameState m_gamestate = new GameState();


    public void OnButtonClick()
    {
        userName = GameObject.Find("UserName").GetComponent<InputField>();
        password = GameObject.Find("Password").GetComponent<InputField>();

        textLabel = GameObject.Find("Text").GetComponent<Text>();

        if(m_gamestate.NewUser(userName.text, password.text) == true)
        {
            textLabel.text = "Created new user";

            //load main menu
            //...
        }
        else
        {
            textLabel.text = "Creating new user failed";
            userName.text = "";
            password.text = "";
        }

    }
}

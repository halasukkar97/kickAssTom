using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewUser : MonoBehaviour {

    private InputField m_UserName;
    private InputField m_Password;

    Text m_TextLabel;

    private GameManagement m_GameManagement = new GameManagement();


    public void OnButtonClick()
    {
        m_UserName = GameObject.Find("UserName").GetComponent<InputField>();
        m_Password = GameObject.Find("Password").GetComponent<InputField>();

        m_TextLabel = GameObject.Find("Text").GetComponent<Text>();

        if(m_GameManagement.NewUser(m_UserName.text, m_Password.text) == true)
        {
            m_TextLabel.text = "Created new user";

            //load main menu
            m_GameManagement.LoadScene(3, false);
        }
        else
        {
            m_TextLabel.text = "Creating new user failed";
            m_UserName.text = "";
            m_Password.text = "";
        }

    }
}
